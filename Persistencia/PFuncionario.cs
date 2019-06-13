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
        private string arquivo = "funcionarios.xml";
        public List<MFuncionario> Abrir()
        {
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

        public void Salvar(List<MFuncionario> listaDeFunciorios)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<MFuncionario>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, listaDeFunciorios);
            f.Close();
        }
    }
}
