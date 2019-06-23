using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MPizza
    {
        public int IdPizza { get; set; }
        public string Tipo { get; set; }
        public double Preco { get; set; }
        public List<string> Ingredientes { get; set; }

        public override string ToString()
        {
            return Tipo + " / R$" + Preco;
        }
    }
}
