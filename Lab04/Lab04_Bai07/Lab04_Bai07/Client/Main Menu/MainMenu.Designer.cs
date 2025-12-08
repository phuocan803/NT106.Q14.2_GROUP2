namespace Lab04_Bai07.Client.Main_Menu
{
    partial class MainMenu
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
            this.label_Title = new System.Windows.Forms.Label();
            this.tabControl_Food_List = new System.Windows.Forms.TabControl();
            this.tabPage_All = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel_All = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage_Contribute = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel_MyFood = new System.Windows.Forms.FlowLayoutPanel();
            this.button_Choose_Food = new System.Windows.Forms.Button();
            this.button_Add_Food = new System.Windows.Forms.Button();
            this.comboBox_Page_Size = new System.Windows.Forms.ComboBox();
            this.label_Page_Size = new System.Windows.Forms.Label();
            this.label_Page = new System.Windows.Forms.Label();
            this.comboBox_Page = new System.Windows.Forms.ComboBox();
            this.tabControl_Food_List.SuspendLayout();
            this.tabPage_All.SuspendLayout();
            this.tabPage_Contribute.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Calibri", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_Title.Location = new System.Drawing.Point(162, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(192, 35);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "Hôm nay ăn gì?";
            // 
            // tabControl_Food_List
            // 
            this.tabControl_Food_List.Controls.Add(this.tabPage_All);
            this.tabControl_Food_List.Controls.Add(this.tabPage_Contribute);
            this.tabControl_Food_List.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Food_List.Location = new System.Drawing.Point(12, 51);
            this.tabControl_Food_List.Name = "tabControl_Food_List";
            this.tabControl_Food_List.SelectedIndex = 0;
            this.tabControl_Food_List.Size = new System.Drawing.Size(531, 445);
            this.tabControl_Food_List.TabIndex = 3;
            this.tabControl_Food_List.Click += new System.EventHandler(this.tabControl_Food_List_SelectedIndexChanged);
            // 
            // tabPage_All
            // 
            this.tabPage_All.Controls.Add(this.flowLayoutPanel_All);
            this.tabPage_All.Location = new System.Drawing.Point(4, 24);
            this.tabPage_All.Name = "tabPage_All";
            this.tabPage_All.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_All.Size = new System.Drawing.Size(523, 417);
            this.tabPage_All.TabIndex = 0;
            this.tabPage_All.Text = "All";
            this.tabPage_All.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_All
            // 
            this.flowLayoutPanel_All.AutoScroll = true;
            this.flowLayoutPanel_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_All.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_All.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_All.Name = "flowLayoutPanel_All";
            this.flowLayoutPanel_All.Size = new System.Drawing.Size(517, 411);
            this.flowLayoutPanel_All.TabIndex = 0;
            this.flowLayoutPanel_All.WrapContents = false;
            this.flowLayoutPanel_All.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_All_Paint);
            // 
            // tabPage_Contribute
            // 
            this.tabPage_Contribute.Controls.Add(this.flowLayoutPanel_MyFood);
            this.tabPage_Contribute.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Contribute.Name = "tabPage_Contribute";
            this.tabPage_Contribute.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Contribute.Size = new System.Drawing.Size(523, 417);
            this.tabPage_Contribute.TabIndex = 1;
            this.tabPage_Contribute.Text = "Tôi đóng góp";
            this.tabPage_Contribute.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_MyFood
            // 
            this.flowLayoutPanel_MyFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_MyFood.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_MyFood.Name = "flowLayoutPanel_MyFood";
            this.flowLayoutPanel_MyFood.Size = new System.Drawing.Size(517, 411);
            this.flowLayoutPanel_MyFood.TabIndex = 0;
            this.flowLayoutPanel_MyFood.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_MyFood_Paint);
            // 
            // button_Choose_Food
            // 
            this.button_Choose_Food.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Choose_Food.Location = new System.Drawing.Point(16, 495);
            this.button_Choose_Food.Name = "button_Choose_Food";
            this.button_Choose_Food.Size = new System.Drawing.Size(120, 42);
            this.button_Choose_Food.TabIndex = 4;
            this.button_Choose_Food.Text = "Ăn gì giờ?";
            this.button_Choose_Food.UseVisualStyleBackColor = true;
            this.button_Choose_Food.Click += new System.EventHandler(this.button_Choose_Food_Click);
            // 
            // button_Add_Food
            // 
            this.button_Add_Food.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add_Food.Location = new System.Drawing.Point(142, 495);
            this.button_Add_Food.Name = "button_Add_Food";
            this.button_Add_Food.Size = new System.Drawing.Size(120, 42);
            this.button_Add_Food.TabIndex = 5;
            this.button_Add_Food.Text = "Thêm món";
            this.button_Add_Food.UseVisualStyleBackColor = true;
            this.button_Add_Food.Click += new System.EventHandler(this.button_Add_Food_Click);
            // 
            // comboBox_Page_Size
            // 
            this.comboBox_Page_Size.FormattingEnabled = true;
            this.comboBox_Page_Size.Location = new System.Drawing.Point(489, 507);
            this.comboBox_Page_Size.Name = "comboBox_Page_Size";
            this.comboBox_Page_Size.Size = new System.Drawing.Size(50, 21);
            this.comboBox_Page_Size.TabIndex = 6;
            this.comboBox_Page_Size.Click += new System.EventHandler(this.comboBox_Page_Size_SelectedIndexChanged);
            // 
            // label_Page_Size
            // 
            this.label_Page_Size.AutoSize = true;
            this.label_Page_Size.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Page_Size.Location = new System.Drawing.Point(417, 507);
            this.label_Page_Size.Name = "label_Page_Size";
            this.label_Page_Size.Size = new System.Drawing.Size(61, 17);
            this.label_Page_Size.TabIndex = 7;
            this.label_Page_Size.Text = "Page Size";
            // 
            // label_Page
            // 
            this.label_Page.AutoSize = true;
            this.label_Page.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Page.Location = new System.Drawing.Point(317, 507);
            this.label_Page.Name = "label_Page";
            this.label_Page.Size = new System.Drawing.Size(36, 17);
            this.label_Page.TabIndex = 8;
            this.label_Page.Text = "Page";
            // 
            // comboBox_Page
            // 
            this.comboBox_Page.FormattingEnabled = true;
            this.comboBox_Page.Location = new System.Drawing.Point(361, 507);
            this.comboBox_Page.Name = "comboBox_Page";
            this.comboBox_Page.Size = new System.Drawing.Size(50, 21);
            this.comboBox_Page.TabIndex = 9;
            this.comboBox_Page.Click += new System.EventHandler(this.comboBox_Page_SelectedIndexChanged);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 547);
            this.Controls.Add(this.comboBox_Page);
            this.Controls.Add(this.label_Page);
            this.Controls.Add(this.label_Page_Size);
            this.Controls.Add(this.comboBox_Page_Size);
            this.Controls.Add(this.button_Add_Food);
            this.Controls.Add(this.button_Choose_Food);
            this.Controls.Add(this.tabControl_Food_List);
            this.Controls.Add(this.label_Title);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.tabControl_Food_List.ResumeLayout(false);
            this.tabPage_All.ResumeLayout(false);
            this.tabPage_Contribute.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TabControl tabControl_Food_List;
        private System.Windows.Forms.TabPage tabPage_All;
        private System.Windows.Forms.TabPage tabPage_Contribute;
        private System.Windows.Forms.Button button_Choose_Food;
        private System.Windows.Forms.Button button_Add_Food;
        private System.Windows.Forms.ComboBox comboBox_Page_Size;
        private System.Windows.Forms.Label label_Page_Size;
        private System.Windows.Forms.Label label_Page;
        private System.Windows.Forms.ComboBox comboBox_Page;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_All;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_MyFood;
    }
}