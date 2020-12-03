﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LeilãodeEntregas
{
    public class Dijkstra
    {
        private static List<string> vertices = new List<string>();
        private static readonly int NO_PARENT = -1;
        private static List<EntregasDikstra> dEntregas = new List<EntregasDikstra>();

        // Function that implements Dijkstra's  
        // single source shortest path  
        // algorithm for a graph represented  
        // using adjacency matrix  
        // representation  
        public List<EntregasDikstra> dijkstra(int[,] adjacencyMatrix, int startVertex, List<string> headers)
        {
            /*string k = string.Empty;
            foreach (string x in headers) 
            {
                k += x + "  ";
            }
            
            Console.WriteLine(k);
                */
            vertices = headers;
            int nVertices = adjacencyMatrix.GetLength(0);

            int[] shortestDistances = new int[nVertices];
            bool[] added = new bool[nVertices];

            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            shortestDistances[startVertex] = 0;
            int[] parents = new int[nVertices];
            parents[startVertex] = NO_PARENT;

            // Find shortest path for all  
            // vertices  
            for (int i = 1; i < nVertices; i++)
            {

                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                added[nearestVertex] = true;

                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0
                        && ((shortestDistance + edgeDistance) <
                            shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance +
                                                        edgeDistance;
                    }
                }
            }

            printSolution(startVertex, shortestDistances, parents);

            return dEntregas;
        }

        private static void printSolution(int startVertex,
                                        int[] distances,
                                        int[] parents)
        {
            int nVertices = distances.Length;
            Console.Write("\n\nOrigem/dst\t Distância\tCaminho");

            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                if (vertexIndex != startVertex)
                {
                    Console.Write("\n" + vertices[startVertex] + "=>");
                    Console.Write(vertices[vertexIndex] + " \t\t ");
                    Console.Write(distances[vertexIndex] + "\t\t");
                    dEntregas.Add(new EntregasDikstra(vertices[startVertex] + "=>" + vertices[vertexIndex], distances[vertexIndex] * 2));
                    printPath(vertexIndex, parents);
                }
            }
            Console.WriteLine("\n");
        }
        private static void printPath(int currentVertex,
                                    int[] parents)
        {
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            printPath(parents[currentVertex], parents);
            Console.Write(vertices[currentVertex] + " => ");

        }
    }
}
    
