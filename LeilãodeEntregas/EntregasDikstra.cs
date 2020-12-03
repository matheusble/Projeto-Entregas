using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class EntregasDikstra
    {
        public string dijksCaminho = string.Empty;
        public int dijksDistancia = 0;


        public EntregasDikstra(string c, int d) 
        {
            this.dijksCaminho = c;
            this.dijksDistancia = d;
        }
    }
}
