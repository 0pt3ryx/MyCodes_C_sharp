using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Forest_Keeper
{
    public class TreeNodeXML : TreeNode
    {
        private XmlNode xmlNode;

        public TreeNodeXML(String name, XmlNode xmlNode) : base(name)
        {
            this.xmlNode = xmlNode;
        }
        
        public void AddNode(String name, XmlNode xmlNode)
        {
            base.Nodes.Add(name, name);
            this.xmlNode = xmlNode;
            base.Tag = null;
        }
        
        public XmlNode GetXmlNodes() { return this.xmlNode; }
    }
}
