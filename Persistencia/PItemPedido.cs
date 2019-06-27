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
    public class PItemPedido
    {
        private string arquivo = "pedidospizza.xml";
        public List<MItemPedido> Abrir()
        {
            List<MItemPedido> listaDePedidosPizza;
            XmlSerializer x = new XmlSerializer(typeof(List<MItemPedido>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDePedidosPizza = (List<MItemPedido>)x.Deserialize(f);
            }
            catch
            {
                listaDePedidosPizza = new List<MItemPedido>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return listaDePedidosPizza;
        }

        public void Salvar(List<MItemPedido> listaDeItensPedidos)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<MItemPedido>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDeItensPedidos);
            f.Close();
        }
    }
}
