using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;

namespace Labeling
{
    public partial class UClabel : UserControl
    {
        string m_imagePath = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public UClabel()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ImagePath
        {
            get => m_imagePath;
            set{
                m_imagePath = value;
                pictureBox1.ImageLocation = m_imagePath;
                lbl_imagePath.Text = m_imagePath;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsChecked
        {
            get { return chk_select.Checked; }
            set { chk_select.Checked = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string FileName
        {
            get => Path.GetFileName(m_imagePath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public event EventHandler<bool> CheckboxChanged;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || (e.Control && e.KeyCode == Keys.S))
            {
                FormMain.GetInstance().CompleteEdit(Path.GetFileName(m_imagePath), textBox1.Text);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UClabel_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;

            FormMain.GetInstance().SetSelected(Path.GetFileName(m_imagePath));
            textBox1.BackColor = Color.White;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UClabel_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            FormMain.GetInstance().SetSelected("");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (!File.Exists(m_imagePath))
                return;
            

            Process.Start("explorer.exe", $"/select,\"{m_imagePath}\"");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "btnCopyPath")
            {
                Clipboard.SetText(m_imagePath);
                FormMain.GetInstance().PrintMessage("Copied path to clipboard");
            }
            else if (e.ClickedItem.Name == "btnCopyImage")
            {
                StringCollection paths = new StringCollection();
                paths.Add(m_imagePath);
                Clipboard.SetFileDropList(paths);
                FormMain.GetInstance().PrintMessage("Copied image to clipboard");
            }
            else if (e.ClickedItem.Name == "btnOpenImage")
            {
                if (!File.Exists(m_imagePath))
                    return;
                System.Diagnostics.Process.Start(m_imagePath);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_select_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxChanged?.Invoke(this, chk_select.Checked);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
