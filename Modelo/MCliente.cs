using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MCliente : MPessoa
    {
        public List<MPedido> Pedidos { get; set; }

        public override string ToString()
        {
            return Nome + " / " + Cpf;
        }
    }
}
