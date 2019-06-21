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
        public bool autorizaLoginFuncionario(string cpf, string senha)
        {
            PFuncionario dados = new PFuncionario();
            //Utiliza a persistencia para verificar se o CPF passado já foi cadastrado
            if (dados.validaFuncionario(cpf))
            {
                //Se sim, receba a lista de funcionarios e procure pelo funcionario pertencente ao CPF informado
                List<MFuncionario> listaDeFuncionarios = dados.Abrir("funcionarios.xml");
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
