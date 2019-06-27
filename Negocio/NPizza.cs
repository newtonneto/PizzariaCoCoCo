using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{

    public class NPizza
    {
        public void InserirPizza(MPizza pizza)
        {
            //Verifica se todos os campos do cadastro foram preenchidos
            if (pizza.Tipo != "" && pizza.Preco > 0 && pizza.Ingredientes.Count != 0)
            {
                PPizza dados = new PPizza();
                List<MPizza> listaDePizzas = dados.Abrir();
                pizza.IdPizza = listaDePizzas.Count + 1; //Substitui o AtualizarIdPizzaFull()
                listaDePizzas.Add(pizza);
                dados.Salvar(listaDePizzas);
                //AtualizarIdPizzaFull();
            }
            else
            {
                throw new CadastroIncompletoException("Cadastro incompleto, não foi possível finalizar a operação");
            }
        }

        public List<MPizza> ListarPizzas()
        {
            PPizza dados = new PPizza();
            List<MPizza> listaDePizzas = dados.Abrir();

            return listaDePizzas;
        }

        public void AtualizarPizza(MPizza pizza)
        {
            PPizza dados = new PPizza();
            List<MPizza> listaDePizzas = dados.Abrir();
            MPizza pizzaDesatualizada = listaDePizzas.Where(temp => temp.Tipo == pizza.Tipo).Single();
            //pizza.Ativo = !pizzaDesatualizada.Ativo;
            listaDePizzas.Remove(pizzaDesatualizada);
            pizza.IdPizza = listaDePizzas.Count + 1; //Substitui o AtualizarIdPizzaFull()
            listaDePizzas.Add(pizza);
            dados.Salvar(listaDePizzas);
            //AtualizarIdPizzaFull();
        }

        public void AtualizarIdPizzaFull()
        {
            List<MPizza> listaDePizzas = ListarPizzas();
            int id = 1;
            foreach (MPizza p in listaDePizzas)
            {
                p.IdPizza = id;
                AtualizarPizza(p);
                id++;
            }

        }

        public MPizza RetornaPizza(int idPizza)
        {
            List<MPizza> listaDePizzas = ListarPizzas();
            foreach (MPizza p in listaDePizzas)
            {
                if (p.IdPizza == idPizza)
                {
                    return p;
                }
            }

            return null;
        }

        public void DeletarPizza(string nomeDaPizza)
        {
            PPizza dados = new PPizza();
            List<MPizza> listaDePizzas = dados.Abrir();
            MPizza pizzaDeletada = listaDePizzas.Where(temp => temp.Tipo == nomeDaPizza).Single();
            listaDePizzas.Remove(pizzaDeletada);
            
            for (int i = pizzaDeletada.IdPizza; i <= listaDePizzas.Count; i++)
            {
                listaDePizzas[i - 1].IdPizza = i;
            }

            dados.Salvar(listaDePizzas);
        }
    }
}
