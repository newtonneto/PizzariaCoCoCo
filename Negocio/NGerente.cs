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
        //private List<MFuncionario> listaDeFuncionarios = new List<MFuncionario>();
        public void InserirFuncionario(MFuncionario funcionario)
        {
            if (funcionario.Nome != "" && funcionario.Cpf != "" && funcionario.Sexo != "" && funcionario.Nascimento != null && funcionario.Senha != "")
            {
                //listaDeFuncionarios.Add(funcionario);
                PFuncionario dados = new PFuncionario();
                List<MFuncionario> listaDeFuncionarios = dados.Abrir("funcionarios.xml");
                listaDeFuncionarios.Add(funcionario);
                dados.Salvar(listaDeFuncionarios, "funcionarios.xml");
            }
            else
            {
                throw new CadastroIncompletoException("Cadastro incompleto, não foi possível finalizar a operação");
            }
        }

        public List<MFuncionario> ListarFuncionarios()
        {
            //return listaDeFuncionarios;
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir("funcionarios.xml");

            return listaDeFuncionarios;
        }

        public void AtualizarFuncionario(MFuncionario funcionario)
        {
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir("funcionarios.xml");
            MFuncionario funcionarioDesatualizado = listaDeFuncionarios.Where(temp => temp.Cpf == funcionario.Cpf).Single();
            listaDeFuncionarios.Remove(funcionarioDesatualizado);
            listaDeFuncionarios.Add(funcionario);
            dados.Salvar(listaDeFuncionarios, "funcionarios.xml");
        }

        public void DeletarFuncionario(MFuncionario funcionario)
        {
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir("funcionarios.xml");
            MFuncionario funcionarioDeletado = listaDeFuncionarios.Where(temp => temp.Cpf == funcionario.Cpf).Single();
            listaDeFuncionarios.Remove(funcionarioDeletado);
            dados.Salvar(listaDeFuncionarios, "funcionarios.xml");
        }

        public bool autorizaLoginGerente(string cpf, string senha)
        {
            PFuncionario dados = new PFuncionario();
            //Utiliza a persistencia para verificar se o CPF passado já foi cadastrado
            if (dados.validaFuncionario(cpf))
            {
                //Se sim, receba a lista de funcionarios e procure pelo funcionario pertencente ao CPF informado
                List<MGerente> listaDeGerentes = dados.Abrir("gerentes.xml");
                MGerente gerenteEncontrado = listaDeGerentes.Where(temp => temp.Cpf == cpf).Single();

                //Verifique se a senha passada é igual a senha cadastrada
                if (gerenteEncontrado.Senha == senha)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
