using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
namespace FO_Telekurs_Feed_Editer
{
    public class MyTreeNode: TreeNode
    {
        public XElement xElement;

        public MyTreeNode(String text): base(text)
        {
              
        }
        public MyTreeNode(XElement xelement): base()
        {
            this.xElement = xelement;
        }
        public MyTreeNode(String text,XElement xelement):base(text)
        {
            this.xElement = xelement;
        }
        public MyTreeNode(): base() {}
    }
}
