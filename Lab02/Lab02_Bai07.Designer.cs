namespace NT106_Lab02
{
    partial class Lab02_Bai07
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
            this.treeView_files = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.richTextBox_content = new System.Windows.Forms.RichTextBox();
            this.label_file_content = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_files
            // 
            this.treeView_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_files.ImageIndex = 0;
            this.treeView_files.ImageList = this.imageList;
            this.treeView_files.Location = new System.Drawing.Point(0, 0);
            this.treeView_files.Name = "treeView_files";
            this.treeView_files.SelectedImageIndex = 0;
            this.treeView_files.Size = new System.Drawing.Size(350, 561);
            this.treeView_files.TabIndex = 0;
            this.treeView_files.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_files_BeforeExpand);
            this.treeView_files.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_files_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_preview.Location = new System.Drawing.Point(0, 27);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(634, 534);
            this.pictureBox_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_preview.TabIndex = 1;
            this.pictureBox_preview.TabStop = false;
            this.pictureBox_preview.Visible = false;
            // 
            // richTextBox_content
            // 
            this.richTextBox_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_content.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_content.Location = new System.Drawing.Point(0, 27);
            this.richTextBox_content.Name = "richTextBox_content";
            this.richTextBox_content.ReadOnly = true;
            this.richTextBox_content.Size = new System.Drawing.Size(634, 534);
            this.richTextBox_content.TabIndex = 2;
            this.richTextBox_content.Text = "";
            // 
            // label_file_content
            // 
            this.label_file_content.AutoSize = true;
            this.label_file_content.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_file_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_file_content.Location = new System.Drawing.Point(0, 0);
            this.label_file_content.Name = "label_file_content";
            this.label_file_content.Padding = new System.Windows.Forms.Padding(5);
            this.label_file_content.Size = new System.Drawing.Size(105, 27);
            this.label_file_content.TabIndex = 3;
            this.label_file_content.Text = "File Content";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView_files);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.richTextBox_content);
            this.splitContainer.Panel2.Controls.Add(this.pictureBox_preview);
            this.splitContainer.Panel2.Controls.Add(this.label_file_content);
            this.splitContainer.Size = new System.Drawing.Size(988, 561);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.TabIndex = 4;
            // 
            // Lab02_Bai07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 561);
            this.Controls.Add(this.splitContainer);
            this.Name = "Lab02_Bai07";
            this.Text = "Lab02 Bai07 - File Explorer";
            this.Load += new System.EventHandler(this.Lab02_Bai07_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_files;
        private System.Windows.Forms.PictureBox pictureBox_preview;
        private System.Windows.Forms.RichTextBox richTextBox_content;
        private System.Windows.Forms.Label label_file_content;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList imageList;
    }
}