using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class BFS
    {
        public static Vertex Buscar(Vertex raiz, string s)
        {
            string caminho = string.Empty;

            Queue<Vertex> q = new Queue<Vertex>();
            Queue<Vertex> visitados = new Queue<Vertex>();

            visitados.Enqueue(raiz);
            q.Enqueue(raiz);

            while (q.Count > 0)
            {
                Vertex vertex = q.Dequeue();

                if (vertex.Estado == s)
                    return vertex;

                if (vertex.Filhos != null) {
                    foreach (Vertex fi in vertex.Filhos)
                        if (!visitados.Contains(fi))
                        {
                            q.Enqueue(fi);
                            visitados.Enqueue(fi);
                        }
                }
            }
            return null;
        }
    }
}
