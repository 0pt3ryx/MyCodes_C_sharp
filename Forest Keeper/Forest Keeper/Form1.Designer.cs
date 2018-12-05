namespace Forest_Keeper
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadXmlFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listView_Search = new System.Windows.Forms.ListView();
            this.searchHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_FInfo = new System.Windows.Forms.ListView();
            this.fInfoHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fInfoHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fInfoHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fInfoHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fInfoHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXMLToolStripMenuItem,
            this.showInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1447, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadXMLToolStripMenuItem
            // 
            this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
            this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.loadXMLToolStripMenuItem.Text = "Load Xml File";
            this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.loadXmlFileToolStripMenuItem_Click);
            // 
            // loadXmlFileToolStripMenuItem
            // 
            this.loadXmlFileToolStripMenuItem.Name = "loadXmlFileToolStripMenuItem";
            this.loadXmlFileToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.loadXmlFileToolStripMenuItem.Text = "Load xml file";
            this.loadXmlFileToolStripMenuItem.Click += new System.EventHandler(this.loadXmlFileToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1447, 632);
            this.splitContainer1.SplitterDistance = 807;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(807, 632);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.button_Search);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_Search);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(636, 632);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.TabIndex = 0;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(321, 0);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // textBox_Search
            // 
            this.textBox_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_Search.Location = new System.Drawing.Point(0, 0);
            this.textBox_Search.MaxLength = 31;
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(315, 21);
            this.textBox_Search.TabIndex = 0;
            this.textBox_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Search_KeyPress);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listView_Search);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listView_FInfo);
            this.splitContainer3.Size = new System.Drawing.Size(636, 573);
            this.splitContainer3.SplitterDistance = 420;
            this.splitContainer3.TabIndex = 0;
            // 
            // listView_Search
            // 
            this.listView_Search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.searchHeader1,
            this.searchHeader2,
            this.searchHeader3});
            this.listView_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Search.Location = new System.Drawing.Point(0, 0);
            this.listView_Search.Name = "listView_Search";
            this.listView_Search.Size = new System.Drawing.Size(636, 420);
            this.listView_Search.TabIndex = 0;
            this.listView_Search.UseCompatibleStateImageBehavior = false;
            this.listView_Search.View = System.Windows.Forms.View.Details;
            // 
            // searchHeader1
            // 
            this.searchHeader1.Text = "Name";
            this.searchHeader1.Width = 84;
            // 
            // searchHeader2
            // 
            this.searchHeader2.Text = "Path";
            this.searchHeader2.Width = 447;
            // 
            // searchHeader3
            // 
            this.searchHeader3.Text = "Type";
            this.searchHeader3.Width = 99;
            // 
            // listView_FInfo
            // 
            this.listView_FInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fInfoHeader1,
            this.fInfoHeader2,
            this.fInfoHeader3,
            this.fInfoHeader4,
            this.fInfoHeader5});
            this.listView_FInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_FInfo.Location = new System.Drawing.Point(0, 0);
            this.listView_FInfo.Name = "listView_FInfo";
            this.listView_FInfo.Size = new System.Drawing.Size(636, 149);
            this.listView_FInfo.TabIndex = 0;
            this.listView_FInfo.UseCompatibleStateImageBehavior = false;
            this.listView_FInfo.View = System.Windows.Forms.View.Details;
            // 
            // fInfoHeader1
            // 
            this.fInfoHeader1.Text = "Name";
            this.fInfoHeader1.Width = 96;
            // 
            // fInfoHeader2
            // 
            this.fInfoHeader2.Text = "Path";
            this.fInfoHeader2.Width = 212;
            // 
            // fInfoHeader3
            // 
            this.fInfoHeader3.Text = "Modified Time";
            this.fInfoHeader3.Width = 149;
            // 
            // fInfoHeader4
            // 
            this.fInfoHeader4.Text = "Extension";
            this.fInfoHeader4.Width = 91;
            // 
            // fInfoHeader5
            // 
            this.fInfoHeader5.Text = "Size(byte)";
            this.fInfoHeader5.Width = 83;
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.showInfoToolStripMenuItem.Text = "Show info.";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1447, 656);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Forest Keeper v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadXmlFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView listView_Search;
        private System.Windows.Forms.ListView listView_FInfo;
        private System.Windows.Forms.ColumnHeader fInfoHeader1;
        private System.Windows.Forms.ColumnHeader fInfoHeader2;
        private System.Windows.Forms.ColumnHeader fInfoHeader3;
        private System.Windows.Forms.ColumnHeader fInfoHeader4;
        private System.Windows.Forms.ColumnHeader fInfoHeader5;
        private System.Windows.Forms.ColumnHeader searchHeader1;
        private System.Windows.Forms.ColumnHeader searchHeader2;
        private System.Windows.Forms.ColumnHeader searchHeader3;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
    }
}

