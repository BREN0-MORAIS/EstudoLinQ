
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AluraTunes.Data
{
    class AcessandoXML
    {
        public void XML()
        {
            XElement root = XElement.Load(@"C:\DESENVOLVEDOR\CÓDIGO FONTE\EstudosLinQ\EstudoLinQ\AluraTunes\AluraTunes\AluraTunes\Data\AluraDados.xml");

            var queryXML =
                  from c in root.Element("contatos").Elements("contato")
                  select c;

            foreach (var genero in queryXML)
            {
                Console.WriteLine(genero.Element("name").Value + "" + genero.Element("company").Value);
            }

            Console.ReadLine();
        }
    }
}
