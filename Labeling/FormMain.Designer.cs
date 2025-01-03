namespace Labeling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.btn_openFolder = new System.Windows.Forms.RibbonOrbMenuItem();
            this.recentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.recentItem2 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.recentItem3 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.txt_search = new System.Windows.Forms.RibbonTextBox();
            this.chk_selectAll = new System.Windows.Forms.RibbonCheckBox();
            this.btn_search = new System.Windows.Forms.RibbonButton();
            this.btn_imageNoLabel = new System.Windows.Forms.RibbonButton();
            this.btn_delete = new System.Windows.Forms.RibbonButton();
            this.panel_paging = new System.Windows.Forms.RibbonPanel();
            this.cb_contentPerPage = new System.Windows.Forms.RibbonComboBox();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.cb_page = new System.Windows.Forms.RibbonComboBox();
            this.ribbonItemGroup1 = new System.Windows.Forms.RibbonItemGroup();
            this.btn_previous = new System.Windows.Forms.RibbonButton();
            this.btn_next = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.chk_askBeforeDelete = new System.Windows.Forms.RibbonCheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 2;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.btn_openFolder);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.RecentItems.Add(this.recentItem1);
            this.ribbon1.OrbDropDown.RecentItems.Add(this.recentItem2);
            this.ribbon1.OrbDropDown.RecentItems.Add(this.recentItem3);
            this.ribbon1.OrbDropDown.RecentItemsCaption = "Recent folder";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(800, 163);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "FILE";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1221, 150);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // btn_openFolder
            // 
            this.btn_openFolder.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.btn_openFolder.Image = global::Labeling.Properties.Resources.close32;
            this.btn_openFolder.LargeImage = global::Labeling.Properties.Resources.close32;
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.SmallImage = global::Labeling.Properties.Resources.close32;
            this.btn_openFolder.Text = "Open folder";
            this.btn_openFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // recentItem1
            // 
            this.recentItem1.Image = ((System.Drawing.Image)(resources.GetObject("recentItem1.Image")));
            this.recentItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("recentItem1.LargeImage")));
            this.recentItem1.Name = "recentItem1";
            this.recentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("recentItem1.SmallImage")));
            // 
            // recentItem2
            // 
            this.recentItem2.Image = ((System.Drawing.Image)(resources.GetObject("recentItem2.Image")));
            this.recentItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("recentItem2.LargeImage")));
            this.recentItem2.Name = "recentItem2";
            this.recentItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("recentItem2.SmallImage")));
            // 
            // recentItem3
            // 
            this.recentItem3.Image = ((System.Drawing.Image)(resources.GetObject("recentItem3.Image")));
            this.recentItem3.LargeImage = ((System.Drawing.Image)(resources.GetObject("recentItem3.LargeImage")));
            this.recentItem3.Name = "recentItem3";
            this.recentItem3.SmallImage = ((System.Drawing.Image)(resources.GetObject("recentItem3.SmallImage")));
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.panel_paging);
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "Manual label";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.txt_search);
            this.ribbonPanel2.Items.Add(this.chk_selectAll);
            this.ribbonPanel2.Items.Add(this.btn_search);
            this.ribbonPanel2.Items.Add(this.btn_imageNoLabel);
            this.ribbonPanel2.Items.Add(this.btn_delete);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Image 0/0";
            // 
            // txt_search
            // 
            this.txt_search.Name = "txt_search";
            this.txt_search.Text = "";
            this.txt_search.TextBoxText = "";
            this.txt_search.TextBoxWidth = 200;
            this.txt_search.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_TextBoxKeyDown);
            // 
            // chk_selectAll
            // 
            this.chk_selectAll.Name = "chk_selectAll";
            this.chk_selectAll.Text = "Select all";
            this.chk_selectAll.CheckBoxCheckChanged += new System.EventHandler(this.chk_selectAll_CheckBoxCheckChanged);
            // 
            // btn_search
            // 
            this.btn_search.Enabled = false;
            this.btn_search.Image = global::Labeling.Properties.Resources.find32;
            this.btn_search.LargeImage = global::Labeling.Properties.Resources.find32;
            this.btn_search.MinimumSize = new System.Drawing.Size(60, 0);
            this.btn_search.Name = "btn_search";
            this.btn_search.SmallImage = ((System.Drawing.Image)(resources.GetObject("btn_search.SmallImage")));
            this.btn_search.Text = "Search";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_imageNoLabel
            // 
            this.btn_imageNoLabel.Enabled = false;
            this.btn_imageNoLabel.Image = global::Labeling.Properties.Resources.printpreview32;
            this.btn_imageNoLabel.LargeImage = global::Labeling.Properties.Resources.printpreview32;
            this.btn_imageNoLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this.btn_imageNoLabel.Name = "btn_imageNoLabel";
            this.btn_imageNoLabel.SmallImage = ((System.Drawing.Image)(resources.GetObject("btn_imageNoLabel.SmallImage")));
            this.btn_imageNoLabel.Text = "Find no label";
            this.btn_imageNoLabel.Click += new System.EventHandler(this.btn_imageNoLabel_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Enabled = false;
            this.btn_delete.Image = global::Labeling.Properties.Resources.minus32x32;
            this.btn_delete.LargeImage = global::Labeling.Properties.Resources.minus32x32;
            this.btn_delete.MinimumSize = new System.Drawing.Size(60, 0);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btn_delete.SmallImage")));
            this.btn_delete.Text = "Delete";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel_paging
            // 
            this.panel_paging.Items.Add(this.cb_contentPerPage);
            this.panel_paging.Items.Add(this.cb_page);
            this.panel_paging.Items.Add(this.ribbonItemGroup1);
            this.panel_paging.Name = "panel_paging";
            this.panel_paging.Text = "Paging";
            // 
            // cb_contentPerPage
            // 
            this.cb_contentPerPage.AllowTextEdit = false;
            this.cb_contentPerPage.DropDownItems.Add(this.ribbonButton1);
            this.cb_contentPerPage.DropDownItems.Add(this.ribbonButton2);
            this.cb_contentPerPage.DropDownItems.Add(this.ribbonButton3);
            this.cb_contentPerPage.DropDownItems.Add(this.ribbonButton4);
            this.cb_contentPerPage.DropDownItems.Add(this.ribbonButton5);
            this.cb_contentPerPage.Name = "cb_contentPerPage";
            this.cb_contentPerPage.SelectedIndex = -1;
            this.cb_contentPerPage.Text = "Num image per page";
            this.cb_contentPerPage.TextBoxText = "";
            this.cb_contentPerPage.DropDownItemClicked += new System.Windows.Forms.RibbonComboBox.RibbonItemEventHandler(this.cb_contentPerPage_DropDownItemClicked);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "20";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "50";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "100";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "200";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "500";
            // 
            // cb_page
            // 
            this.cb_page.LabelWidth = 123;
            this.cb_page.Name = "cb_page";
            this.cb_page.SelectedIndex = -1;
            this.cb_page.Text = "Select page";
            this.cb_page.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            this.cb_page.TextBoxText = "";
            this.cb_page.TextBoxTextChanged += new System.EventHandler(this.cb_page_TextBoxTextChanged);
            this.cb_page.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_page_TextBoxKeyDown);
            // 
            // ribbonItemGroup1
            // 
            this.ribbonItemGroup1.Items.Add(this.btn_previous);
            this.ribbonItemGroup1.Items.Add(this.btn_next);
            this.ribbonItemGroup1.Name = "ribbonItemGroup1";
            this.ribbonItemGroup1.Text = "ribbonItemGroup1";
            this.ribbonItemGroup1.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // btn_previous
            // 
            this.btn_previous.Enabled = false;
            this.btn_previous.Image = global::Labeling.Properties.Resources.arrow_left_32;
            this.btn_previous.LargeImage = global::Labeling.Properties.Resources.arrow_left_32;
            this.btn_previous.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.SmallImage = global::Labeling.Properties.Resources.arrow_left_32;
            this.btn_previous.Text = "ribbonButton6";
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_next
            // 
            this.btn_next.Enabled = false;
            this.btn_next.Image = ((System.Drawing.Image)(resources.GetObject("btn_next.Image")));
            this.btn_next.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_next.LargeImage")));
            this.btn_next.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btn_next.Name = "btn_next";
            this.btn_next.SmallImage = global::Labeling.Properties.Resources.arrow_right_32;
            this.btn_next.Text = "ribbonButton7";
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.chk_askBeforeDelete);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Option";
            // 
            // chk_askBeforeDelete
            // 
            this.chk_askBeforeDelete.Name = "chk_askBeforeDelete";
            this.chk_askBeforeDelete.Text = "Ask before delete";
            this.chk_askBeforeDelete.CheckBoxCheckChanged += new System.EventHandler(this.chk_askBeforeDelete_CheckBoxCheckChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1221, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 2000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.WorkerReportsProgress = true;
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 50;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel1.Location = new System.Drawing.Point(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 510);
            this.panel1.TabIndex = 40;
            this.panel1.WrapContents = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 682);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "Viet OCR labeling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTextBox txt_search;
        private System.Windows.Forms.RibbonOrbRecentItem recentItem1;
        private System.Windows.Forms.RibbonOrbRecentItem recentItem2;
        private System.Windows.Forms.RibbonOrbRecentItem recentItem3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Timer timerClear;
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.Windows.Forms.RibbonOrbMenuItem btn_openFolder;
        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.RibbonButton btn_search;
        private System.Windows.Forms.RibbonButton btn_imageNoLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.RibbonButton btn_delete;
        private System.Windows.Forms.RibbonPanel panel_paging;
        private System.Windows.Forms.RibbonComboBox cb_contentPerPage;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup1;
        private System.Windows.Forms.RibbonButton btn_previous;
        private System.Windows.Forms.RibbonButton btn_next;
        private System.Windows.Forms.RibbonComboBox cb_page;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonCheckBox chk_askBeforeDelete;
        private System.Windows.Forms.RibbonCheckBox chk_selectAll;
    }
}