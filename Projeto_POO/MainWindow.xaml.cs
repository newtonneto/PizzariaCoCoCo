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

namespace Projeto_POO
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        NGerente admin = new NGerente();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void atualizaListBoxFuncionarios()
        {
            List<MFuncionario> listaDeFuncionarios = admin.ListarFuncionarios();

            listBoxFuncionarios.Items.Clear();
            foreach (MFuncionario f in listaDeFuncionarios)
            {
                listBoxFuncionarios.Items.Add(f);
            }
        }

        private void buttonCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            //Cria um novo funcionario pegando as informações contidas nas TextBoxes
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
            admin.InserirFuncionario(novoFuncionario);

            //Limpa as TextBoxes
            textBoxNome.Text = String.Empty;
            textBoxCpf.Text = String.Empty;
            radioButtonMasculino.IsChecked = false;
            radioButtonFeminino.IsChecked = false;
            textBoxDataDeNascimento.Text = String.Empty;
            textBoxSenha.Text = String.Empty;
            atualizaListBoxFuncionarios();
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
            buttonCadastrar.Visibility = Visibility.Collapsed;
            buttonAtualizar.Visibility = Visibility.Visible;
            try
            {
                MFuncionario funcionadoDesatualizado = (MFuncionario)listBoxFuncionarios.SelectedItem;
                textBoxNome.Text = funcionadoDesatualizado.Nome;
                textBoxCpf.Text = funcionadoDesatualizado.Cpf;
                //textBoxCpf.IsEnabled = false; Antes de implementar, encontrar uma forma de reativar sem procisar ficar chamando o metodo em todos os botões
                if(funcionadoDesatualizado.Sexo.Equals("Masculino"))
                {
                    radioButtonMasculino.IsChecked = true;
                }
                else
                {
                    radioButtonFeminino.IsChecked = true;
                }
                textBoxDataDeNascimento.Text = funcionadoDesatualizado.Nascimento.ToString();
                textBoxSenha.Text = funcionadoDesatualizado.Senha;

            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void buttonAtualizar_Click(object sender, RoutedEventArgs e)
        {
            //Cria um novo funcionario pegando as informações contidas nas TextBoxes
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
            admin.AtualizarFuncionario(novoFuncionario);

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

        private void buttonRemoverFuncionario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MFuncionario funcionarioRemover = (MFuncionario)listBoxFuncionarios.SelectedItem;
                admin.DeletarFuncionario(funcionarioRemover);
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
                admin.AtualizarFuncionario(funcionarioEstado);
                atualizaListBoxFuncionarios();
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }
    }
}
