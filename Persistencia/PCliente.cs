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
    public class PCliente
    {
        private string arquivo = "clientes.xml";
        public List<MCliente> Abrir()
        {
            List<MCliente> listaDeClientes;
            XmlSerializer x = new XmlSerializer(typeof(List<MCliente>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDeClientes = (List<MCliente>)x.Deserialize(f);
            }
            catch
            {
                listaDeClientes = new List<MCliente>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return listaDeClientes;
        }

        public void Salvar(List<MCliente> listaDeClientes)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<MCliente>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDeClientes);
            f.Close();
        }

        public bool verificaExistenciaCliente(string cpf)
        {
            List<MCliente> listaDeClientes;
            XmlSerializer x = new XmlSerializer(typeof(List<MCliente>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDeClientes = (List<MCliente>)x.Deserialize(f);

                foreach (MCliente cliente in listaDeClientes)
                {
                    if (cliente.Cpf == cpf)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                listaDeClientes = new List<MCliente>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return false;
        }
    }
}
