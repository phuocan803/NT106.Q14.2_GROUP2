namespace Lab04
{
    partial class Lab04_Bai03
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
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDownFiles = new System.Windows.Forms.Button();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnDownResources = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.SuspendLayout();
            // 
            // webView2
            // 
            this.webView2.AllowExternalDrop = true;
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Location = new System.Drawing.Point(25, 49);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(895, 592);
            this.webView2.TabIndex = 0;
            this.webView2.ZoomFactor = 1D;
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(124, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(351, 24);
            this.txtUrl.TabIndex = 6;
            this.txtUrl.Text = "http://uit.edu.vn";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnLoad.Location = new System.Drawing.Point(23, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 28);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDownFiles
            // 
            this.btnDownFiles.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnDownFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownFiles.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnDownFiles.Location = new System.Drawing.Point(592, 12);
            this.btnDownFiles.Name = "btnDownFiles";
            this.btnDownFiles.Size = new System.Drawing.Size(134, 28);
            this.btnDownFiles.TabIndex = 8;
            this.btnDownFiles.Text = "DOWN FILES";
            this.btnDownFiles.UseVisualStyleBackColor = false;
            this.btnDownFiles.Click += new System.EventHandler(this.btnDownFiles_Click);
            // 
            // btnReLoad
            // 
            this.btnReLoad.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnReLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReLoad.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnReLoad.Location = new System.Drawing.Point(489, 12);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(90, 28);
            this.btnReLoad.TabIndex = 9;
            this.btnReLoad.Text = "RELOAD";
            this.btnReLoad.UseVisualStyleBackColor = false;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnDownResources
            // 
            this.btnDownResources.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnDownResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownResources.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnDownResources.Location = new System.Drawing.Point(740, 13);
            this.btnDownResources.Name = "btnDownResources";
            this.btnDownResources.Size = new System.Drawing.Size(180, 28);
            this.btnDownResources.TabIndex = 10;
            this.btnDownResources.Text = "DOWN RESOURCES";
            this.btnDownResources.UseVisualStyleBackColor = false;
            this.btnDownResources.Click += new System.EventHandler(this.btnDownResources_Click);
            // 
            // Lab04_Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 667);
            this.Controls.Add(this.btnDownResources);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.btnDownFiles);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webView2);
            this.Name = "Lab04_Bai03";
            this.Text = "Lab04_Bai03";
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDownFiles;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnDownResources;
    }
}