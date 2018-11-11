using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp7
{
    //https://coursehunters.net/course/master-klass-po-laravel
    class XmlReader
    {
        XmlDocument xDoc;

        public String searchByIndex(string str)
        {
            string result = "";

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.FirstChild.Name == "Index")
                {
                    XmlNode attr = null;
                    try
                    {
                        attr = xnode.FirstChild.Attributes.GetNamedItem("value");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (attr != null)
                    {
                        if (attr.Value == str)
                        {
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name != "Index")
                                {
                                    if (childnode.Name == "Street")
                                    {
                                        result += childnode.Attributes.GetNamedItem("br").Value + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }

                }
            }

            if(result == "")
            {
                result = "НЕ найдено";
            }

            return result;
        }
        public XmlReader()
        {
           
            xDoc = new XmlDocument();
            xDoc.Load("../../XMLFile1.xml");

        
        }
    }
}
