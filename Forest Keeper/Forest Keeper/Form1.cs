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
using System.Threading;

namespace Forest_Keeper
{
    public partial class MainForm : Form
    {
        private String xmlPath = null;
        private XmlDocument xdoc = null;
        private DateTime origin = new DateTime(1970, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc);
        private ImageList imgList = new ImageList();
        private ListViewItem infoItem = null;

        private String searchKeyword = null;
        private bool searchProcessingFlag = false;
        private Thread[] searchThreads = null;
        private object threadSynLocker = new object();

        private readonly Char[] invalidCharacters = new Char[] { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };

        delegate void CrossThreadSafetyAddListView(List<ListViewItem> buffer);

        public MainForm()
        {
            InitializeComponent();

            this.imgList.Images.Add(Properties.Resources.Folder_16x);
            this.imgList.Images.Add(Properties.Resources.FolderOpen_16x);
            this.imgList.Images.Add(Properties.Resources.Document_16x);
            this.treeView1.ImageList = this.imgList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Load_XML();
            TreeNode[] treeNodes = this.treeView1.Nodes.Find("cuc.txt", true);
            foreach (TreeNode node in treeNodes)
            {
                Console.WriteLine(node.Name);
            }
            Console.WriteLine("Complete");
            Console.WriteLine(((TreeNodeXML)this.treeView1.Nodes[0].Nodes[0]).GetXmlNodes().Attributes["name"].Value);
            */
        }

        private void Load_XML()
        {
            if (this.xmlPath == null)
            {
                Console.WriteLine("XML path is invalid.");
                return;
            }

            if (this.xdoc != null)
            {
                //this.xdoc.SelectSingleNode("/root").RemoveAll();
                this.treeView1.Nodes.Clear();
                this.textBox_Search.Text = "";
                this.listView_FInfo.Items.Clear();
                this.listView_Search.Items.Clear();

                this.xdoc = null;
            }

            this.xdoc = new XmlDocument();
            this.xdoc.Load(this.xmlPath);
            XmlNode rootXmlNode = this.xdoc.SelectSingleNode("/root");
            String newNodeName = rootXmlNode.Attributes["path"].Value;
            this.treeView1.Nodes.Add(newNodeName, newNodeName, 0, 0);
            TreeNode rootTreeNode = treeView1.Nodes[this.treeView1.Nodes.Count - 1];
            rootTreeNode.Tag = rootXmlNode;

            //LoadLazyDeepTrees(rootXmlNode, rootTreeNode);
            LoadDeepTrees(rootXmlNode, rootTreeNode, 1);
            MessageBox.Show("XML 파일 로딩 완료", "알림", MessageBoxButtons.OK);
        }
        
