using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MFuncionario : MPessoa
    {
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return Nome + " / " + Cpf + " / " + Ativo;
        }
    }
}
