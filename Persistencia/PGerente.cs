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
    public class PGerente
    {
        private string arquivo = "gerentes.xml";

        public List<MGerente> Abrir()
        {
            List<MGerente> listaDeGerentes;
            XmlSerializer x = new XmlSerializer(typeof(List<MGerente>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDeGerentes = (List<MGerente>)x.Deserialize(f);
            }
            catch
            {
                listaDeGerentes = new List<MGerente>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return listaDeGerentes;
        }

        /*public void Salvar(List<MGerente> listaDeGerentes)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<MGerente>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDeGerentes);
            f.Close();
        }*/

        public bool verificaExistenciaGerente(string cpf)
        {
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
