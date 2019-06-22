using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioJaCadastradoException : Exception
    {
        public UsuarioJaCadastradoException()
        {

        }
        public UsuarioJaCadastradoException(string message) : base(message)
        {

        }
        public UsuarioJaCadastradoException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
