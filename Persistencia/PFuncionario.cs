using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Modelo;

namespace Persistencia
{
    public class PFuncionario
    {
        //private string arquivo = "funcionarios.xml";
        public List<MFuncionario> Abrir(string nomeArquivo)
        {
            string arquivo = nomeArquivo;
            List<MFuncionario> listaDeFuncionarios;
            XmlSerializer x = new XmlSerializer(typeof(List<MFuncionario>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDeFuncionarios = (List<MFuncionario>)x.Deserialize(f);
            }
            catch
            {
                listaDeFuncionarios = new List<MFuncionario>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return listaDeFuncionarios;
        }

        public void Salvar(List<MFuncionario> listaDeFunciorios, string nomeArquivo)
        {
            string arquivo = nomeArquivo;
            XmlSerializer x = new XmlSerializer(typeof(List<MFuncionario>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDeFunciorios);
            f.Close();
        }

        public bool validaFuncionario(string cpf)
        {
            string arquivo = "funcionarios.xml";
            List<MFuncionario> listaDeFuncionarios;
            XmlSerializer x = new XmlSerializer(typeof(List<MFuncionario>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDeFuncionarios = (List<MFuncionario>)x.Deserialize(f);

                foreach (MFuncionario funcionario in listaDeFuncionarios)
                {
                    if (funcionario.Cpf == cpf)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                listaDeFuncionarios = new List<MFuncionario>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return false;
        }

        public bool verificaExistenciaGerente(string cpf)
        {
            string arquivo = "gerentes.xml";
            List<MGerente> listaDeGerentes;
            XmlSerializer x = new XmlSerializer(typeof(List<MGerente>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDeGerentes = (List<MGerente>)x.Deserialize(f);

                foreach (MGerente gerente in listaDeGerentes)
                {
                    if (gerente.Cpf == cpf)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                listaDeGerentes = new List<MGerente>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return false;
        }
    }
}
