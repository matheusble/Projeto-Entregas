using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class Vertex
    {
        public string Estado;
        public int Tempo = 0;
        public int Nivel = 0;
        public List<Vertex> Pais = new List<Vertex>();
        public List<Vertex> Filhos = new List<Vertex>();

        public Vertex() { }

        public Vertex(string estado) 
        {
            this.Estado = estado;
        }

        public Vertex(Vertex src, string estado, int tempo) 
        {
            Pais.Add(src);
            this.Nivel = src.Nivel + 1;
            this.Estado = estado;
            this.Tempo = tempo;
        }

    }
}
