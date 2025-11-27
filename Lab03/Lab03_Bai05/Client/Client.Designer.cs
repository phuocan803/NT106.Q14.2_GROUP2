namespace Bai05
{
    partial class ClientForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFoodName = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPermission = new System.Windows.Forms.TextBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.lblSelectedImage = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMyFoods = new System.Windows.Forms.Button();
            this.btnCommunityFoods = new System.Windows.Forms.Button();
            this.listViewFoods = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRandomMyFood = new System.Windows.Forms.Button();
            this.btnRandomCommunity = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(41, 23);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(143, 42);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(38, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Món ăn";
            // 
            // textBoxFoodName
            // 
            this.textBoxFoodName.Location = new System.Drawing.Point(41, 275);
            this.textBoxFoodName.Name = "textBoxFoodName";
            this.textBoxFoodName.Size = new System.Drawing.Size(143, 22);
            this.textBoxFoodName.TabIndex = 2;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(41, 127);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(143, 22);
            this.textBoxUserName.TabIndex = 3;
            // 
            // textBoxPermission
            // 
            this.textBoxPermission.Location = new System.Drawing.Point(41, 201);
            this.textBoxPermission.Name = "textBoxPermission";
            this.textBoxPermission.Size = new System.Drawing.Size(143, 22);
            this.textBoxPermission.TabIndex = 4;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(41, 347);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(143, 30);
            this.btnChooseImage.TabIndex = 5;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // lblSelectedImage
            // 
            this.lblSelectedImage.AutoSize = true;
            this.lblSelectedImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblSelectedImage.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblSelectedImage.Location = new System.Drawing.Point(204, 61);
            this.lblSelectedImage.Name = "lblSelectedImage";
            this.lblSelectedImage.Size = new System.Drawing.Size(38, 20);
            this.lblSelectedImage.TabIndex = 6;
            this.lblSelectedImage.Text = "Ảnh";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBoxPreview.Location = new System.Drawing.Point(208, 102);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(334, 244);
            this.pictureBoxPreview.TabIndex = 7;
            this.pictureBoxPreview.TabStop = false;
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddFood.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.Color.White;
            this.btnAddFood.Location = new System.Drawing.Point(41, 392);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(143, 47);
            this.btnAddFood.TabIndex = 8;
            this.btnAddFood.Text = "Thêm";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(544, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Danh sách món ăn";
            // 
            // btnMyFoods
            // 
            this.btnMyFoods.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMyFoods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyFoods.ForeColor = System.Drawing.Color.White;
            this.btnMyFoods.Location = new System.Drawing.Point(785, 54);
            this.btnMyFoods.Name = "btnMyFoods";
            this.btnMyFoods.Size = new System.Drawing.Size(161, 35);
            this.btnMyFoods.TabIndex = 10;
            this.btnMyFoods.Text = "Dữ liệu của tôi";
            this.btnMyFoods.UseVisualStyleBackColor = false;
            this.btnMyFoods.Click += new System.EventHandler(this.btnMyFoods_Click);
            // 
            // btnCommunityFoods
            // 
            this.btnCommunityFoods.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCommunityFoods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommunityFoods.ForeColor = System.Drawing.Color.White;
            this.btnCommunityFoods.Location = new System.Drawing.Point(963, 54);
            this.btnCommunityFoods.Name = "btnCommunityFoods";
            this.btnCommunityFoods.Size = new System.Drawing.Size(158, 35);
            this.btnCommunityFoods.TabIndex = 11;
            this.btnCommunityFoods.Text = "Dữ liệu cộng đồng";
            this.btnCommunityFoods.UseVisualStyleBackColor = false;
            this.btnCommunityFoods.Click += new System.EventHandler(this.btnCommunityFoods_Click);
            // 
            // listViewFoods
            // 
            this.listViewFoods.FullRowSelect = true;
            this.listViewFoods.HideSelection = false;
            this.listViewFoods.Location = new System.Drawing.Point(548, 102);
            this.listViewFoods.Name = "listViewFoods";
            this.listViewFoods.Size = new System.Drawing.Size(573, 244);
            this.listViewFoods.TabIndex = 12;
            this.listViewFoods.UseCompatibleStateImageBehavior = false;
            this.listViewFoods.View = System.Windows.Forms.View.Details;
            this.listViewFoods.SelectedIndexChanged += new System.EventHandler(this.listViewFoods_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(544, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Random chọn";
            // 
            // btnRandomMyFood
            // 
            this.btnRandomMyFood.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRandomMyFood.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomMyFood.ForeColor = System.Drawing.Color.White;
            this.btnRandomMyFood.Location = new System.Drawing.Point(831, 392);
            this.btnRandomMyFood.Name = "btnRandomMyFood";
            this.btnRandomMyFood.Size = new System.Drawing.Size(209, 34);
            this.btnRandomMyFood.TabIndex = 14;
            this.btnRandomMyFood.Text = "Random của tôi";
            this.btnRandomMyFood.UseVisualStyleBackColor = false;
            this.btnRandomMyFood.Click += new System.EventHandler(this.btnRandomMyFood_Click);
            // 
            // btnRandomCommunity
            // 
            this.btnRandomCommunity.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRandomCommunity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomCommunity.ForeColor = System.Drawing.Color.White;
            this.btnRandomCommunity.Location = new System.Drawing.Point(831, 432);
            this.btnRandomCommunity.Name = "btnRandomCommunity";
            this.btnRandomCommunity.Size = new System.Drawing.Size(209, 34);
            this.btnRandomCommunity.TabIndex = 15;
            this.btnRandomCommunity.Text = "Random cộng đồng";
            this.btnRandomCommunity.UseVisualStyleBackColor = false;
            this.btnRandomCommunity.Click += new System.EventHandler(this.btnRandomCommunity_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(479, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kết quả";
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBoxResult.Location = new System.Drawing.Point(548, 392);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(277, 168);
            this.pictureBoxResult.TabIndex = 18;
            this.pictureBoxResult.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(38, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Người dùng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Location = new System.Drawing.Point(38, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Quyền truy cập";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAll.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAll.Location = new System.Drawing.Point(41, 459);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(143, 40);
            this.btnDeleteAll.TabIndex = 21;
            this.btnDeleteAll.Text = "Xóa dữ liệu";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.BackColor = System.Drawing.Color.White;
            this.labelResult.Location = new System.Drawing.Point(839, 539);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 16);
            this.labelResult.TabIndex = 22;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 589);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRandomCommunity);
            this.Controls.Add(this.btnRandomMyFood);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewFoods);
            this.Controls.Add(this.btnCommunityFoods);
            this.Controls.Add(this.btnMyFoods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.lblSelectedImage);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.textBoxPermission);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxFoodName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDeleteAll);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFoodName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPermission;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Label lblSelectedImage;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMyFoods;
        private System.Windows.Forms.Button btnCommunityFoods;
        private System.Windows.Forms.ListView listViewFoods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRandomMyFood;
        private System.Windows.Forms.Button btnRandomCommunity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label labelResult;
    }
}

