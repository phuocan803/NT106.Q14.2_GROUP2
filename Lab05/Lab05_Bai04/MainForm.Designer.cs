namespace Lab05_Bai04
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Button_Load = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.TextBox_URL = new System.Windows.Forms.TextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Load
            // 
            this.Button_Load.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Load.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Button_Load.ForeColor = System.Drawing.Color.Navy;
            this.Button_Load.Location = new System.Drawing.Point(760, 40);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(210, 50);
            this.Button_Load.TabIndex = 1;
            this.Button_Load.Text = "Load Server";
            this.Button_Load.UseVisualStyleBackColor = false;
            this.Button_Load.Click += new System.EventHandler(this.btnLoadMovies_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.flowLayoutPanelMovies);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(30, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 390);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movies";
            // 
            // flowLayoutPanelMovies
            // 
            this.flowLayoutPanelMovies.AutoScroll = true;
            this.flowLayoutPanelMovies.Location = new System.Drawing.Point(10, 30);
            this.flowLayoutPanelMovies.Name = "flowLayoutPanelMovies";
            this.flowLayoutPanelMovies.Size = new System.Drawing.Size(920, 350);
            this.flowLayoutPanelMovies.TabIndex = 0;
            // 
            // TextBox_URL
            // 
            this.TextBox_URL.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.TextBox_URL.Location = new System.Drawing.Point(30, 45);
            this.TextBox_URL.Name = "TextBox_URL";
            this.TextBox_URL.Size = new System.Drawing.Size(710, 30);
            this.TextBox_URL.TabIndex = 0;
            this.TextBox_URL.Text = "https://betacinemas.vn/phim.htm";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(30, 100);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(710, 23);
            this.ProgressBar.TabIndex = 3;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1020, 580);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.TextBox_URL);
            this.Controls.Add(this.Button_Load);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Movie Booking";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button_Load;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMovies;
        private System.Windows.Forms.TextBox TextBox_URL;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}
