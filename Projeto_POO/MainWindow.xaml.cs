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
 2- Pq não consigo adicionar o "using Persistencia"
 3- Como usar genericos em Pessoa/Funcionario/Gerente
 4- Como usar o ToString em NFuncionario
     */

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

            //Envia o objeto funcionario criado para um objeto de classe gerente
            admin.InserirFuncionario(novoFuncionario);

            //Limpa as TextBoxes
            textBoxNome.Text = String.Empty;
            textBoxCpf.Text = String.Empty;
            radioButtonMasculino.IsChecked = false;
            radioButtonFeminino.IsChecked = false;
            textBoxDataDeNascimento.Text = String.Empty;
            textBoxSenha.Text = String.Empty;

        }

        private void buttonListarFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            List<MFuncionario> listaDeFuncionarios = admin.ListarFuncionarios();

            listBoxFuncionarios.Items.Clear();
            foreach(MFuncionario f in listaDeFuncionarios)
            {
                listBoxFuncionarios.Items.Add(f);
            }
        }
    }
}
