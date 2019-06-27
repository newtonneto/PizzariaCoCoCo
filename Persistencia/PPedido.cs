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
    public class PPedido
    {
        private string arquivo = "pedidos.xml";
        public List<MPedido> Abrir()
        {
            List<MPedido> listaDePedidos;
            XmlSerializer x = new XmlSerializer(typeof(List<MPedido>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDePedidos = (List<MPedido>)x.Deserialize(f);
            }
            catch
            {
                listaDePedidos = new List<MPedido>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return listaDePedidos;
        }

        public void Salvar(List<MPedido> listaDePedidos)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<MPedido>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDePedidos);
            f.Close();
        }

        public int TamanhoListaPedidos()
        {
            List<MPedido> listaDePedidos = Abrir();

            return listaDePedidos.Count;
        }
    }
}
