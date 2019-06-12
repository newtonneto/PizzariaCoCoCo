using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class NGerente
    {
        private List<MFuncionario> listaDeFuncionarios = new List<MFuncionario>();
        public void InserirFuncionario(MFuncionario funcionario)
        {
            listaDeFuncionarios.Add(funcionario);
        }

        public List<MFuncionario> ListarFuncionarios()
        {
            return listaDeFuncionarios;
        }
    }
}
