using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NItemPedido
    {
        public void InserirPedidoPizza(MItemPedido itemPedido)
        {
            PItemPedido dados = new PItemPedido();
            List<MItemPedido> listaDeItensPedidos = dados.Abrir();
            listaDeItensPedidos.Add(itemPedido);
            dados.Salvar(listaDeItensPedidos);
        }

        public List<MItemPedido> ListarItensPedidos()
        {
            PItemPedido dados = new PItemPedido();
            List<MItemPedido> listaDeItensPedidos = dados.Abrir();

            return listaDeItensPedidos;
        }

        public List<MPizza> PizzasPedidas(int idPedido)
        {
            List<MPizza> listaDePizzas = new List<MPizza>();
            NPizza pizza = new NPizza();
            //List<MItemPedido> listaDeItensPedidos = new List<MItemPedido>();
            //listaDeItensPedidos.Add(ListarItensPedidos().Where(temp => temp.IdPedido == idPedido));
            foreach (MItemPedido ip in ListarItensPedidos())
            {
                if (ip.IdPedido == idPedido)
                {
                    listaDePizzas.Add(pizza.RetornaPizza(ip.IdPizza));
                }
            }


            return listaDePizzas; 
        }
    }
}
