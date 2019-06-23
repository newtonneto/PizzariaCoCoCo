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
    public class PPizza
    {
        private string arquivo = "pizzas.xml";
        public List<MPizza> Abrir()
        {
            List<MPizza> listaDePizzas;
            XmlSerializer x = new XmlSerializer(typeof(List<MPizza>));
            StreamReader f = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                listaDePizzas = (List<MPizza>)x.Deserialize(f);
            }
            catch
            {
                listaDePizzas = new List<MPizza>();
            }
            finally
            {
                if (f != null) f.Close();
            }

            return listaDePizzas;
        }

        public void Salvar(List<MPizza> listaDePizzas)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<MPizza>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDePizzas);
            f.Close();
        }
    }
}
