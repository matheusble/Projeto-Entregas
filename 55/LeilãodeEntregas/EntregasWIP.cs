using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class EntregasWIP 
    {
        public string caminho;
        public int horarioSaida;
        public int horarioTermino;
        public int custo;
        public int predecessora;
        public int BonusTotal;


        public EntregasWIP(string caminho, int saida, int fim, int custo) 
        {
            this.caminho = caminho;
            this.horarioSaida = saida;
            this.horarioTermino = fim;
            this.custo = custo;
        }
    }
}
