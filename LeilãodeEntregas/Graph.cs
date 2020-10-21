using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    class Graph
    {
        public List<Vertex> vertex = new List<Vertex>();
        public Graph() { }
        public void addVertice(string estado)
        {
            Vertex vertice = new Vertex();
            vertice.Estado = estado;
            vertex.Add(vertice);
            Console.WriteLine("Estado Adicionado com sucesso!");
        }

        public void addVizinho(string src, string dst, int tempo)
        {
            bool achou = false;
            foreach (Vertex pai in vertex)
            {
                if (pai.Estado == src)
                {
                    pai.Filhos.Add(new Vertex(pai, dst, tempo));

                    Queue<Vertex> q = new Queue<Vertex>();
                    Queue<Vertex> visitados = new Queue<Vertex>();

                    visitados.Enqueue(vertex[0]);
                    q.Enqueue(vertex[0]);

                    while (q.Count > 0 || !achou)
                    {
                        Vertex vertex = q.Dequeue();

                        if (vertex.Estado == src)
                        {
                            vertex.Filhos.Add(new Vertex(vertex, dst, tempo));
                            achou = true;
                        }
                        else
                        {
                            if (vertex.Filhos != null)
                            {
                                foreach (Vertex fi in vertex.Filhos)
                                    if (!visitados.Contains(fi))
                                    {
                                        q.Enqueue(fi);
                                        visitados.Enqueue(fi);
                                    }
                            }
                        }
                    }

                }
            }

            foreach(Vertex filho in vertex) 
            {
                if (filho.Estado == dst)
                {
                    foreach (Vertex pai in vertex)
                    {
                        if (pai.Estado == src)
                            filho.Pais.Add(pai);
                    }
                }
            }
        }
    }

}
