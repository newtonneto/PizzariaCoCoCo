using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NPedido
    {
        public void InserirPedido(MPedido pedido)
        {
            //Verifica se todos os campos do cadastro foram preenchidos
            if (pedido.Cliente != null && pedido.Total > 0)
            {
                PPedido dados = new PPedido();
                List<MPedido> listaDePedidos = dados.Abrir();
                pedido.IdPedido = listaDePedidos.Count + 1;
                listaDePedidos.Add(pedido);
                dados.Salvar(listaDePedidos);
            }
            else
            {
                throw new CadastroIncompletoException("Cadastro incompleto, não foi possível finalizar a operação");
            }
        }

        public void DeletarPedido(MPedido pedido)
        {
            PPedido dados = new PPedido();
            List<MPedido> listaDePedidos = dados.Abrir();
            MPedido pedidoDeletado = listaDePedidos.Where(temp => temp.IdPedido == pedido.IdPedido).Single();
            listaDePedidos.Remove(pedidoDeletado);
            dados.Salvar(listaDePedidos);
        }

        public List<MPedido> ListarPedidos()
        {
            PPedido dados = new PPedido();
            List<MPedido> listaDePedidos = dados.Abrir();

            return listaDePedidos;
        }
    }
}
