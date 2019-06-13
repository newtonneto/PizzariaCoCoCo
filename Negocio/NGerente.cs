using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NGerente
    {
        private List<MFuncionario> listaDeFuncionarios = new List<MFuncionario>();
        public void InserirFuncionario(MFuncionario funcionario)
        {
            //listaDeFuncionarios.Add(funcionario);
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir();
            listaDeFuncionarios.Add(funcionario);
            dados.Salvar(listaDeFuncionarios);
        }

        public List<MFuncionario> ListarFuncionarios()
        {
            //return listaDeFuncionarios;
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir();

            return listaDeFuncionarios;
        }

        public void AtualizarFuncionario(MFuncionario funcionario)
        {
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir();
            MFuncionario funcionarioDesatualizado = listaDeFuncionarios.Where(temp => temp.Cpf == funcionario.Cpf).Single();
            listaDeFuncionarios.Remove(funcionarioDesatualizado);
            listaDeFuncionarios.Add(funcionario);
            dados.Salvar(listaDeFuncionarios);
        }

        public void DeletarFuncionario(MFuncionario funcionario)
        {
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir();
            MFuncionario funcionarioDeletado = listaDeFuncionarios.Where(temp => temp.Cpf == funcionario.Cpf).Single();
            listaDeFuncionarios.Remove(funcionarioDeletado);
            dados.Salvar(listaDeFuncionarios);
        }
    }
}
