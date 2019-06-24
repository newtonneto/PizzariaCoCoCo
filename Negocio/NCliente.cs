using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NCliente
    {
        public void InserirCliente(MCliente cliente)
        {
            //Verifica se todos os campos do cadastro foram preenchidos
            if (cliente.Nome != "" && cliente.Cpf != "" && cliente.Sexo != "" && cliente.Nascimento != null && cliente.Nascimento != DateTime.MinValue)
            {
                PCliente dados = new PCliente();
                if (!dados.verificaExistenciaCliente(cliente.Cpf))
                {
                    List<MCliente> listaDeClientes = dados.Abrir();
                    listaDeClientes.Add(cliente);
                    dados.Salvar(listaDeClientes);
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

        public List<MCliente> ListarClientes()
        {
            PCliente dados = new PCliente();
            List<MCliente> listaDeClientes = dados.Abrir();

            return listaDeClientes;
        }

        public void AtualizarCliente(MCliente cliente)
        {
            PCliente dados = new PCliente();
            List<MCliente> listaDeClientes = dados.Abrir();
            MCliente clienteDesatualizado = listaDeClientes.Where(temp => temp.Cpf == cliente.Cpf).Single();
            listaDeClientes.Remove(clienteDesatualizado);
            listaDeClientes.Add(cliente);
            dados.Salvar(listaDeClientes);
        }

        public void DeletarCliente(MCliente cliente)
        {
            PCliente dados = new PCliente();
            List<MCliente> listaDeClientes = dados.Abrir();
            MCliente clienteDeletado = listaDeClientes.Where(temp => temp.Cpf == cliente.Cpf).Single();
            listaDeClientes.Remove(clienteDeletado);
            dados.Salvar(listaDeClientes);
        }
    }
}
