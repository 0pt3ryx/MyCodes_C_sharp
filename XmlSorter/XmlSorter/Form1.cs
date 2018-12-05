using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace XmlSorter
{
    public partial class Form1 : Form
    {
        // private String path = "D:\\tasks\\Projects\\LIG-CTI (2018년 5월_)\\crawler\\Directory_structure_202.xml";
        private String path = "";
        // private String newPath = "D:\\tasks\\Projects\\LIG-CTI (2018년 5월_)\\crawler\\DS_202_new.xml";
        private String newPath = "";
        private XmlDocument oldXmlDoc;
        private XmlDocument newXmlDoc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Parse_Deeper(XmlNode oldRoot, XmlElement newRoot)
        {
            List<XmlNode> dirList = new List<XmlNode>();
            List<XmlNode> fileList = new List<XmlNode>();

            foreach(XmlNode oldChild in oldRoot.ChildNodes)
            {
                if (oldChild.Name == "directory")
                    dirList.Add(oldChild);
                else if (oldChild.Name == "file")
                    fileList.Add(oldChild);
                else
                    Console.WriteLine("Warning");
            }

            dirList.Sort(delegate (XmlNode node1, XmlNode node2)
            {
                return node1.Attributes["name"].Value.CompareTo(node2.Attributes["name"].Value);
            });
            fileList.Sort(delegate (XmlNode node1, XmlNode node2)
            {
                return node1.Attributes["name"].Value.CompareTo(node2.Attributes["name"].Value);
            });
            
            foreach(XmlNode oldChild in dirList)
            {
                XmlElement newChild = this.newXmlDoc.CreateElement(oldChild.Name);
                newChild.SetAttribute("name", oldChild.Attributes["name"].Value);
                newRoot.AppendChild(newChild);

                Parse_Deeper(oldChild, newChild);

                if (!newChild.HasChildNodes)
                    newChild.SetAttribute("empty", "t");
            }
            foreach(XmlNode oldChild in fileList)
            {
                XmlElement newChild = this.newXmlDoc.CreateElement(oldChild.Name);
                newChild.SetAttribute("name", oldChild.Attributes["name"].Value);

                String size = null;
                String m_time = null;
                String ext = null;
                /*
                if (oldChild.Attributes["name"].Value == "0978d5d48ac81b059a693f09a13f2621a41fc0842beacf2b7ac87fe060c3e308" && oldRoot.Attributes["name"].Value == "add_malware_sample")
                {
                    Console.WriteLine(oldRoot.ParentNode.Attributes["name"].Value);
                    Console.WriteLine(oldRoot.Attributes["name"].Value);
                    Console.WriteLine(oldChild.Attributes["name"].Value);
                    size = "349872";
                    m_time = "1371132286";
                    ext = "";
                }
                else if(oldChild.Attributes["name"].Value == "systeminfo.jpg.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.asp")
                {
                    Console.WriteLine(oldRoot.ParentNode.Attributes["name"].Value);
                    Console.WriteLine(oldRoot.Attributes["name"].Value);
                    Console.WriteLine(oldChild.Attributes["name"].Value);
                    size = "29355";
                    m_time = "1308043716";
                    ext = "asp";
                }
                else
                {
                    try
                    {
                        size = oldChild.SelectSingleNode("./size").InnerText;
                        m_time = oldChild.SelectSingleNode("./m_time").InnerText;
                        ext = oldChild.SelectSingleNode("./ext").InnerText;
                    }
                    catch(Exception)
                    {
                        Console.WriteLine(oldChild.Attributes["name"].Value);
                        throw;
                    }
                }
                */

                try
                {
                    size = oldChild.SelectSingleNode("./size").InnerText;
                    m_time = oldChild.SelectSingleNode("./m_time").InnerText;
                    ext = oldChild.SelectSingleNode("./ext").InnerText;
                }
                catch(Exception ex)
                {
                    if(oldChild.Attributes["name"].Value.IndexOf("Romantic") != -1)
                    {
                        Console.WriteLine("romantic");
                        size = "5418";
                        m_time = "1487653032";
                        ext = "jpg";
                    }
                    else
                    {
                        if(oldChild.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Attributes["name"].Value == "23174457")
                        {
                            
                            Console.WriteLine("hi");
                            size = "5324";
                            m_time = "1487656230";
                            ext = "jpg";
                        }
                        else if(oldChild.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Attributes["name"].Value == "23277974")
                        {
                            Console.WriteLine("hey");
                            size = "5324";
                            m_time = "1487658031";
                            ext = "jpg";
                        }
                    }
                }

                XmlElement newGrandChild1 = this.newXmlDoc.CreateElement("size");
                newGrandChild1.InnerText = size;
                XmlElement newGrandChild2 = this.newXmlDoc.CreateElement("m_time");
                newGrandChild2.InnerText = m_time;
                XmlElement newGrandChild3 = this.newXmlDoc.CreateElement("ext");
                newGrandChild3.InnerText = ext;

                newChild.AppendChild(newGrandChild1);
                newChild.AppendChild(newGrandChild2);
                newChild.AppendChild(newGrandChild3);

                newRoot.AppendChild(newChild);
                /*
                if (oldChild.Attributes["name"].Value == "systeminfo" && oldRoot.Attributes["name"].Value == "webshell")
                {
                    Console.WriteLine(oldChild.Attributes["name"].Value);
                    XmlElement tmpEle = this.newXmlDoc.CreateElement("file");
                    tmpEle.SetAttribute("name", "systeminfo.jpg.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.a.asp");
                    XmlElement tmpGrandEle1 = this.newXmlDoc.CreateElement("size");
                    tmpGrandEle1.InnerText = "29355";
                    XmlElement tmpGrandEle2 = this.newXmlDoc.CreateElement("m_time");
                    tmpGrandEle2.InnerText = "1371132286";
                    XmlElement tmpGrandEle3 = this.newXmlDoc.CreateElement("ext");
                    tmpGrandEle3.InnerText = "asp";

                    tmpEle.AppendChild(tmpGrandEle1);
                    tmpEle.AppendChild(tmpGrandEle2);
                    tmpEle.AppendChild(tmpGrandEle3);

                    newRoot.AppendChild(tmpEle);
                }
                */
            }
        }

        private void Parse_Xml()
        {
            this.oldXmlDoc = new XmlDocument();
            this.oldXmlDoc.Load(this.path);
            this.newXmlDoc = new XmlDocument();
            
            XmlNode oldRootXmlNode = this.oldXmlDoc.SelectSingleNode("/root");
            XmlElement newRootXmlNode = this.newXmlDoc.CreateElement(oldRootXmlNode.Name);
            newRootXmlNode.SetAttribute("path", oldRootXmlNode.Attributes["path"].Value);
            this.newXmlDoc.AppendChild(newRootXmlNode);

            Parse_Deeper(oldRootXmlNode, newRootXmlNode);
            this.newXmlDoc.Save(this.newPath);
            Console.WriteLine("Completed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parse_Xml();
        }
    }
}
