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
                listaDePizzas.Add(pizza);
                dados.Salvar(listaDePizzas);
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
            listaDePizzas.Remove(pizzaDesatualizada);
            listaDePizzas.Add(pizza);
            dados.Salvar(listaDePizzas);
        }

        public void DeletarPizza(string nomeDaPizza)
        {
            PPizza dados = new PPizza();
            List<MPizza> listaDePizzas = dados.Abrir();
            MPizza pizzaDeletada = listaDePizzas.Where(temp => temp.Tipo == nomeDaPizza).Single();
            listaDePizzas.Remove(pizzaDeletada);
            dados.Salvar(listaDePizzas);
        }
    }
}
