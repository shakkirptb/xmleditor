using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace FO_Telekurs_Feed_Editer
{
    public partial class FormMain : Form
    {
        MyTreeNode root = new MyTreeNode();
        MyTreeNode seletedNode = null;
        bool ITEMSChanged = false,loading=true;
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listAttrib.Columns.Clear();
            listAttrib.Columns.Add("Attribute",100);
            listAttrib.Columns.Add("Value", 150);
            listAttrib.Columns.Add("New Value", 130);
            //listAttrib.Columns[0].DisplayIndex = 1;

            //load settings app.config
            LoadAppConfig();
            if (!loadItemsXML()) showErrorMessage("Loading ItemsXML Failed!");
            loading = false;

            //load last used  out file
            if (loadOutPutTree())
            {
                string[] outfilesegments = TextOutFile.Text.Split('\\');

                File.Copy(TextOutFile.Text, Application.StartupPath + "\\Backup_" + outfilesegments[outfilesegments.Length - 1],true);
                showInfoMessage("A backup of the File loaded has been kept in the application path.");
            }

        }
        private void LoadAppConfig()
        {
            try
            {
                TextISINsXML.Text = AppConfig.getAppConfig("ITEMSXML", "path");
                TextOutFile.Text = AppConfig.getAppConfig("OUTPUT", "path");
                checkParent.Checked = AppConfig.getAppConfig("delete_parent_node", "checkbox").ToUpper().Equals("TRUE") ? true : false;
                checkOnlyFirst.Checked = AppConfig.getAppConfig("apply_only_on_first_match", "checkbox").ToUpper().Equals("TRUE") ? true : false;
            }
            catch (Exception err)
            {
                showErrorMessage(err.Message);
            }
        }

 

        private void BtnRunDelete_Click(object sender, EventArgs e)
        {
            //MyTreeNode 
            XElement element;//,appSettings;
            if(listAttrib.SelectedItems.Count!=1)
            {
                showInfoMessage("Error: No items/more than one item selected");
                return;
            }
            string selectedAttrib=listAttrib.SelectedItems[0].SubItems[0].Text;
            try
            {
                element = XElement.Load(TextOutFile.Text);
                XNamespace Xns = element.Name.Namespace;
                int foundCount = 0;
                List<XElement> itemsToBeRemoved = new List<XElement>();
                foreach (string item in ListItems.CheckedItems)
                {
                    foreach (XElement xItem in element.Descendants(seletedNode.xElement.Name.ToString()))
                    {
                        XElement xItemToBeRemoved = checkParent.Checked ? xItem.Parent : xItem;

                        if (selectedAttrib.ToLower().Equals("<content>"))
                        {
                            if (xItem.Value.ToUpper().Equals(item.ToUpper()))
                            {
                                itemsToBeRemoved.Add(xItemToBeRemoved);
                                if (checkOnlyFirst.Checked) break;
                                /* xItem.Parent.Remove();
                                foundCount++;
                                break;*/
                            }
                        }
                        else if(xItem.Attribute(Xns+selectedAttrib)!=null && xItem.Attribute(Xns+selectedAttrib).Value.ToUpper().Equals(item.ToUpper()))
                        {
                            itemsToBeRemoved.Add(xItemToBeRemoved);
                            if (checkOnlyFirst.Checked) break;
                           /* xItem.Parent.Remove();
                            foundCount++;
                            break;*/
                        }
                    }
                }
                foundCount = itemsToBeRemoved.Count;
                foreach (XElement xItem in itemsToBeRemoved)
                {
                    xItem.Remove();
                }

                element.Save(TextOutFile.Text);
                showSuccessMessage(foundCount + " itemn(s)Removed");
                
                loadOutPutTree();
            }
            catch (Exception err)
            {
                
                //Console.WriteLine(err.Message);
                showErrorMessage(err.Message);
            }
        }

        private void BtnBrowseIn_Click(object sender, EventArgs e)
        {
            openDialog1.Filter = "XML Files(Config, xml)|*.config;*.xml|All Files|*.*";
            //if(
            if (openDialog1.ShowDialog() != DialogResult.Cancel)
            {
                TextISINsXML.Text = openDialog1.FileName;
                loadItemsXML();
            }
        }
        private bool loadItemsXML()
        {
            XElement element;
            try
            {
                element = XElement.Load(TextISINsXML.Text);
                ListItems.Items.Clear();
                foreach (XElement item in element.Elements())
                {
                    if(item.Attribute("checked")!=null)
                    ListItems.Items.Add(item.Value,"TRUE".Equals(item.Attribute("checked").Value.ToUpper()));
                }
                return true;
            }
            catch (Exception err)
            {
                showErrorMessage(err.Message);
                return false;
            }
        }

        private void BtnBrowseOut_Click(object sender, EventArgs e)
        {
            openDialog1.Filter = "XML Files(Config, xml)|*.config;*.xml|All Files|*.*";
            if (openDialog1.ShowDialog() != DialogResult.Cancel)
            {

                try
                {
                    TextOutFile.Text = openDialog1.FileName;
                    if (loadOutPutTree())
                    {
                        string[] outfilesegments =TextOutFile.Text.Split('\\');

                        File.Copy(TextOutFile.Text, Application.StartupPath + "Backup_"+outfilesegments[outfilesegments.Length-1]);
                        showInfoMessage("A backup of the File loaded has been kept in the application path.");
                    }
                }
                catch (Exception)
                {                    }
            }


        }
        private bool loadOutPutTree()
        {
            textAttribName.Text = "";
            textAttribVal.Text = "";
            textNS.Text = "";
            XElement element;
            try
            {
                element = XElement.Load(TextOutFile.Text);
                textNS.Text = element.Name.Namespace.ToString();
                //XNamespace Xns=element.getna
                treeOutXML.Nodes.Clear();
                root = new MyTreeNode(element.Name.LocalName.ToString(),element);
                getInnerNode(root,element);
                treeOutXML.Nodes.Add(root);
                root.Expand();
                return true;
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message);
                showErrorMessage(err.Message);
                return false;
            }
        }
        private void getInnerNode(MyTreeNode root,XElement element)
        {
            MyTreeNode node;
            foreach (XElement item in element.Elements())
            {
//                ListItems.Items.Add(item.Value, "TRUE".Equals(item.Attribute("checked").Value.ToUpper()));
                node = new MyTreeNode(item.Name.LocalName.ToString(),item);
                root.Nodes.Add(node);
                getInnerNode(node,item);
                
            }
        }
    
        private bool addToISINxml(string isin)
        {
            XElement element;
            try
            {
                element = XElement.Load(TextISINsXML.Text);
                //XElement newItem = new XElement("isin", new XAttribute("checked", "true")).Value = "isin";
                element.Add(new XElement("isin", new XAttribute("checked", "true")).Value = "isin");
                element.Save(TextISINsXML.Text);
                return true;
            }
            catch(Exception err)
            {
                showErrorMessage(err.Message);
                return false;
            }
        }
        private  bool removeFromISINxml(string isin)
        {
            XElement element;
            try
            {
                element = XElement.Load(TextISINsXML.Text);
                foreach (XElement x in element.Elements())
                {
                    if (x.Value.ToUpper().Equals(isin.ToUpper()))
                    {
                        x.Remove();
                        break;
                    }
                }
                element.Save(TextISINsXML.Text);
                return true;
            }
            catch (Exception err)
            {
                showErrorMessage(err.Message);
                return false;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save input and output paths
            AppConfig.setAppConfig("ITEMSXML", TextISINsXML.Text, "path");
            AppConfig.setAppConfig("OUTPUT", TextOutFile.Text, "path");
            AppConfig.setAppConfig("delete_parent_node", checkParent.Checked.ToString(), "checkbox");
            AppConfig.setAppConfig("apply_only_on_first_match", checkOnlyFirst.Checked.ToString(), "checkbox");
            

            //prompt to save save changes
            if (ITEMSChanged)
            {
                switch (MessageBox.Show("Save changes made to ISINs list?", "save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        saveISINSXML();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
        private bool saveISINSXML()
        {
            XElement element=new XElement("items");
            try
            {
                for (int i = 0; i < ListItems.Items.Count; i++)
                {
                    XElement subelement=new XElement("item", new XAttribute("checked", ListItems.GetItemChecked(i).ToString()));
                    subelement.SetValue(ListItems.Items[i].ToString());
                    element.Add(subelement);
                }
                element.Save(TextISINsXML.Text);
                return true;
            }
            catch (Exception err)
            {
                showErrorMessage(err.Message);
                return false;
            }
        }

        private void BtnISINAdd_Click(object sender, EventArgs e)
        {
            ITEMSChanged = true;
            //if(addToISINxml(textISIN.Text))
                ListItems.Items.Add(textISIN.Text, true);

        }

        private void BtnISINRemove_Click(object sender, EventArgs e)
        {
            if (ListItems.CheckedItems.Count > 0 && MessageBox.Show("Do you want to remove selected items?", "Remove", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ITEMSChanged = true;
                List<string> arr = new List<string>();
                
                foreach (string item in ListItems.CheckedItems)
                    arr.Add(item);
                foreach (string item in arr)
                    ListItems.Items.Remove(item);
            }
        }

        private void ListISINs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(!loading)
            ITEMSChanged = true;

        }

        private void btnISINsSave_Click(object sender, EventArgs e)
        {
            if (ITEMSChanged)
            {
                if (MessageBox.Show("Save changes made to input list?", "save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                && saveISINSXML())
                {
                    ITEMSChanged = false;
                    MessageBox.Show("Changes saved", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else showErrorMessage("something went wrong!");
            }
        }

        private void BtnISINsReload_Click(object sender, EventArgs e)
        {
            loadItemsXML();
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ListItems.Items.Count; i++)
                ListItems.SetItemChecked(i, checkAll.Checked);

        }
        private void loadAttrib(MyTreeNode node)
        {
            MyTreeNode selectedNode = node;
            ListViewItem item = null;
            listAttrib.Items.Clear();
            //adding contentenclosed by node
            if (!selectedNode.xElement.HasElements)
            {
                string[] row1 ={ "<Content>", selectedNode.xElement.Value,"" };
                item = new ListViewItem(row1);
                listAttrib.Items.Add(item);
            }
            //adding attributes
            foreach (XAttribute attrib in selectedNode.xElement.Attributes())
            {
                string[] row = { attrib.Name.LocalName.ToString(),attrib.Value,""};
                item = new ListViewItem(row);
                listAttrib.Items.Add(item);
            }
        }
        private void BtnAttribAdd_Click(object sender, EventArgs e)
        {
            //if(listAttrib.SelectedItems.Count==0)
            
            try
            {
                if(textAttribName.Text.Equals("")){MessageBox.Show("Ënter Attribute Name!");return;}
                XNamespace Xns = seletedNode.xElement.Name.Namespace;
                if (textAttribName.Text.ToLower().Equals("<content>"))
                {
                    if (MessageBox.Show("Do you want to Edit the Content of selected node?", "Edit Content", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        seletedNode.xElement.SetValue(textAttribVal.Text);
                        root.xElement.Save(TextOutFile.Text);
                        loadAttrib(seletedNode);
                        showSuccessMessage("Content had been changed...");
                        listAttrib.Focus();
                    }
                }

                if (MessageBox.Show("Do you want Add new Attribute?", "Add Attribtue", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    seletedNode.xElement.Add(new XAttribute(Xns + textAttribName.Text, textAttribVal.Text));
                    root.xElement.Save(TextOutFile.Text);
                    loadAttrib(seletedNode);
                    showSuccessMessage("new Attribute Added.");
                    listAttrib.Focus();
                }
                //MessageBox.Show("Sucessful...", "Add Attribute");
                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
  
            }
        }
        private string InputBox(string Title, string Prompt, string Default,int XPos, int YPos)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(Title, Prompt,Default,XPos,YPos);
        }

        private void BtnAttribRemove_Click(object sender, EventArgs e)
        {
            MyTreeNode node = seletedNode;
            XNamespace Xns = node.xElement.Name.Namespace;

            try
            {
                if (listAttrib.SelectedItems.Count > 0 && node != null && MessageBox.Show("Do you want to remove selected Attribute(s)/Content?", "Remove", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listAttrib.SelectedItems)
                    {
                        if (item.SubItems[0].Text.ToLower().Equals("<content>"))
                        {
                            seletedNode.xElement.SetValue("");
                        }
                        else if (node.xElement.Attribute(Xns + item.SubItems[0].Text)!=null)
                            node.xElement.Attribute(Xns + item.SubItems[0].Text).Remove();//RemoveAttributes[item.Index]();

                    }
                    root.xElement.Save(TextOutFile.Text);
                    //MessageBox.Show("Removed", "Remove Attribute(s)");
                    showSuccessMessage(listAttrib.SelectedItems.Count + " Item(s) Removed.");
                    loadAttrib(node);
                    listAttrib.Focus();

                }
            }
            catch (Exception err)
            {
                showErrorMessage(err.Message);
                
            }

        }

        private void treeOutXML_AfterSelect(object sender, TreeViewEventArgs e)
        {
            seletedNode = (MyTreeNode)e.Node;
            loadAttrib(seletedNode);
            XNamespace xns = seletedNode.xElement.Name.Namespace;
            textNS.Text = seletedNode.xElement.Name.Namespace.ToString();
            textAttribName.Text = "";
            textAttribVal.Text = "";
        }

        private void BtnAttribEdit_Click(object sender, EventArgs e)
        {
            MyTreeNode node = seletedNode;
            XNamespace Xns = node.xElement.Name.Namespace;
            List<ListViewItem> ListSelected =new List<ListViewItem>();
            foreach (ListViewItem item in listAttrib.SelectedItems)
            {
                ListSelected.Add(item);
            }
            try
            {
                if (ListSelected.Count > 0 && node != null && MessageBox.Show("Do you want to edit selected Attribute(s)/Content?", "Remove", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in ListSelected)
                    {
                        if (item.SubItems[0].Text.ToLower().Equals("<content>"))
                        {
                            seletedNode.xElement.SetValue(textAttribVal.Text);
                            //item.SubItems[2].Text = textSearch.Text;
                        }
                        else
                        {
                            if (node.xElement.Attribute(Xns+item.SubItems[0].Text)!=null && ListSelected.Count == 1 && !item.SubItems[0].Text.Equals(textAttribName.Text))
                            {
                                node.xElement.Attribute(Xns+item.SubItems[0].Text).Remove();
                                node.xElement.Add(new XAttribute(Xns+textAttribName.Text, ""));
                            }
                            node.xElement.SetAttributeValue(Xns + textAttribName.Text, textAttribVal.Text);
                        }
                    }
                    root.xElement.Save(TextOutFile.Text);
                    //MessageBox.Show("Sucessful...", "Edit Attribute(s)");
                    showSuccessMessage(ListSelected.Count + " Item(s) Edited.");
                    loadAttrib(node);
                    listAttrib.Focus();
                }
            }
            catch (Exception err)
            {
                showErrorMessage(err.Message);

            }
            }

        private void listAttrib_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listAttrib.SelectedItems.Count == 1)
            {
                
                //textNS.Text = seletedNode.xElement.Attribute(xns + e.Item.SubItems[0].Text).Name.Namespace.ToString();
                textAttribName.Text = e.Item.SubItems[0].Text;
                textAttribVal.Text = e.Item.SubItems[1].Text;

                try
                {
                    textNewVal.Text = e.Item.SubItems[2].Text;
                }
                catch (Exception){}
            }
        }
     private void lblMessage_TextChanged(object sender, EventArgs e)
        {

        }
        private void messagetimer1_Tick(object sender, EventArgs e)
        {
            messagetimer1.Stop();
            lblMessage.Visible = false;
            //lblMessage.Text = ""; 
        }

   

        private void lblMessage_Click(object sender, EventArgs e)
        {
            lblMessage.BackColor = Color.FromArgb(220, 200, 70);
            lblMessage.Visible = false;
            listAttrib.Focus();
        }
        private void showSuccessMessage(string message)
        {
            lblMessage.BackColor = Color.FromArgb(100, 200, 100);
            lblMessage.Text = message;
                lblMessage.Visible = true;
                messagetimer1.Start();
        }
        private void showErrorMessage(string message)
        {
            lblMessage.BackColor = Color.FromArgb(200, 100, 100);
            lblMessage.Text = message;
            lblMessage.Visible = true;
            messagetimer1.Start();
        }
        private void showInfoMessage(string message)
        {
            lblMessage.BackColor = Color.FromArgb(100, 200, 100);
            lblMessage.Text = message;
            lblMessage.Visible = true;
            messagetimer1.Start();
        }

        private void BtnSetNewVal_Click(object sender, EventArgs e)
        {
            if (listAttrib.SelectedItems.Count == 1)
            {
                listAttrib.SelectedItems[0].SubItems[2].Text = textNewVal.Text;
            }
        }

        private void BtnRunEdit_Click(object sender, EventArgs e)
        {
            //MyTreeNode 
            XElement element;//,appSettings;
            if (listAttrib.SelectedItems.Count != 1)
            {
                showInfoMessage("Error: No attributes/more than one Attribute selected for comparing");
                return;
            }
            if (listAttrib.CheckedItems.Count == 0)
            {
                showInfoMessage("Error: No Attributes are 'checked' for editing");
                return;
            }
            string selectedAttrib = listAttrib.SelectedItems[0].SubItems[0].Text;
            try
            {
            element = XElement.Load(TextOutFile.Text);
            XNamespace Xns = element.Name.Namespace;
            int foundCount = 0;
            foreach (string item in ListItems.CheckedItems)
            {
                foreach (XElement xItem in element.Descendants(seletedNode.xElement.Name.ToString()))
                {
                    if (selectedAttrib.ToLower().Equals("<content>"))
                    {
                        if (xItem.Value.ToUpper().Equals(item.ToUpper()))
                        {
                            foreach (ListViewItem listRow in listAttrib.CheckedItems)
                            {
                                xItem.SetValue(listRow.SubItems[2].Text);
                                foundCount++;
                            }
                            if(checkOnlyFirst.Checked)break;//not required since we are not removing item
                        }
                    }
                    else if (xItem.Attribute(Xns + selectedAttrib)!=null && xItem.Attribute(Xns + selectedAttrib).Value.ToUpper().Equals(item.ToUpper()))
                    {
                        foreach (ListViewItem listRow in listAttrib.CheckedItems)
                        {
                            xItem.SetAttributeValue(Xns + listRow.SubItems[0].Text, listRow.SubItems[2].Text);
                            foundCount++;
                        }
                        if (checkOnlyFirst.Checked) break;//not required since we are not removing item
                    }
                }
            }
            element.Save(TextOutFile.Text);
            showSuccessMessage(foundCount + " itemn(s)Editted");

            loadOutPutTree();
            }
            catch (Exception err)
            {
                
                //Console.WriteLine(err.Message);
                showErrorMessage(err.Message);
            }
        }

    }
}