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

        public string FileName
        {
            get => Path.GetFileName(m_imagePath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
    }
}
