using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace Labeling
{
    public partial class FormMain : Form
    {
        string g_folderImagePath = "";



        int m_lastSearchIndex = 0;
        string m_lastSearch = "";

        bool m_isTextboxFocused = false;

        static FormMain m_instance;

        Dictionary<string, string> m_labels = new Dictionary<string, string>();

        string m_labelFile = "label.txt";

        string m_fileName = "";

        int m_totalPage = 0;
        int m_currentPage = 1;
        int m_numContentPerPage = 50;
        string m_search = "";

        int m_numSelected = 0;

        string m_foundImagePath = "";


        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormMain()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form2_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            TGMTform.SetDoubleBuffer(panel1);

            g_folderImagePath = TGMTregistry.GetInstance().ReadString("txtFolderImage");

            m_numContentPerPage = TGMTregistry.GetInstance().ReadInt("numContentPerPage", m_numContentPerPage);

            for(int i=0; i< cb_contentPerPage.DropDownItems.Count; i++)
            {
                if(cb_contentPerPage.DropDownItems[i].Text == m_numContentPerPage.ToString())
                {
                    cb_contentPerPage.SelectedIndex = i;
                    break;
                }                
            }
            
            chk_askBeforeDelete.Checked = TGMTregistry.GetInstance().ReadBool("chk_askBeforeDelete", true);


            this.KeyPreview = true;

            this.Text += " " + TGMTutil.GetVersion();

#if DEBUG
            this.Text += " (Debug)";
#endif


            LoadRecentDir();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormMain GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormMain();
            return m_instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadRecentDir()
        {
            ribbon1.OrbDropDown.RecentItems.Clear();

            string recentDir = TGMTregistry.GetInstance().ReadString("recentDir");
            if (recentDir != "")
            {
                string[] recentDirs = recentDir.Split(';');

                if (recentDirs.Length > 0)
                {
                    int endIdx = Math.Max(recentDirs.Length - 5, 0);
                    for (int i = recentDirs.Length-1; i > endIdx; i--)
                    {
                        if (!Directory.Exists(recentDirs[i]))
                            continue;
                        RibbonOrbRecentItem item = new RibbonOrbRecentItem(recentDirs[i]);
                        item.Click += this.recentItem_Click;
                        ribbon1.OrbDropDown.RecentItems.Add(item);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void recentItem_Click(object sender, EventArgs e)
        {
            g_folderImagePath = ((RibbonOrbRecentItem)sender).Text;
            if (Directory.Exists(g_folderImagePath))
            {
                m_currentPage = 1;
                LoadImage();
            }                
            else
            {
                MessageBox.Show("Folder không tồn tại");
            }                
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            //if (m_isTextboxFocused)
            //    return;

            if (e.KeyCode == Keys.Left)
            {
                GoToPreviousPage();
            }
            else if (e.KeyCode == Keys.Right)
            {
                GoToNextPage();
            }
            else if (e.KeyCode == Keys.F)
            {
                if (e.Control)
                {
                    SearchFile();
                }
            }            
            else
            {
                e.Handled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Select folder contain image";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                g_folderImagePath = TGMTutil.CorrectPath(folderPath);

                if (g_folderImagePath.Contains(" "))
                {
                    MessageBox.Show("Folder không được có khoảng trắng hay ký tự đặc biệt");
                    return;
                }


                if (!Directory.Exists(g_folderImagePath))
                {
                    MessageBox.Show("Folder không tồn tại");
                    return;
                }
                LoadImage();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Directory.Exists(g_folderImagePath))
            {
                MessageBox.Show("Không tìm thấy folder:" + g_folderImagePath);
                return;
            }

            panel1.Controls.Clear();

            List<int> listNoTxt = new List<int>();
            int index = 0;


            string labelDir = TGMTutil.CorrectPath(g_folderImagePath);


            int fromIndex = (m_currentPage - 1) * m_numContentPerPage;
            int toIndex = Math.Min(fromIndex + m_numContentPerPage - 1, m_labels.Keys.Count - 1);


            for (int i = fromIndex; i <= toIndex; i++)
            {
                string fileName = m_labels.ElementAt(i).Key;
                //if (!TGMTimage.IsImage(filePath))
                //continue;

                string filePath = g_folderImagePath + fileName;



                UClabel uc = new UClabel();
                uc.CheckboxChanged += UcLabel_CheckboxChanged;
                uc.ImagePath = filePath;

                if (m_labels.ContainsKey(fileName))
                {
                    uc.textBox1.Text = m_labels[fileName];
                    if(uc.textBox1.Text == "")
                    {
                        uc.textBox1.BackColor = Color.Red;
                    }
                }
                else
                {
                    listNoTxt.Add(index);
                }



                this.Invoke(new Action(() =>
                {
                    panel1.Controls.Add(uc);
                }));
                index++;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Minimum;
            lblMessage.Text = "";

            ribbonPanel2.Text = "0/" + panel1.Controls.Count;
            cb_page.TextBoxText = m_currentPage.ToString();

            btn_search.Enabled = true;
            btn_imageNoLabel.Enabled = true;

            CheckNextPrevious();

            if(m_search != "")
            {
                int fileIndex = m_lastSearchIndex - (m_numContentPerPage * (m_currentPage - 1));

                UClabel uc = (UClabel)panel1.Controls[fileIndex];
                uc.Focus();
              
                m_search = "";
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void GotoLastNotAnnotated()
        {
            //if (lstImg.Items.Count == 0)
            //    return;

            //int startIndex = lstImg.Items.Count - 1;
            //if (lstImg.SelectedIndices.Count > 0)
            //    startIndex = lstImg.SelectedIndices[0] - 1;

            //for (int i = startIndex; i > 0; i--)
            //{
            //    string filePath = g_folderImagePath + lstImg.Items[i].Text;
            //    string txtPath = filePath.Replace(Path.GetExtension(filePath), ".txt");
            //    if (File.Exists(txtPath))
            //    {
            //        string[] lines = File.ReadAllLines(txtPath);
            //        if (lines.Length == 0)
            //        {
            //            lstImg.Items[i].Selected = true;
            //            lstImg.EnsureVisible(i);
            //            lstImg.Focus();
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        lstImg.Items[i].Selected = true;
            //        lstImg.EnsureVisible(i);
            //        lstImg.Focus();
            //        return;
            //    }

            //}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void GotoNextNotAnnotated()
        {
            //int startIndex = 0;
            //if (lstImg.SelectedIndices.Count > 0)
            //    startIndex = lstImg.SelectedIndices[0] + 1;
            //for (int i = startIndex; i < lstImg.Items.Count; i++)
            //{
            //    string filePath = TGMTutil.CorrectPath(g_folderImagePath) + lstImg.Items[i].Text;
            //    string txtPath = filePath.Replace(Path.GetExtension(filePath), ".txt");
            //    if (File.Exists(txtPath))
            //    {
            //        string[] lines = File.ReadAllLines(txtPath);
            //        if (lines.Length == 0)
            //        {
            //            lstImg.Items[i].Selected = true;
            //            lstImg.EnsureVisible(i);
            //            lstImg.Focus();
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        lstImg.Items[i].Selected = true;
            //        lstImg.EnsureVisible(i);
            //        lstImg.Focus();
            //        return;
            //    }

            //}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SearchFile()
        {
            if (txt_search.TextBoxText == "")
                return;

            m_search = txt_search.TextBoxText.ToLower().Trim();
            m_foundImagePath = "";

            if (m_search != m_lastSearch)
                m_lastSearchIndex = 0;
            m_lastSearch = m_search;
            if (m_lastSearchIndex >= m_labels.Count - 1)
                m_lastSearchIndex = 0;

            bool found = false;

            for (int i = m_lastSearchIndex + 1; i < m_labels.Count; i++)
            {
                string filename = m_labels.ElementAt(i).Key.ToLower();
                string label = m_labels.ElementAt(i).Value.ToLower();

                if (filename.Contains(m_search) || label.Contains(m_search))
                {
                    found = true;
                    m_lastSearchIndex = i;
                    m_foundImagePath = filename;
                    break;
                }
            }

            if (!found) //search again at begin
            {
                for (int i = 0; i < m_labels.Count; i++)
                {
                    string filename = m_labels.ElementAt(i).Key.ToLower();
                    string label = m_labels.ElementAt(i).Value.ToLower();

                    if (filename.Contains(m_search) || label.Contains(m_search))
                    {
                        found = true;
                        m_lastSearchIndex = i;
                        m_foundImagePath = filename;
                        break;
                    }
                }
            }



            if (found)
            {
                int contentPerPage = int.Parse(cb_contentPerPage.SelectedItem.Text);
                int pageIdx = (int)Math.Ceiling((double)(m_lastSearchIndex + 1) / contentPerPage);
                m_currentPage = pageIdx;
                
                LoadImage();
            }
            else
            {
                m_lastSearchIndex = 0;
                PrintError("Not found");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = message;
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = message;
            timerClear.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CompleteEdit(string fileName, string text)
        {
            m_labels[fileName] = text;

            string labelFilePath = g_folderImagePath + fileName.Replace(".jpg", ".txt");
            File.WriteAllText(labelFilePath, text);

            SaveLabels();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SaveLabels()
        {
            File.WriteAllLines(g_folderImagePath + m_labelFile, m_labels.Select(x => x.Key + "\t" + x.Value).ToArray());
            PrintSuccess("Save thành công");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadImage()
        {
            //this.Enabled = false;
            lblMessage.Text = "Loading file...";


            ClearControl();


            TGMTregistry.GetInstance().SaveValue("txtFolderImage", g_folderImagePath);

            string recentDir = TGMTregistry.GetInstance().ReadString("recentDir");
            if (recentDir == "")
                recentDir += g_folderImagePath;
            else
            {
                if (!recentDir.Contains(g_folderImagePath))
                    recentDir += ";" + g_folderImagePath;
            }


            TGMTregistry.GetInstance().SaveValue("recentDir", recentDir);

            LoadLabels();

            if (!bgLoadFile.IsBusy)
            {
                bgLoadFile.RunWorkerAsync();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_search_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFile();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgCrop_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            PrintMessage(e.ProgressPercentage + "%");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgCrop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Minimum;
            PrintMessage("");
            MessageBox.Show(e.Result.ToString(), "Crop success");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchFile();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_imageNoLabel_Click(object sender, EventArgs e)
        {
            bool found = false;

            for (int i = 0; i < m_labels.Count; i++)
            {
                string label = m_labels.ElementAt(i).Value;

                if (label == "")
                {
                    found = true;
                    m_search = "@@##"; //trick
                    int contentPerPage = int.Parse(cb_contentPerPage.SelectedItem.Text);
                    int pageIdx = (int)Math.Ceiling((double)i / contentPerPage);
                    m_currentPage = pageIdx;
                    LoadImage();
                    break;
                }
            }

            if (!found)
                PrintError("Not found");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveLabels();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerClear_Tick(object sender, EventArgs e)
        {
            timerClear.Stop();
            lblMessage.Text = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadLabels()
        {
            m_labels.Clear();

            string filePath = g_folderImagePath + m_labelFile;
            if(!File.Exists(filePath))
            {
                //MessageBox.Show("File " + m_labelFile + " không tồn tại.");
                //return;
                MergeLabelFiles(g_folderImagePath, m_labelFile);
            }

            string[] lines = File.ReadAllLines(filePath);

            int totalLine = lines.Length;
            if (totalLine == 0)
            {
                MessageBox.Show("File " + m_labelFile + " rỗng.");
                return;
            }

            m_totalPage = (int)((float)totalLine / m_numContentPerPage) + 1;


            cb_page.DropDownItems.Clear();
            for(int i=1; i<=m_totalPage; i++)
            {
                cb_page.DropDownItems.Add(i.ToString());
            }

            if (m_currentPage > m_totalPage)
                m_currentPage = m_totalPage;

            panel_paging.Text = String.Format("Page: {0}/{1}", m_currentPage, m_totalPage); 

            for (int i=0; i<lines.Length; i++)
            {
                string[] splitted = lines[i].Split('\t');
                if(splitted.Length == 2)
                {
                    if (m_labels.ContainsKey(splitted[0]))
                        continue;
                    m_labels.Add(splitted[0], splitted[1]);
                }
            }

            CheckNextPrevious();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MergeLabelFiles(string folderPath, string labelFileName)
        {
            string outputFile = Path.Combine(folderPath, labelFileName);

            // Ensure "label.txt" is cleared or created
            File.WriteAllText(outputFile, "");

            foreach (string filePath in Directory.GetFiles(folderPath, "*.txt"))
            {
                string fileName = Path.GetFileName(filePath);

                // Skip "label.txt"
                if (fileName.Equals(labelFileName, StringComparison.OrdinalIgnoreCase))
                    continue;

                // Read content of the file
                string content = File.ReadAllText(filePath);

                // Format: fileName (replace .txt with .jpg) \t content \n
                string formattedLine = $"{fileName.Replace(".txt", ".jpg")}\t{content}\n";

                // Append to "label.txt"
                File.AppendAllText(outputFile, formattedLine);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteLabel(string fileName)
        {
            List<Control> listControls = panel1.Controls.Cast<Control>().ToList();

            for(int i=0; i< panel1.Controls.Count; i++)
            {
                UClabel uc = (UClabel)panel1.Controls[i];
                if(uc.FileName == fileName)
                {
                    int lastIndex = i;
                    panel1.Controls.Remove(uc);
                    uc.Dispose();

                    if (lastIndex >= panel1.Controls.Count)
                        lastIndex = panel1.Controls.Count - 1;

                    if(lastIndex >= 0)
                    {
                        panel1.Controls[lastIndex].Focus();
                        ribbonPanel2.Text = lastIndex + "/" + panel1.Controls.Count;
                    }
                    
                    break;
                }
                
            }

            m_labels.Remove(fileName);
            File.Delete(g_folderImagePath + fileName);
            File.Delete(g_folderImagePath + fileName.Replace(".jpg", ".txt"));


            SaveLabels();

            m_numSelected--;
            btn_delete.Enabled = m_numSelected > 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetSelected(string fileName)
        {
            int index = Array.IndexOf(m_labels.Keys.ToArray(), fileName);

            if(index >= 0)
            {
                m_fileName = fileName;

                if(m_currentPage > 1)
                    index -= (m_currentPage - 1) * m_numContentPerPage;

                ribbonPanel2.Text = (index + 1) + "/" + panel1.Controls.Count;
                m_isTextboxFocused = true;
            }
            else
            {
                m_fileName = "";
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (chk_askBeforeDelete.Checked)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa file", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

            for (int i = panel1.Controls.Count -1 ; i>=0; i--)
            {
                UClabel uc = (UClabel)panel1.Controls[i];
                if(uc.chk_select.Checked)
                {
                    DeleteLabel(uc.FileName);
                }
            }

            chk_selectAll.Checked = false;
            LoadImage();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_previous_Click(object sender, EventArgs e)
        {
            GoToPreviousPage();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void GoToPreviousPage()
        {
            if (m_currentPage <= 1)
                return;

            chk_selectAll.Checked = false;
            m_currentPage--;
            panel_paging.Text = String.Format("Page: {0}/{1}", m_currentPage, m_totalPage);

            CheckNextPrevious();

            ClearControl();
            bgLoadFile.RunWorkerAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_next_Click(object sender, EventArgs e)
        {
            GoToNextPage();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void GoToNextPage()
        {
            if (m_currentPage >= m_totalPage)
                return;

            chk_selectAll.Checked = false;
            m_currentPage++;
            panel_paging.Text = String.Format("Page: {0}/{1}", m_currentPage, m_totalPage);

            CheckNextPrevious();

            ClearControl();
            bgLoadFile.RunWorkerAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_contentPerPage_DropDownItemClicked(object sender, RibbonItemEventArgs e)
        {
            string txt = cb_contentPerPage.SelectedItem.Text;
            m_numContentPerPage = int.Parse(txt);

            TGMTregistry.GetInstance().SaveValue("numContentPerPage", m_numContentPerPage);

            LoadLabels();
            bgLoadFile.RunWorkerAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ClearControl()
        {
            btn_search.Enabled = false;
            btn_imageNoLabel.Enabled = false;
            btn_previous.Enabled = false;
            btn_next.Enabled = false;
            panel1.Controls.Clear();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void CheckNextPrevious()
        {
            btn_previous.Enabled = m_currentPage > 1;
            btn_next.Enabled = m_currentPage < m_totalPage;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_page_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (cb_page.TextBoxText == "")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                SelectPage();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_page_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cb_page.TextBoxText == "")
                return;
            SelectPage();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SelectPage()
        {
            int currentPage = int.Parse(cb_page.TextBoxText);
            if (m_currentPage == currentPage)
                return;

            chk_selectAll.Checked = false;
            if (currentPage < 1 || currentPage > m_totalPage)
            {
                MessageBox.Show("Số trang phải lớn hơn 0 và nhỏ hơn tổng số trang");
                return;
            }

            m_currentPage = currentPage;
            LoadImage();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_askBeforeDelete_CheckBoxCheckChanged(object sender, EventArgs e)
        {
             TGMTregistry.GetInstance().SaveValue("chk_askBeforeDelete", chk_askBeforeDelete.Checked);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_selectAll_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                UClabel uc = (UClabel)panel1.Controls[i];
                uc.chk_select.Checked = chk_selectAll.Checked;
            }
            if(panel1.Controls.Count > 0)
            {
                btn_delete.Enabled = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UcLabel_CheckboxChanged(object sender, bool isChecked)
        {
            if (isChecked)
                m_numSelected++;
            else
                m_numSelected--;

            btn_delete.Enabled = m_numSelected > 0;
        }
    }
}
