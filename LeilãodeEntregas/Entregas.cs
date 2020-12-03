using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class Entregas
    {
        public Vertex Destino;
        public string Estado;
        public int indice;
        public int Bonus;
        public int HorarioSaida;
        public int TempoTotal;
        public string Caminho;

        public Entregas(int horarioSaida, string estado, int indice, int bonus)
        {
            this.HorarioSaida = horarioSaida;
            this.Estado = estado;
            this.Bonus = bonus;
            this.indice = indice;

            this.Caminho = "A=>" + estado;
        }
    }
}
