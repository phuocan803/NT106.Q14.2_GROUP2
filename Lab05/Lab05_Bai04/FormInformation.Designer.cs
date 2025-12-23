namespace Lab05_Bai04
{
    partial class FormInformation
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
            this.Button_Book = new System.Windows.Forms.Button();
            this.Label_Ticket = new System.Windows.Forms.Label();
            this.TextBox_Genre = new System.Windows.Forms.TextBox();
            this.Label_Genre = new System.Windows.Forms.Label();
            this.TextBox_Customer = new System.Windows.Forms.TextBox();
            this.Label_Customer = new System.Windows.Forms.Label();
            this.Label_Title = new System.Windows.Forms.Label();
            this.PictureBox_Movie = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_Duration = new System.Windows.Forms.TextBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBox_Email = new System.Windows.Forms.TextBox();
            this.ComboBox_Seat = new System.Windows.Forms.ComboBox();
            this.ComboBox_Room = new System.Windows.Forms.ComboBox();
            this.ComboBox_Time = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Movie)).BeginInit();
            this.groupBoxDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Book
            // 
            this.Button_Book.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Book.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Button_Book.ForeColor = System.Drawing.Color.Navy;
            this.Button_Book.Location = new System.Drawing.Point(890, 119);
            this.Button_Book.Name = "Button_Book";
            this.Button_Book.Size = new System.Drawing.Size(178, 55);
            this.Button_Book.TabIndex = 8;
            this.Button_Book.Text = "Book";
            this.Button_Book.UseVisualStyleBackColor = false;
            this.Button_Book.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // Label_Ticket
            // 
            this.Label_Ticket.AutoSize = true;
            this.Label_Ticket.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Label_Ticket.Location = new System.Drawing.Point(365, 376);
            this.Label_Ticket.Name = "Label_Ticket";
            this.Label_Ticket.Size = new System.Drawing.Size(55, 25);
            this.Label_Ticket.TabIndex = 6;
            this.Label_Ticket.Text = "Seat:";
            // 
            // TextBox_Genre
            // 
            this.TextBox_Genre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TextBox_Genre.Location = new System.Drawing.Point(500, 169);
            this.TextBox_Genre.Name = "TextBox_Genre";
            this.TextBox_Genre.ReadOnly = true;
            this.TextBox_Genre.Size = new System.Drawing.Size(330, 30);
            this.TextBox_Genre.TabIndex = 5;
            // 
            // Label_Genre
            // 
            this.Label_Genre.AutoSize = true;
            this.Label_Genre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Label_Genre.Location = new System.Drawing.Point(365, 169);
            this.Label_Genre.Name = "Label_Genre";
            this.Label_Genre.Size = new System.Drawing.Size(71, 25);
            this.Label_Genre.TabIndex = 4;
            this.Label_Genre.Text = "Genre:";
            // 
            // TextBox_Customer
            // 
            this.TextBox_Customer.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TextBox_Customer.Location = new System.Drawing.Point(500, 119);
            this.TextBox_Customer.Name = "TextBox_Customer";
            this.TextBox_Customer.Size = new System.Drawing.Size(330, 30);
            this.TextBox_Customer.TabIndex = 3;
            // 
            // Label_Customer
            // 
            this.Label_Customer.AutoSize = true;
            this.Label_Customer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Label_Customer.Location = new System.Drawing.Point(365, 119);
            this.Label_Customer.Name = "Label_Customer";
            this.Label_Customer.Size = new System.Drawing.Size(104, 25);
            this.Label_Customer.TabIndex = 2;
            this.Label_Customer.Text = "Customer:";
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.Label_Title.Location = new System.Drawing.Point(365, 47);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(178, 41);
            this.Label_Title.TabIndex = 1;
            this.Label_Title.Text = "Movie Title";
            // 
            // PictureBox_Movie
            // 
            this.PictureBox_Movie.Location = new System.Drawing.Point(44, 58);
            this.PictureBox_Movie.Name = "PictureBox_Movie";
            this.PictureBox_Movie.Size = new System.Drawing.Size(300, 450);
            this.PictureBox_Movie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Movie.TabIndex = 0;
            this.PictureBox_Movie.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(495, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Price:";
            // 
            // TextBox_Price
            // 
            this.TextBox_Price.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TextBox_Price.Location = new System.Drawing.Point(576, 505);
            this.TextBox_Price.Name = "TextBox_Price";
            this.TextBox_Price.ReadOnly = true;
            this.TextBox_Price.Size = new System.Drawing.Size(254, 30);
            this.TextBox_Price.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(365, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Duration:";
            // 
            // TextBox_Duration
            // 
            this.TextBox_Duration.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TextBox_Duration.Location = new System.Drawing.Point(500, 216);
            this.TextBox_Duration.Name = "TextBox_Duration";
            this.TextBox_Duration.ReadOnly = true;
            this.TextBox_Duration.Size = new System.Drawing.Size(330, 30);
            this.TextBox_Duration.TabIndex = 12;
            // 
            // Button_Save
            // 
            this.Button_Save.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Save.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Button_Save.ForeColor = System.Drawing.Color.Navy;
            this.Button_Save.Location = new System.Drawing.Point(890, 402);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(178, 55);
            this.Button_Save.TabIndex = 13;
            this.Button_Save.Text = "Save JSON";
            this.Button_Save.UseVisualStyleBackColor = false;
            this.Button_Save.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBoxDetail.Controls.Add(this.label5);
            this.groupBoxDetail.Controls.Add(this.TextBox_Email);
            this.groupBoxDetail.Controls.Add(this.ComboBox_Seat);
            this.groupBoxDetail.Controls.Add(this.ComboBox_Room);
            this.groupBoxDetail.Controls.Add(this.ComboBox_Time);
            this.groupBoxDetail.Controls.Add(this.label4);
            this.groupBoxDetail.Controls.Add(this.label3);
            this.groupBoxDetail.Controls.Add(this.Button_Save);
            this.groupBoxDetail.Controls.Add(this.TextBox_Duration);
            this.groupBoxDetail.Controls.Add(this.label2);
            this.groupBoxDetail.Controls.Add(this.TextBox_Price);
            this.groupBoxDetail.Controls.Add(this.label1);
            this.groupBoxDetail.Controls.Add(this.PictureBox_Movie);
            this.groupBoxDetail.Controls.Add(this.Label_Title);
            this.groupBoxDetail.Controls.Add(this.Label_Customer);
            this.groupBoxDetail.Controls.Add(this.TextBox_Customer);
            this.groupBoxDetail.Controls.Add(this.Label_Genre);
            this.groupBoxDetail.Controls.Add(this.TextBox_Genre);
            this.groupBoxDetail.Controls.Add(this.Label_Ticket);
            this.groupBoxDetail.Controls.Add(this.Button_Book);
            this.groupBoxDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetail.ForeColor = System.Drawing.Color.Navy;
            this.groupBoxDetail.Location = new System.Drawing.Point(40, 60);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(1200, 608);
            this.groupBoxDetail.TabIndex = 0;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Movie Detail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(365, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // TextBox_Email
            // 
            this.TextBox_Email.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TextBox_Email.Location = new System.Drawing.Point(500, 427);
            this.TextBox_Email.Name = "TextBox_Email";
            this.TextBox_Email.Size = new System.Drawing.Size(330, 30);
            this.TextBox_Email.TabIndex = 1;
            // 
            // ComboBox_Seat
            // 
            this.ComboBox_Seat.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ComboBox_Seat.Location = new System.Drawing.Point(500, 376);
            this.ComboBox_Seat.Name = "ComboBox_Seat";
            this.ComboBox_Seat.Size = new System.Drawing.Size(330, 31);
            this.ComboBox_Seat.TabIndex = 2;
            // 
            // ComboBox_Room
            // 
            this.ComboBox_Room.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ComboBox_Room.Location = new System.Drawing.Point(500, 322);
            this.ComboBox_Room.Name = "ComboBox_Room";
            this.ComboBox_Room.Size = new System.Drawing.Size(330, 31);
            this.ComboBox_Room.TabIndex = 3;
            // 
            // ComboBox_Time
            // 
            this.ComboBox_Time.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ComboBox_Time.Location = new System.Drawing.Point(500, 268);
            this.ComboBox_Time.Name = "ComboBox_Time";
            this.ComboBox_Time.Size = new System.Drawing.Size(330, 31);
            this.ComboBox_Time.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(367, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Room:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(365, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time:";
            // 
            // MovieDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(1288, 714);
            this.Controls.Add(this.groupBoxDetail);
            this.Name = "MovieDetailForm";
            this.Text = "Movie Detail";
            this.Load += new System.EventHandler(this.MovieDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Movie)).EndInit();
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_Book;
        private System.Windows.Forms.Label Label_Ticket;
        private System.Windows.Forms.TextBox TextBox_Genre;
        private System.Windows.Forms.Label Label_Genre;
        private System.Windows.Forms.TextBox TextBox_Customer;
        private System.Windows.Forms.Label Label_Customer;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.PictureBox PictureBox_Movie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_Duration;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBox_Room;
        private System.Windows.Forms.ComboBox ComboBox_Time;
        private System.Windows.Forms.ComboBox ComboBox_Seat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBox_Email;
    }
}
