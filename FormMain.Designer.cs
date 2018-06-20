namespace FO_Telekurs_Feed_Editer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnRunDelete = new System.Windows.Forms.Button();
            this.TextOutFile = new System.Windows.Forms.TextBox();
            this.BtnBrowseOut = new System.Windows.Forms.Button();
            this.ListItems = new System.Windows.Forms.CheckedListBox();
            this.BtnBrowseIn = new System.Windows.Forms.Button();
            this.TextISINsXML = new System.Windows.Forms.TextBox();
            this.openDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnISINAdd = new System.Windows.Forms.Button();
            this.BtnISINRemove = new System.Windows.Forms.Button();
            this.textISIN = new System.Windows.Forms.TextBox();
            this.btnISINsSave = new System.Windows.Forms.Button();
            this.BtnISINsReload = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeOutXML = new System.Windows.Forms.TreeView();
            this.listAttrib = new System.Windows.Forms.ListView();
            this.BtnAttribRemove = new System.Windows.Forms.Button();
            this.BtnAttribAdd = new System.Windows.Forms.Button();
            this.BtnAttribEdit = new System.Windows.Forms.Button();
            this.textAttribName = new System.Windows.Forms.TextBox();
            this.textAttribVal = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.messagetimer1 = new System.Windows.Forms.Timer(this.components);
            this.textNS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkParent = new System.Windows.Forms.CheckBox();
            this.textNewVal = new System.Windows.Forms.TextBox();
            this.BtnSetNewVal = new System.Windows.Forms.Button();
            this.BtnRunEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkOnlyFirst = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRunDelete
            // 
            this.BtnRunDelete.Location = new System.Drawing.Point(801, 388);
            this.BtnRunDelete.Name = "BtnRunDelete";
            this.BtnRunDelete.Size = new System.Drawing.Size(73, 34);
            this.BtnRunDelete.TabIndex = 0;
            this.BtnRunDelete.Text = "Delete Matches";
            this.BtnRunDelete.UseVisualStyleBackColor = true;
            this.BtnRunDelete.Click += new System.EventHandler(this.BtnRunDelete_Click);
            // 
            // TextOutFile
            // 
            this.TextOutFile.Location = new System.Drawing.Point(27, 51);
            this.TextOutFile.Name = "TextOutFile";
            this.TextOutFile.Size = new System.Drawing.Size(256, 20);
            this.TextOutFile.TabIndex = 1;
            // 
            // BtnBrowseOut
            // 
            this.BtnBrowseOut.Location = new System.Drawing.Point(289, 47);
            this.BtnBrowseOut.Name = "BtnBrowseOut";
            this.BtnBrowseOut.Size = new System.Drawing.Size(67, 26);
            this.BtnBrowseOut.TabIndex = 2;
            this.BtnBrowseOut.Text = "Browse";
            this.BtnBrowseOut.UseVisualStyleBackColor = true;
            this.BtnBrowseOut.Click += new System.EventHandler(this.BtnBrowseOut_Click);
            // 
            // ListItems
            // 
            this.ListItems.CheckOnClick = true;
            this.ListItems.FormattingEnabled = true;
            this.ListItems.Location = new System.Drawing.Point(13, 52);
            this.ListItems.Name = "ListItems";
            this.ListItems.Size = new System.Drawing.Size(146, 169);
            this.ListItems.TabIndex = 4;
            this.ListItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListISINs_ItemCheck);
            // 
            // BtnBrowseIn
            // 
            this.BtnBrowseIn.Location = new System.Drawing.Point(627, 47);
            this.BtnBrowseIn.Name = "BtnBrowseIn";
            this.BtnBrowseIn.Size = new System.Drawing.Size(67, 26);
            this.BtnBrowseIn.TabIndex = 6;
            this.BtnBrowseIn.Text = "Browse";
            this.BtnBrowseIn.UseVisualStyleBackColor = true;
            this.BtnBrowseIn.Click += new System.EventHandler(this.BtnBrowseIn_Click);
            // 
            // TextISINsXML
            // 
            this.TextISINsXML.Location = new System.Drawing.Point(364, 51);
            this.TextISINsXML.Name = "TextISINsXML";
            this.TextISINsXML.Size = new System.Drawing.Size(256, 20);
            this.TextISINsXML.TabIndex = 5;
            // 
            // openDialog1
            // 
            this.openDialog1.FileName = "openFileDialog1";
            // 
            // BtnISINAdd
            // 
            this.BtnISINAdd.Location = new System.Drawing.Point(13, 30);
            this.BtnISINAdd.Name = "BtnISINAdd";
            this.BtnISINAdd.Size = new System.Drawing.Size(71, 21);
            this.BtnISINAdd.TabIndex = 7;
            this.BtnISINAdd.Text = "Add";
            this.BtnISINAdd.UseVisualStyleBackColor = true;
            this.BtnISINAdd.Click += new System.EventHandler(this.BtnISINAdd_Click);
            // 
            // BtnISINRemove
            // 
            this.BtnISINRemove.Location = new System.Drawing.Point(88, 30);
            this.BtnISINRemove.Name = "BtnISINRemove";
            this.BtnISINRemove.Size = new System.Drawing.Size(71, 21);
            this.BtnISINRemove.TabIndex = 8;
            this.BtnISINRemove.Text = "Remove";
            this.BtnISINRemove.UseVisualStyleBackColor = true;
            this.BtnISINRemove.Click += new System.EventHandler(this.BtnISINRemove_Click);
            // 
            // textISIN
            // 
            this.textISIN.Location = new System.Drawing.Point(13, 11);
            this.textISIN.Name = "textISIN";
            this.textISIN.Size = new System.Drawing.Size(146, 20);
            this.textISIN.TabIndex = 9;
            // 
            // btnISINsSave
            // 
            this.btnISINsSave.Location = new System.Drawing.Point(108, 229);
            this.btnISINsSave.Name = "btnISINsSave";
            this.btnISINsSave.Size = new System.Drawing.Size(51, 21);
            this.btnISINsSave.TabIndex = 10;
            this.btnISINsSave.Text = "Save";
            this.btnISINsSave.UseVisualStyleBackColor = true;
            this.btnISINsSave.Click += new System.EventHandler(this.btnISINsSave_Click);
            // 
            // BtnISINsReload
            // 
            this.BtnISINsReload.Location = new System.Drawing.Point(51, 229);
            this.BtnISINsReload.Name = "BtnISINsReload";
            this.BtnISINsReload.Size = new System.Drawing.Size(51, 21);
            this.BtnISINsReload.TabIndex = 11;
            this.BtnISINsReload.Text = "Reload";
            this.BtnISINsReload.UseVisualStyleBackColor = true;
            this.BtnISINsReload.Click += new System.EventHandler(this.BtnISINsReload_Click);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(14, 232);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(37, 17);
            this.checkAll.TabIndex = 12;
            this.checkAll.Text = "All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "XML file in which items to be compared are listed :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "File To be editted (XML formated)";
            // 
            // treeOutXML
            // 
            this.treeOutXML.Location = new System.Drawing.Point(15, 27);
            this.treeOutXML.Name = "treeOutXML";
            this.treeOutXML.Size = new System.Drawing.Size(269, 269);
            this.treeOutXML.TabIndex = 15;
            this.treeOutXML.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOutXML_AfterSelect);
            // 
            // listAttrib
            // 
            this.listAttrib.CheckBoxes = true;
            this.listAttrib.FullRowSelect = true;
            this.listAttrib.GridLines = true;
            this.listAttrib.Location = new System.Drawing.Point(296, 47);
            this.listAttrib.Name = "listAttrib";
            this.listAttrib.Size = new System.Drawing.Size(384, 190);
            this.listAttrib.TabIndex = 16;
            this.listAttrib.UseCompatibleStateImageBehavior = false;
            this.listAttrib.View = System.Windows.Forms.View.Details;
            this.listAttrib.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listAttrib_ItemSelectionChanged);
            // 
            // BtnAttribRemove
            // 
            this.BtnAttribRemove.Location = new System.Drawing.Point(374, 269);
            this.BtnAttribRemove.Name = "BtnAttribRemove";
            this.BtnAttribRemove.Size = new System.Drawing.Size(72, 21);
            this.BtnAttribRemove.TabIndex = 18;
            this.BtnAttribRemove.Text = "Remove";
            this.BtnAttribRemove.UseVisualStyleBackColor = true;
            this.BtnAttribRemove.Click += new System.EventHandler(this.BtnAttribRemove_Click);
            // 
            // BtnAttribAdd
            // 
            this.BtnAttribAdd.Location = new System.Drawing.Point(296, 269);
            this.BtnAttribAdd.Name = "BtnAttribAdd";
            this.BtnAttribAdd.Size = new System.Drawing.Size(72, 21);
            this.BtnAttribAdd.TabIndex = 17;
            this.BtnAttribAdd.Text = "Add";
            this.BtnAttribAdd.UseVisualStyleBackColor = true;
            this.BtnAttribAdd.Click += new System.EventHandler(this.BtnAttribAdd_Click);
            // 
            // BtnAttribEdit
            // 
            this.BtnAttribEdit.Location = new System.Drawing.Point(456, 269);
            this.BtnAttribEdit.Name = "BtnAttribEdit";
            this.BtnAttribEdit.Size = new System.Drawing.Size(72, 21);
            this.BtnAttribEdit.TabIndex = 21;
            this.BtnAttribEdit.Text = "Set";
            this.BtnAttribEdit.UseVisualStyleBackColor = true;
            this.BtnAttribEdit.Click += new System.EventHandler(this.BtnAttribEdit_Click);
            // 
            // textAttribName
            // 
            this.textAttribName.Location = new System.Drawing.Point(296, 243);
            this.textAttribName.Name = "textAttribName";
            this.textAttribName.Size = new System.Drawing.Size(91, 20);
            this.textAttribName.TabIndex = 22;
            // 
            // textAttribVal
            // 
            this.textAttribVal.Location = new System.Drawing.Point(393, 243);
            this.textAttribVal.Name = "textAttribVal";
            this.textAttribVal.Size = new System.Drawing.Size(135, 20);
            this.textAttribVal.TabIndex = 23;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(200)))), ((int)(((byte)(70)))));
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(11, 307);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(672, 30);
            this.lblMessage.TabIndex = 24;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            this.lblMessage.Enter += new System.EventHandler(this.lblMessage_Click);
            // 
            // messagetimer1
            // 
            this.messagetimer1.Interval = 5000;
            this.messagetimer1.Tick += new System.EventHandler(this.messagetimer1_Tick);
            // 
            // textNS
            // 
            this.textNS.Location = new System.Drawing.Point(369, 25);
            this.textNS.Name = "textNS";
            this.textNS.Size = new System.Drawing.Size(208, 20);
            this.textNS.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Name Space";
            // 
            // checkParent
            // 
            this.checkParent.AutoSize = true;
            this.checkParent.Checked = true;
            this.checkParent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkParent.Location = new System.Drawing.Point(722, 329);
            this.checkParent.Name = "checkParent";
            this.checkParent.Size = new System.Drawing.Size(125, 17);
            this.checkParent.TabIndex = 27;
            this.checkParent.Text = "Delete Parent Nodes";
            this.checkParent.UseVisualStyleBackColor = true;
            // 
            // textNewVal
            // 
            this.textNewVal.Location = new System.Drawing.Point(551, 243);
            this.textNewVal.Name = "textNewVal";
            this.textNewVal.Size = new System.Drawing.Size(129, 20);
            this.textNewVal.TabIndex = 29;
            // 
            // BtnSetNewVal
            // 
            this.BtnSetNewVal.Location = new System.Drawing.Point(592, 269);
            this.BtnSetNewVal.Name = "BtnSetNewVal";
            this.BtnSetNewVal.Size = new System.Drawing.Size(88, 21);
            this.BtnSetNewVal.TabIndex = 30;
            this.BtnSetNewVal.Text = "Set New";
            this.BtnSetNewVal.UseVisualStyleBackColor = true;
            this.BtnSetNewVal.Click += new System.EventHandler(this.BtnSetNewVal_Click);
            // 
            // BtnRunEdit
            // 
            this.BtnRunEdit.Location = new System.Drawing.Point(722, 388);
            this.BtnRunEdit.Name = "BtnRunEdit";
            this.BtnRunEdit.Size = new System.Drawing.Size(73, 34);
            this.BtnRunEdit.TabIndex = 31;
            this.BtnRunEdit.Text = "Edit Matches";
            this.BtnRunEdit.UseVisualStyleBackColor = true;
            this.BtnRunEdit.Click += new System.EventHandler(this.BtnRunEdit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.treeOutXML);
            this.panel1.Controls.Add(this.BtnSetNewVal);
            this.panel1.Controls.Add(this.BtnAttribAdd);
            this.panel1.Controls.Add(this.textNewVal);
            this.panel1.Controls.Add(this.BtnAttribRemove);
            this.panel1.Controls.Add(this.BtnAttribEdit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textAttribName);
            this.panel1.Controls.Add(this.textNS);
            this.panel1.Controls.Add(this.textAttribVal);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.listAttrib);
            this.panel1.Location = new System.Drawing.Point(10, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 350);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnISINAdd);
            this.panel2.Controls.Add(this.ListItems);
            this.panel2.Controls.Add(this.BtnISINRemove);
            this.panel2.Controls.Add(this.textISIN);
            this.panel2.Controls.Add(this.btnISINsSave);
            this.panel2.Controls.Add(this.BtnISINsReload);
            this.panel2.Controls.Add(this.checkAll);
            this.panel2.Location = new System.Drawing.Point(707, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 266);
            this.panel2.TabIndex = 33;
            // 
            // checkOnlyFirst
            // 
            this.checkOnlyFirst.AutoSize = true;
            this.checkOnlyFirst.Checked = true;
            this.checkOnlyFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkOnlyFirst.Location = new System.Drawing.Point(722, 355);
            this.checkOnlyFirst.Name = "checkOnlyFirst";
            this.checkOnlyFirst.Size = new System.Drawing.Size(158, 17);
            this.checkOnlyFirst.TabIndex = 34;
            this.checkOnlyFirst.Text = "Apply only on the first match";
            this.checkOnlyFirst.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 443);
            this.Controls.Add(this.checkOnlyFirst);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnRunEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkParent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBrowseIn);
            this.Controls.Add(this.TextISINsXML);
            this.Controls.Add(this.BtnBrowseOut);
            this.Controls.Add(this.TextOutFile);
            this.Controls.Add(this.BtnRunDelete);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "Feeder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRunDelete;
        private System.Windows.Forms.TextBox TextOutFile;
        private System.Windows.Forms.Button BtnBrowseOut;
        private System.Windows.Forms.CheckedListBox ListItems;
        private System.Windows.Forms.Button BtnBrowseIn;
        private System.Windows.Forms.TextBox TextISINsXML;
        private System.Windows.Forms.OpenFileDialog openDialog1;
        private System.Windows.Forms.Button BtnISINAdd;
        private System.Windows.Forms.Button BtnISINRemove;
        private System.Windows.Forms.TextBox textISIN;
        private System.Windows.Forms.Button btnISINsSave;
        private System.Windows.Forms.Button BtnISINsReload;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeOutXML;
        private System.Windows.Forms.ListView listAttrib;
        private System.Windows.Forms.Button BtnAttribRemove;
        private System.Windows.Forms.Button BtnAttribAdd;
        private System.Windows.Forms.Button BtnAttribEdit;
        private System.Windows.Forms.TextBox textAttribName;
        private System.Windows.Forms.TextBox textAttribVal;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer messagetimer1;
        private System.Windows.Forms.TextBox textNS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkParent;
        private System.Windows.Forms.TextBox textNewVal;
        private System.Windows.Forms.Button BtnSetNewVal;
        private System.Windows.Forms.Button BtnRunEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkOnlyFirst;
    }
}

