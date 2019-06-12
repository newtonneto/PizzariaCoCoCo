using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class MPedido
    {
        public int IdPedido { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public int Mesa { get; set; }
    }
}
