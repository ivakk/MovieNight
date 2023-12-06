namespace MovieNightOOD
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            button1 = new Button();
            usernameEntry = new TextBox();
            label1 = new Label();
            label2 = new Label();
            passwordEntry = new TextBox();
            label3 = new Label();
            reveal = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)reveal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(259, 259);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(165, 43);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // usernameEntry
            // 
            usernameEntry.Location = new Point(259, 182);
            usernameEntry.Margin = new Padding(3, 2, 3, 2);
            usernameEntry.Name = "usernameEntry";
            usernameEntry.Size = new Size(199, 23);
            usernameEntry.TabIndex = 1;
            usernameEntry.TextChanged += usernameEntry_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 184);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 217);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // passwordEntry
            // 
            passwordEntry.Location = new Point(259, 214);
            passwordEntry.Margin = new Padding(3, 2, 3, 2);
            passwordEntry.Name = "passwordEntry";
            passwordEntry.Size = new Size(199, 23);
            passwordEntry.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(306, 149);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 6;
            label3.Text = "Welcome!";
            label3.Click += label3_Click;
            // 
            // reveal
            // 
            reveal.Image = Properties.Resources.show;
            reveal.Location = new Point(464, 214);
            reveal.Name = "reveal";
            reveal.Size = new Size(25, 23);
            reveal.TabIndex = 7;
            reveal.TabStop = false;
            reveal.MouseDown += reveal_MouseDown;
            reveal.MouseUp += reveal_MouseUp;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_movienight;
            pictureBox1.Location = new Point(133, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(436, 103);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(pictureBox1);
            Controls.Add(reveal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordEntry);
            Controls.Add(label1);
            Controls.Add(usernameEntry);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MovieNight";
            Load += login_Load;
            ((System.ComponentModel.ISupportInitialize)reveal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox usernameEntry;
        private Label label1;
        private Label label2;
        private TextBox passwordEntry;
        private Label label3;
        private PictureBox reveal;
        private PictureBox pictureBox1;
    }
}