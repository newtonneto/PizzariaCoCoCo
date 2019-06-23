using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modelo;
using Negocio;

/* PERGUNTAS PRA GILBERT 
 1- Como evitar que um funcionario/cliente seja criado com informações faltando (exceção)
    Resp: A verificação deve ser feita na classe negocio, através de ifs, se tiver incompleta retorne exceção
     */

/* IMPLEMENTAR
 1- Impedir que seja criado objetos com CPFs iguais, gerando exceção
 2- Alterar botões da lista ao selecionar um funcionario, tipo Ativar/Desativar (funcionário)*/

namespace Pizzaria_CoCoCo
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        NGerente admin = new NGerente();
        NFuncionario funcionario = new NFuncionario();
        NPizza pizza = new NPizza();
        public MainWindow()
        {
            InitializeComponent();
            atualizaListBoxFuncionarios();
            atualizaListBoxPizzas();
        }

        private void atualizaListBoxFuncionarios()
        {
            List<MFuncionario> listaDeFuncionarios = funcionario.ListarFuncionarios();

            listBoxFuncionarios.Items.Clear();
            foreach (MFuncionario f in listaDeFuncionarios)
            {
                listBoxFuncionarios.Items.Add(f);
            }
        }

        private void atualizaListBoxPizzas()
        {
            List<MPizza> listaDePizzas = pizza.ListarPizzas();

            listBoxPizzas.Items.Clear();
            foreach (MPizza p in listaDePizzas)
            {
                listBoxPizzas.Items.Add(p);
            }
        }

        private void ativaTextBoxes()
        {
            textBoxNome.IsEnabled = true;
            textBoxCpf.IsEnabled = true;
            radioButtonMasculino.IsEnabled = true;
            radioButtonFeminino.IsEnabled = true;
            textBoxDataDeNascimento.IsEnabled = true;
            textBoxSenha.IsEnabled = true;

        }

        //Reseta todos os campos do cadastro de funcionario
        private void ResetaCadastroFuncionario()
        {
            textBoxNome.Text = String.Empty;
            textBoxCpf.Text = String.Empty;
            radioButtonMasculino.IsChecked = false;
            radioButtonFeminino.IsChecked = false;
            textBoxDataDeNascimento.Text = String.Empty;
            textBoxSenha.Text = String.Empty;
            buttonCadastrar.Visibility = Visibility.Visible;
            buttonAtualizar.Visibility = Visibility.Collapsed;
            atualizaListBoxFuncionarios();
        }

        //Reseta todos os campos do cadastro de pizza
        private void ResetaCadastroPizza()
        {
            textBoxNomePizza.Text = String.Empty;
            checkBoxAzeitona.IsChecked = false;
            checkBoxBacon.IsChecked = false;
            checkBoxBrocolis.IsChecked = false;
            checkBoxCalabresa.IsChecked = false;
            checkBoxCamarao.IsChecked = false;
            checkBoxCarneDeSol.IsChecked = false;
            checkBoxCatupiry.IsChecked = false;
            checkBoxCebola.IsChecked = false;
            checkBoxChampignon.IsChecked = false;
            checkBoxErvilha.IsChecked = false;
            checkBoxFrango.IsChecked = false;
            checkBoxLombo.IsChecked = false;
            checkBoxManjericao.IsChecked = false;
            checkBoxMilho.IsChecked = false;
            checkBoxMolhoDeTomate.IsChecked = false;
            checkBoxOregano.IsChecked = false;
            checkBoxOvo.IsChecked = false;
            checkBoxPalmito.IsChecked = false;
            checkBoxPepperoni.IsChecked = false;
            checkBoxPresunto.IsChecked = false;
            checkBoxQueijoCoalho.IsChecked = false;
            checkBoxQueijoGorgonzola.IsChecked = false;
            checkBoxQueijoMussarela.IsChecked = false;
            checkBoxQueijoParmessao.IsChecked = false;
            checkBoxQueijoProvolone.IsChecked = false;
            checkBoxRucula.IsChecked = false;
            checkBoxTomate.IsChecked = false;
            checkBoxTomateCereja.IsChecked = false;
            atualizaListBoxPizzas();
        }

        private void ButtonEntrarSistema_Click(object sender, RoutedEventArgs e)
        {
            if (admin.autorizaLoginGerente(textBoxLoginCpf.Text, textBoxLoginSenha.Text))
            {
                gridLogin.Visibility = Visibility.Collapsed;
                gridGerente.Visibility = Visibility.Visible;
            }
            else if (funcionario.autorizaLoginFuncionario(textBoxLoginCpf.Text, textBoxLoginSenha.Text))
            {
                gridLogin.Visibility = Visibility.Collapsed;
                gridFuncionario.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBoxResult exibeErro = MessageBox.Show("CPF e/ou senha incorretos");
            }
        }

        private void buttonCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            ativaTextBoxes();
            //Cria um novo funcionario pegando as informações contidas nas TextBoxes
            try
            {
                MFuncionario novoFuncionario = new MFuncionario();
                novoFuncionario.Nome = textBoxNome.Text;
                novoFuncionario.Cpf = textBoxCpf.Text;
                if (radioButtonMasculino.IsChecked == true)
                {
                    novoFuncionario.Sexo = "Masculino";
                }
                if (radioButtonFeminino.IsChecked == true)
                {
                    novoFuncionario.Sexo = "Feminino";
                }
                novoFuncionario.Nascimento = DateTime.Parse(textBoxDataDeNascimento.Text);
                novoFuncionario.Senha = textBoxSenha.Text;
                novoFuncionario.Ativo = true;

                //Envia o objeto funcionario criado para um objeto de classe gerente
                funcionario.InserirFuncionario(novoFuncionario);
            }
            catch (CadastroIncompletoException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            catch (Exception erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            finally
            {
                ResetaCadastroFuncionario();
            }
        }

        private void buttonListarFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            /*List<MFuncionario> listaDeFuncionarios = admin.ListarFuncionarios();

            listBoxFuncionarios.Items.Clear();
            foreach(MFuncionario f in listaDeFuncionarios)
            {
                listBoxFuncionarios.Items.Add(f);
            }*/
            atualizaListBoxFuncionarios();
        }

        private void buttonAtualizarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            ativaTextBoxes();
            buttonCadastrar.Visibility = Visibility.Collapsed;
            buttonAtualizar.Visibility = Visibility.Visible;
            try
            {
                MFuncionario funcionarioDesatualizado = (MFuncionario)listBoxFuncionarios.SelectedItem;
                textBoxNome.Text = funcionarioDesatualizado.Nome;
                textBoxCpf.Text = funcionarioDesatualizado.Cpf;
                textBoxCpf.IsEnabled = false; //Antes de implementar, encontrar uma forma de reativar sem procisar ficar chamando o metodo em todos os botões
                if (funcionarioDesatualizado.Sexo.Equals("Masculino"))
                {
                    radioButtonMasculino.IsChecked = true;
                }
                else
                {
                    radioButtonFeminino.IsChecked = true;
                }
                textBoxDataDeNascimento.Text = funcionarioDesatualizado.Nascimento.ToString();
                textBoxSenha.Text = funcionarioDesatualizado.Senha;

            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void buttonAtualizar_Click(object sender, RoutedEventArgs e)
        {
            ativaTextBoxes();
            //Cria um novo funcionario pegando as informações contidas nas TextBoxes
            try
            {
                MFuncionario novoFuncionario = new MFuncionario();
                novoFuncionario.Nome = textBoxNome.Text;
                novoFuncionario.Cpf = textBoxCpf.Text;
                if (radioButtonMasculino.IsChecked == true)
                {
                    novoFuncionario.Sexo = "Masculino";
                }
                if (radioButtonFeminino.IsChecked == true)
                {
                    novoFuncionario.Sexo = "Feminino";
                }
                novoFuncionario.Nascimento = DateTime.Parse(textBoxDataDeNascimento.Text);
                novoFuncionario.Senha = textBoxSenha.Text;

                //Envia o objeto funcionario criado para um objeto de classe gerente
                funcionario.AtualizarFuncionario(novoFuncionario);
            }
            catch (CadastroIncompletoException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            catch (Exception erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            finally
            {
                //Limpa as TextBoxes
                textBoxNome.Text = String.Empty;
                textBoxCpf.Text = String.Empty;
                radioButtonMasculino.IsChecked = false;
                radioButtonFeminino.IsChecked = false;
                textBoxDataDeNascimento.Text = String.Empty;
                textBoxSenha.Text = String.Empty;
                buttonCadastrar.Visibility = Visibility.Visible;
                buttonAtualizar.Visibility = Visibility.Collapsed;
                atualizaListBoxFuncionarios();
            }
        }

        private void buttonRemoverFuncionario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MFuncionario funcionarioRemover = (MFuncionario)listBoxFuncionarios.SelectedItem;
                funcionario.DeletarFuncionario(funcionarioRemover);
                atualizaListBoxFuncionarios();
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void buttonDesativarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MFuncionario funcionarioEstado = (MFuncionario)listBoxFuncionarios.SelectedItem;
                funcionarioEstado.Ativo = false;
                funcionario.AtualizarFuncionario(funcionarioEstado);
                atualizaListBoxFuncionarios();
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        //Cria um novo delicioso sabor de pizza uhmm uhmm uhmm
        private void buttonCadastrarPizza_Click(object sender, RoutedEventArgs e)
        {
            //Lista para armazenar todos os ingredientes da pizza
            List<string> ingredientes = new List<string>();

            try
            {
                MPizza novaPizza = new MPizza();
                novaPizza.Tipo = textBoxNomePizza.Text;

                if (checkBoxAzeitona.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Azeitona");
                }
                if (checkBoxBacon.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Bacon");
                }
                if (checkBoxBrocolis.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Brócolis");
                }
                if (checkBoxCalabresa.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Calabresa");
                }
                if (checkBoxCamarao.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Camarão");
                }
                if (checkBoxCarneDeSol.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Carne de Sol");
                }
                if (checkBoxCatupiry.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Catupiry");
                }
                if (checkBoxCebola.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Cebola");
                }
                if (checkBoxChampignon.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Champignon");
                }
                if (checkBoxErvilha.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Ervilha");
                }
                if (checkBoxFrango.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Frango");
                }
                if (checkBoxLombo.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Lombo");
                }
                if (checkBoxManjericao.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Manjericão");
                }
                if (checkBoxMilho.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Milho");
                }
                if (checkBoxMolhoDeTomate.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Molho de Tomate");
                }
                if (checkBoxOregano.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Orégano");
                }
                if (checkBoxOvo.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Ovo");
                }
                if (checkBoxPalmito.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Palmito");
                }
                if (checkBoxPepperoni.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Pepperoni");
                }
                if (checkBoxPresunto.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Presunto");
                }
                if (checkBoxQueijoCoalho.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Coalho");
                }
                if (checkBoxQueijoGorgonzola.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Gorgonzola");
                }
                if (checkBoxQueijoMussarela.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Mussarela");
                }
                if (checkBoxQueijoParmessao.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Parmessão");
                }
                if (checkBoxQueijoProvolone.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Provolone");
                }
                if (checkBoxRucula.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Rúcula");
                }
                if (checkBoxTomate.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Tomate");
                }
                if (checkBoxTomateCereja.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Tomate Cereja");
                }

                novaPizza.Ingredientes = ingredientes;
                novaPizza.Preco = Double.Parse(textBoxPreco.Text);
                novaPizza.Ativo = true;

                pizza.InserirPizza(novaPizza);
            }
            catch (CadastroIncompletoException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            finally
            {
                ResetaCadastroPizza();
            }
        }

        private void CheckBoxAzeitona_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxAzeitona.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 1.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 1.0).ToString();
            }
        }

        private void CheckBoxBacon_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxBacon.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.0).ToString();
            }
        }

        private void CheckBoxBrocolis_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxBrocolis.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.0).ToString();
            }
        }

        private void CheckBoxCalabresa_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxCalabresa.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 2.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 2.0).ToString();
            }
        }

        private void CheckBoxCamarao_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxCamarao.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.0).ToString();
            }
        }

        private void CheckBoxCarneDeSol_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxCarneDeSol.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 2.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 2.50).ToString();
            }
        }

        private void CheckBoxCatupiry_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxCatupiry.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 1.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 1.50).ToString();
            }
        }

        private void CheckBoxCebola_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxCebola.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 1.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 1.0).ToString();
            }
        }

        private void CheckBoxChampignon_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxChampignon.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.50).ToString();
            }
        }

        private void CheckBoxErvilha_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxErvilha.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 0.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 0.50).ToString();
            }
        }

        private void CheckBoxFrango_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxFrango.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 4.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 4.0).ToString();
            }
        }

        private void CheckBoxLombo_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxLombo.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 5.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 5.0).ToString();
            }
        }

        private void CheckBoxManjericao_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxManjericao.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 1.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 1.0).ToString();
            }
        }

        private void CheckBoxMilho_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxMilho.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 0.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 0.50).ToString();
            }
        }

        private void CheckBoxMolhoDeTomate_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxMolhoDeTomate.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.0).ToString();
            }
        }

        private void CheckBoxOregano_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxOregano.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 0.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 0.50).ToString();
            }
        }

        private void CheckBoxOvo_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxOvo.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 1.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 1.0).ToString();
            }
        }

        private void CheckBoxPalmito_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxPalmito.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.50).ToString();
            }
        }

        private void CheckBoxPepperoni_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxPepperoni.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.0).ToString();
            }
        }

        private void CheckBoxPresunto_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxPresunto.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 2.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 2.0).ToString();
            }
        }

        private void CheckBoxQueijoCoalho_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxQueijoCoalho.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 4.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 4.50).ToString();
            }
        }

        private void CheckBoxQueijoGorgonzola_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxQueijoGorgonzola.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 4.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 4.0).ToString();
            }
        }

        private void CheckBoxQueijoMussarela_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxQueijoMussarela.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 2.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 2.0).ToString();
            }
        }

        private void CheckBoxQueijoParmessao_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxQueijoParmessao.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 3.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 3.0).ToString();
            }
        }

        private void CheckBoxQueijoProvolone_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxQueijoProvolone.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 5.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 5.0).ToString();
            }
        }

        private void CheckBoxRucula_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxRucula.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 2.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 2.0).ToString();
            }
        }

        private void CheckBoxTomate_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxTomate.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 1.50).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 1.50).ToString();
            }
        }

        private void CheckBoxTomateCereja_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxTomateCereja.IsChecked.GetValueOrDefault())
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) + 2.0).ToString();
            }
            else
            {
                textBoxPreco.Text = (Double.Parse(textBoxPreco.Text) - 2.0).ToString();
            }
        }

        private void ButtonListarPizzas_Click(object sender, RoutedEventArgs e)
        {
            atualizaListBoxPizzas();
        }

        private void ButtonAtualizarPizza_Click(object sender, RoutedEventArgs e)
        {
            buttonCadastrarPizza.Visibility = Visibility.Collapsed;
            buttonAtualizarCadastroPizza.Visibility = Visibility.Visible;
            try
            {
                MPizza pizzaDesatualizada = (MPizza)listBoxPizzas.SelectedItem;
                textBoxNomePizza.Text = pizzaDesatualizada.Tipo;
                //textBoxPreco.Text = pizzaDesatualizada.Preco.ToString();

                //Ativa as checkbox de ingredientes
                foreach (string ingrediente in pizzaDesatualizada.Ingredientes)
                {
                    if (ingrediente == "Azeitona")
                    {
                        checkBoxAzeitona.IsChecked = true;
                    }
                    else if (ingrediente == "Bacon")
                    {
                        checkBoxBacon.IsChecked = true;
                    }
                    else if (ingrediente == "Brócolis")
                    {
                        checkBoxBrocolis.IsChecked = true;
                    }
                    else if (ingrediente == "Calabresa")
                    {
                        checkBoxCalabresa.IsChecked = true;
                    }
                    else if (ingrediente == "Camarão")
                    {
                        checkBoxCamarao.IsChecked = true;
                    }
                    else if (ingrediente == "Carne de Sol")
                    {
                        checkBoxCarneDeSol.IsChecked = true;
                    }
                    else if (ingrediente == "Catupiry")
                    {
                        checkBoxCatupiry.IsChecked = true;
                    }
                    else if (ingrediente == "Cebola")
                    {
                        checkBoxCebola.IsChecked = true;
                    }
                    else if (ingrediente == "Champignon")
                    {
                        checkBoxChampignon.IsChecked = true;
                    }
                    else if (ingrediente == "Ervilha")
                    {
                        checkBoxErvilha.IsChecked = true;
                    }
                    else if (ingrediente == "Frango")
                    {
                        checkBoxFrango.IsChecked = true;
                    }
                    else if (ingrediente == "Lombo")
                    {
                        checkBoxLombo.IsChecked = true;
                    }
                    else if (ingrediente == "Manjericão")
                    {
                        checkBoxManjericao.IsChecked = true;
                    }
                    else if (ingrediente == "Milho")
                    {
                        checkBoxMilho.IsChecked = true;
                    }
                    else if (ingrediente == "Molho de Tomate")
                    {
                        checkBoxMolhoDeTomate.IsChecked = true;
                    }
                    else if (ingrediente == "Orégano")
                    {
                        checkBoxOregano.IsChecked = true;
                    }
                    else if (ingrediente == "Ovo")
                    {
                        checkBoxOvo.IsChecked = true;
                    }
                    else if (ingrediente == "Palmito")
                    {
                        checkBoxPalmito.IsChecked = true;
                    }
                    else if (ingrediente == "Pepperoni")
                    {
                        checkBoxPepperoni.IsChecked = true;
                    }
                    else if (ingrediente == "Presunto")
                    {
                        checkBoxPresunto.IsChecked = true;
                    }
                    else if (ingrediente == "Queijo Coalho")
                    {
                        checkBoxQueijoCoalho.IsChecked = true;
                    }
                    else if (ingrediente == "Gorgonzola")
                    {
                        checkBoxQueijoGorgonzola.IsChecked = true;
                    }
                    else if (ingrediente == "Mussarela")
                    {
                        checkBoxQueijoMussarela.IsChecked = true;
                    }
                    else if (ingrediente == "Parmessão")
                    {
                        checkBoxQueijoParmessao.IsChecked = true;
                    }
                    else if (ingrediente == "Provolone")
                    {
                        checkBoxQueijoProvolone.IsChecked = true;
                    }
                    else if (ingrediente == "Rúcula")
                    {
                        checkBoxRucula.IsChecked = true;
                    }
                    else if (ingrediente == "Tomate")
                    {
                        checkBoxTomate.IsChecked = true;
                    }
                    else if (ingrediente == "Tomate Cereja")
                    {
                        checkBoxTomateCereja.IsChecked = true;
                    }
                }
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void ButtonAtualizarCadastroPizza_Click(object sender, RoutedEventArgs e)
        {
            List<string> ingredientes = new List<string>();

            try
            {
                MPizza novaPizza = new MPizza();
                novaPizza.Tipo = textBoxNomePizza.Text;

                if (checkBoxAzeitona.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Azeitona");
                }
                if (checkBoxBacon.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Bacon");
                }
                if (checkBoxBrocolis.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Brócolis");
                }
                if (checkBoxCalabresa.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Calabresa");
                }
                if (checkBoxCamarao.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Camarão");
                }
                if (checkBoxCarneDeSol.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Carne de Sol");
                }
                if (checkBoxCatupiry.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Catupiry");
                }
                if (checkBoxCebola.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Cebola");
                }
                if (checkBoxChampignon.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Champignon");
                }
                if (checkBoxErvilha.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Ervilha");
                }
                if (checkBoxFrango.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Frango");
                }
                if (checkBoxLombo.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Lombo");
                }
                if (checkBoxManjericao.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Manjericão");
                }
                if (checkBoxMilho.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Milho");
                }
                if (checkBoxMolhoDeTomate.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Molho de Tomate");
                }
                if (checkBoxOregano.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Orégano");
                }
                if (checkBoxOvo.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Ovo");
                }
                if (checkBoxPalmito.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Palmito");
                }
                if (checkBoxPepperoni.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Pepperoni");
                }
                if (checkBoxPresunto.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Presunto");
                }
                if (checkBoxQueijoCoalho.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Coalho");
                }
                if (checkBoxQueijoGorgonzola.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Gorgonzola");
                }
                if (checkBoxQueijoMussarela.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Mussarela");
                }
                if (checkBoxQueijoParmessao.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Parmessão");
                }
                if (checkBoxQueijoProvolone.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Queijo Provolone");
                }
                if (checkBoxRucula.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Rúcula");
                }
                if (checkBoxTomate.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Tomate");
                }
                if (checkBoxTomateCereja.IsChecked.GetValueOrDefault())
                {
                    ingredientes.Add("Tomate Cereja");
                }

                novaPizza.Ingredientes = ingredientes;
                novaPizza.Preco = Double.Parse(textBoxPreco.Text);

                pizza.AtualizarPizza(novaPizza);
            }
            catch (CadastroIncompletoException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            finally
            {
                ResetaCadastroPizza();
            }
        }

        private void ButtonDesativarPizza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MPizza pizzaEstado = (MPizza)listBoxPizzas.SelectedItem;
                pizzaEstado.Ativo = false;
                pizza.AtualizarPizza(pizzaEstado);
                atualizaListBoxPizzas();
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void ButtonRemoverPizza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MPizza pizzaRemover = (MPizza)listBoxPizzas.SelectedItem;
                pizza.DeletarPizza(pizzaRemover.Tipo);
                atualizaListBoxPizzas();
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }
    }
}