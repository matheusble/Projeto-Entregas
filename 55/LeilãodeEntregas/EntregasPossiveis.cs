using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilãodeEntregas
{
    public class EntregasPossiveis
    {
        public StringBuilder Caminhos = new StringBuilder();
        public int Lucro = 0;

        public EntregasPossiveis(string caminho, int lucro)
        {
            this.Caminhos.Append(caminho);
            this.Lucro += lucro;
        }

        public EntregasPossiveis() { }
    }
}
