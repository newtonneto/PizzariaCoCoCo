using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NFuncionario
    {
        public void InserirFuncionario(MFuncionario funcionario)
        {
            //Verifica se todos os campos do cadastro foram preenchidos
            if (funcionario.Nome != "" && funcionario.Cpf != "" && funcionario.Sexo != "" && funcionario.Nascimento != null && funcionario.Senha != "" && funcionario.Nascimento != DateTime.MinValue)
            {
                //listaDeFuncionarios.Add(funcionario);
                PFuncionario dados = new PFuncionario();
                if (!dados.verificaExistenciaFuncionario(funcionario.Cpf))
                {
                    List<MFuncionario> listaDeFuncionarios = dados.Abrir();
                    listaDeFuncionarios.Add(funcionario);
                    dados.Salvar(listaDeFuncionarios);
                }
                else
                {
                    throw new UsuarioJaCadastradoException("O CPF informado já possui um cadastro");
                }
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
            List<MFuncionario> listaDeFuncionarios = dados.Abrir();

            return listaDeFuncionarios;
        }

        public void AtualizarFuncionario(MFuncionario funcionario)
        {
            PFuncionario dados = new PFuncionario();
            List<MFuncionario> listaDeFuncionarios = dados.Abrir();
            MFuncionario funcionarioDesatualizado = listaDeFuncionarios.Where(temp => temp.Cpf == funcionario.Cpf).Single();
            //funcionario.Ativo = !funcionarioDesatualizado.Ativo;
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

        public bool autorizaLoginFuncionario(string cpf, string senha)
        {
            PFuncionario dados = new PFuncionario();
            //Utiliza a persistencia para verificar se o CPF passado já foi cadastrado
            if (dados.verificaExistenciaFuncionario(cpf))
            {
                //Se sim, receba a lista de funcionarios e procure pelo funcionario pertencente ao CPF informado
                List<MFuncionario> listaDeFuncionarios = dados.Abrir();
                MFuncionario funcionarioEncontrado = listaDeFuncionarios.Where(temp => temp.Cpf == cpf).Single();

                //Verifique se a senha passada é igual a senha cadastrada
                if (funcionarioEncontrado.Senha == senha)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
