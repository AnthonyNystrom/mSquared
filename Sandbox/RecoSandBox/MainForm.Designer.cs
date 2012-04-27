namespace SURFFeature
{
    partial class MainForm
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
            this.pnlModelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMatchedImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSelectObservedImage = new System.Windows.Forms.Button();
            this.btnLoadModelImage = new System.Windows.Forms.Button();
            this.modelFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.observedOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlObservedImage = new System.Windows.Forms.Panel();
            this.picBoxObserved = new System.Windows.Forms.PictureBox();
            this.pnlAction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlObservedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxObserved)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlModelImages
            // 
            this.pnlModelImages.AutoScroll = true;
            this.pnlModelImages.BackColor = System.Drawing.Color.Silver;
            this.pnlModelImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelImages.Location = new System.Drawing.Point(0, 0);
            this.pnlModelImages.Name = "pnlModelImages";
            this.pnlModelImages.Size = new System.Drawing.Size(680, 245);
            this.pnlModelImages.TabIndex = 0;
            // 
            // pnlMatchedImages
            // 
            this.pnlMatchedImages.AutoScroll = true;
            this.pnlMatchedImages.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlMatchedImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMatchedImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMatchedImages.Location = new System.Drawing.Point(5, 250);
            this.pnlMatchedImages.Name = "pnlMatchedImages";
            this.pnlMatchedImages.Size = new System.Drawing.Size(936, 291);
            this.pnlMatchedImages.TabIndex = 1;
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.progressBar);
            this.pnlAction.Controls.Add(this.btnStart);
            this.pnlAction.Controls.Add(this.btnSelectObservedImage);
            this.pnlAction.Controls.Add(this.btnLoadModelImage);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(5, 541);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(936, 33);
            this.pnlAction.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(282, 6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(516, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(804, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(129, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Detection";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSelectObservedImage
            // 
            this.btnSelectObservedImage.Location = new System.Drawing.Point(147, 6);
            this.btnSelectObservedImage.Name = "btnSelectObservedImage";
            this.btnSelectObservedImage.Size = new System.Drawing.Size(129, 23);
            this.btnSelectObservedImage.TabIndex = 1;
            this.btnSelectObservedImage.Text = "Select Observed Image";
            this.btnSelectObservedImage.UseVisualStyleBackColor = true;
            this.btnSelectObservedImage.Click += new System.EventHandler(this.btnSelectObservedImage_Click);
            // 
            // btnLoadModelImage
            // 
            this.btnLoadModelImage.Location = new System.Drawing.Point(12, 6);
            this.btnLoadModelImage.Name = "btnLoadModelImage";
            this.btnLoadModelImage.Size = new System.Drawing.Size(129, 23);
            this.btnLoadModelImage.TabIndex = 0;
            this.btnLoadModelImage.Text = "Load Model Images";
            this.btnLoadModelImage.UseVisualStyleBackColor = true;
            this.btnLoadModelImage.Click += new System.EventHandler(this.btnLoadModelImage_Click);
            // 
            // modelFolderDialog
            // 
            this.modelFolderDialog.SelectedPath = "D:\\MS\\Thesis stuff\\Sandbox\\models";
            // 
            // observedOpenFileDialog
            // 
            this.observedOpenFileDialog.Filter = "All Files | *.*";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlModelImages);
            this.panel1.Controls.Add(this.pnlObservedImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 245);
            this.panel1.TabIndex = 3;
            // 
            // pnlObservedImage
            // 
            this.pnlObservedImage.BackColor = System.Drawing.Color.DimGray;
            this.pnlObservedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObservedImage.Controls.Add(this.picBoxObserved);
            this.pnlObservedImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlObservedImage.Location = new System.Drawing.Point(680, 0);
            this.pnlObservedImage.Name = "pnlObservedImage";
            this.pnlObservedImage.Size = new System.Drawing.Size(256, 245);
            this.pnlObservedImage.TabIndex = 1;
            // 
            // picBoxObserved
            // 
            this.picBoxObserved.BackColor = System.Drawing.Color.White;
            this.picBoxObserved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxObserved.Location = new System.Drawing.Point(0, 0);
            this.picBoxObserved.Name = "picBoxObserved";
            this.picBoxObserved.Size = new System.Drawing.Size(254, 243);
            this.picBoxObserved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxObserved.TabIndex = 0;
            this.picBoxObserved.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 579);
            this.Controls.Add(this.pnlMatchedImages);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAction);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlObservedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxObserved)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlModelImages;
        private System.Windows.Forms.FlowLayoutPanel pnlMatchedImages;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnLoadModelImage;
        private System.Windows.Forms.FolderBrowserDialog modelFolderDialog;
        private System.Windows.Forms.Button btnSelectObservedImage;
        private System.Windows.Forms.OpenFileDialog observedOpenFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlObservedImage;
        private System.Windows.Forms.PictureBox picBoxObserved;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;        
    }
}