using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class Mapa
    {
        public string Origem;
        public string Destino;
        public int Tempo;


        public Mapa(string orig, string dest, int minutos)
        {
            this.Origem = orig;
            this.Destino = dest;
            this.Tempo = minutos;
        }
    }
}