        private void LoadDeepTrees(XmlNode rootXmlNode, TreeNode rootTreeNode, int level)
        {
            XmlNodeList nodeList = rootXmlNode.ChildNodes;
            //String indent = String.Concat(Enumerable.Repeat("  ", level));

            foreach (XmlNode child in nodeList)
            {
                if (String.Compare(child.Name, "directory") == 0)
                {
                    if(child.ChildNodes.Count > 50000)
                    {
                        String mg = "다음 디렉토리에는 너무 많은 파일이 존재하여 표시하지 않습니다.";
                        mg += "\r\\" + rootTreeNode.FullPath + "\\" + child.Attributes["name"].Value;
                        mg += "\r파일 갯수: " + child.ChildNodes.Count.ToString();
                        MessageBox.Show(mg, "경고", MessageBoxButtons.OK);
                        continue;
                    }

                    String newNodeName = child.Attributes["name"].Value;
                    rootTreeNode.Nodes.Add(newNodeName, newNodeName, 0, 0);
                    TreeNode newNode = rootTreeNode.LastNode;
                    newNode.Tag = child;

                    LoadDeepTrees(child, newNode, level + 1);
                }
                else if (String.Compare(child.Name, "file") == 0)
                {
                    String newNodeName = child.Attributes["name"].Value;
                    rootTreeNode.Nodes.Add(newNodeName, newNodeName, 2, 2);
                    TreeNode newNode = rootTreeNode.LastNode;
                    newNode.Tag = child;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        /*
        private void LoadLazyDeepTrees(XmlNode rootXmlNode, TreeNode rootTreeNode)
        {
            XmlNodeList nodeList = rootXmlNode.ChildNodes;

            foreach (XmlNode child in nodeList)
            {
                if (rootTreeNode.Nodes.ContainsKey(child.Attributes["name"].Value) == true)
                    continue;

                if (String.Compare(child.Name, "directory") == 0)
                {
                    //Console.WriteLine(indent + child.Attributes["name"].Value);
                    //TreeNodeXML newNode = new TreeNodeXML(child.Attributes["name"].Value, child);
                    //rootTreeNode.Nodes.Add(newNode);
                    String newNodeName = child.Attributes["name"].Value;
                    rootTreeNode.Nodes.Add(newNodeName, newNodeName, 0, 0);
                    TreeNode newNode = rootTreeNode.LastNode;
                    newNode.Tag = child;
                }
                else if (String.Compare(child.Name, "file") == 0)
                {
                    String newNodeName = child.Attributes["name"].Value;
                    rootTreeNode.Nodes.Add(newNodeName, newNodeName, 2, 2);
                    TreeNode newNode = rootTreeNode.LastNode;
                    newNode.Tag = child;
                }
                else
                {
                    Console.WriteLine("XML format Error");
                }
            }
        }
        */

        private bool IsValid()
        {
            foreach(Char invalidChar in this.invalidCharacters)
            {
                if (this.textBox_Search.Text.IndexOf(invalidChar) != -1)
                    return false;
            }
            return true;
        }

        private void MonitorSearchThreads()
        {
            int numOfSearchThreads = this.searchThreads.Length;

            while(true)
            {
                int numOfExitThreads = 0;

                for (int idx = 0; idx < numOfSearchThreads; idx++)
                {
                    if (this.searchThreads[idx].IsAlive == false)
                        numOfExitThreads++;
                }

                if(numOfExitThreads >= numOfSearchThreads)
                {
                    this.searchThreads = null;
                    this.searchProcessingFlag = false;
                    this.searchKeyword = null;
                    MessageBox.Show("검색이 완료되었습니다.", "알림", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void AddListViewItemBuffer_Thread(TreeNode targetNode, List<ListViewItem> itemBuffer)
        {
            ListViewItem newSearchResult = new ListViewItem(targetNode.Name);
            newSearchResult.SubItems.Add("\\" + targetNode.FullPath);
            newSearchResult.SubItems.Add(((XmlNode)targetNode.Tag).Name);

            itemBuffer.Add(newSearchResult);
        }

        private void AddListView_Thread(List<ListViewItem> itemBuffer)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CrossThreadSafetyAddListView(AddListView_Thread), itemBuffer);
            }
            else
            {
                foreach(ListViewItem item in itemBuffer)
                    this.listView_Search.Items.Add(item);
            }
        }

        private void SearchFileDirectory_ThreadFunc_Deeper(TreeNode rootNode, List<ListViewItem> itemBuffer)
        {
            foreach(TreeNode child in rootNode.Nodes)
            {
                if (child.Name.Contains(this.searchKeyword) == true)
                    AddListViewItemBuffer_Thread(child, itemBuffer);

                if (((XmlNode)child.Tag).Name == "directory")
                    SearchFileDirectory_ThreadFunc_Deeper(child, itemBuffer);
            }
        }

        private void SearchFileDirectory_ThreadFunc(object rootNode)
        {
            TreeNode rootTreeNode = (TreeNode)rootNode;
            List<ListViewItem> itemBuffer = new List<ListViewItem>();

            if (rootTreeNode.Name.Contains(this.searchKeyword) == true)
                AddListViewItemBuffer_Thread(rootTreeNode, itemBuffer);

            SearchFileDirectory_ThreadFunc_Deeper(rootTreeNode, itemBuffer);

            // Lazy ListView addition
            AddListView_Thread(itemBuffer);
        }

        private void SearchFileDirectory()
        {
            this.searchProcessingFlag = true;
            this.searchKeyword = String.Copy(this.textBox_Search.Text);
            this.listView_Search.Items.Clear();
            
            TreeNode rootNode = this.treeView1.Nodes[this.treeView1.Nodes.Count - 1];
            int numOf1stChildren = rootNode.Nodes.Count;
            this.searchThreads = new Thread[numOf1stChildren];

            for (int threadIdx = 0; threadIdx < numOf1stChildren; threadIdx++)
            {
                this.searchThreads[threadIdx] = new Thread(new ParameterizedThreadStart(SearchFileDirectory_ThreadFunc));
                this.searchThreads[threadIdx].Start(rootNode.Nodes[threadIdx]);
            }

            Thread monitorThread = new Thread(new ThreadStart(MonitorSearchThreads));
            monitorThread.Start();
        }

        private String ConvertSize(String size, ref String sizeUnit)
        {
            long tmpSize = Convert.ToInt64(size);
            if (tmpSize < 1024)
            {
                sizeUnit = "KB";
                return "1";
            }

            tmpSize /= 1024;
            if (tmpSize < 1024)
            {
                sizeUnit = "KB";
                return tmpSize.ToString();
            }

            tmpSize /= 1024;
            if (tmpSize < 1024)
            {
                sizeUnit = "MB";
                return tmpSize.ToString();
            }

            tmpSize /= 1024;
            if (tmpSize < 1024)
            {
                sizeUnit = "GB";
                return tmpSize.ToString();
            }

            tmpSize /= 1024;
            if (tmpSize < 1024)
            {
                sizeUnit = "TB";
                return tmpSize.ToString();
            }

            return "0";
        }


        private void loadXmlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";

            while(true)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.xmlPath = openFileDialog1.FileName;
                    openFileDialog1.InitialDirectory = this.xmlPath.Substring(0, this.xmlPath.LastIndexOf('\\'));

                    String fileExt = this.xmlPath.Split('.')[this.xmlPath.Split('.').Length - 1];
                    if (String.Compare(fileExt, "xml") == 0)
                    {
                        Load_XML();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("It is not xml file.");
                    }
                }
                else
                {
                    break;
                }
            }
            
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex == 1 && e.Node.IsExpanded == true)
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex == 0 && e.Node.IsExpanded == false)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
            }

