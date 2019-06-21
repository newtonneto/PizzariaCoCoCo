using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CadastroIncompletoException : Exception
    {
        public CadastroIncompletoException()
        {

        }
        public CadastroIncompletoException(string message) : base(message)
        {

        }
        public CadastroIncompletoException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