            /*
            foreach (TreeNode child in e.Node.Nodes)
            {
                XmlNode childXmlNode = (XmlNode)child.Tag;
                if (String.Compare(childXmlNode.Name, "directory") == 0)
                {
                    if (childXmlNode.HasChildNodes)
                    {
                        if(childXmlNode.ChildNodes.Count > 50000)
                        {
                            String mg = "다음 디렉토리에는 너무 많은 파일이 존재하여 표시하지 않습니다.";
                            mg += "\r\\" + child.FullPath;
                            mg += "\r파일 갯수: " + childXmlNode.ChildNodes.Count.ToString();
                            MessageBox.Show(mg, "경고", MessageBoxButtons.OK);
                        }
                        else
                        {
                            LoadLazyDeepTrees((XmlNode)child.Tag, child);
                        }
                    }
                }
            }
            */
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlNode xmlNode = (XmlNode)e.Node.Tag;
            if (String.Compare(xmlNode.Name, "directory") == 0 || String.Compare(xmlNode.Name, "root") == 0)
                return;

            if (this.infoItem != null)
            {
                this.infoItem.Remove();
                this.listView_FInfo.Items.Remove(this.infoItem);
                this.infoItem = null;
            }

            this.infoItem = new ListViewItem(xmlNode.Attributes["name"].Value);
            this.infoItem.SubItems.Add(e.Node.FullPath);
            // Console.WriteLine(Convert.ToDateTime(xmlNode.SelectSingleNode("./m_time").InnerText));
            double dTime = Convert.ToDouble(xmlNode.SelectSingleNode("./m_time").InnerText);
            DateTime fTime = this.origin.AddSeconds(dTime);
            this.infoItem.SubItems.Add(fTime.ToString());
            this.infoItem.SubItems.Add(xmlNode.SelectSingleNode("./ext").InnerText);
            String sizeUnit = "";
            String size = ConvertSize(xmlNode.SelectSingleNode("./size").InnerText, ref sizeUnit);
            this.infoItem.SubItems.Add(size + " " + sizeUnit);

            this.listView_FInfo.Items.Add(this.infoItem);
        }


        private void StartSearch_WhenClicked()
        {
            if(this.xdoc == null && this.treeView1.HasChildren == false)
            {
                MessageBox.Show("XML 파일이 로드되지 않았습니다.", "에러", MessageBoxButtons.OK);
                return;
            }

            if (this.searchProcessingFlag == true)
            {
                MessageBox.Show("검색이 진행중입니다.", "알림", MessageBoxButtons.OK);
                return;
            }

            this.textBox_Search.Text = this.textBox_Search.Text.Trim();
            if (this.textBox_Search.Text == "")
                MessageBox.Show("잘못된 입력입니다.\r입력값 없음", "에러", MessageBoxButtons.OK);
            else if (IsValid() == true)
                SearchFileDirectory();
            else
                MessageBox.Show("잘못된 입력입니다.\r유효하지 않은 문자 포함", "에러", MessageBoxButtons.OK);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            StartSearch_WhenClicked();
        }

        private void textBox_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (int)Keys.Enter)
            {
                StartSearch_WhenClicked();
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String content = "@Author:\tYoo JeongDo (0pt3ryx)";
            content += "\r@Email:\topteryx25104@hksecurity.net";

            MessageBox.Show(content, "정보", MessageBoxButtons.OK);
        }
    }
}
