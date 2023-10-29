namespace MovieNightOOD
{
    partial class Form1
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
            button1 = new Button();
            usernameEntry = new TextBox();
            label1 = new Label();
            label2 = new Label();
            passwordEntry = new TextBox();
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
            usernameEntry.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 184);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 217);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            label2.Click += label2_Click;
            // 
            // passwordEntry
            // 
            passwordEntry.Location = new Point(259, 214);
            passwordEntry.Margin = new Padding(3, 2, 3, 2);
            passwordEntry.Name = "passwordEntry";
            passwordEntry.Size = new Size(199, 23);
            passwordEntry.TabIndex = 3;
            passwordEntry.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label2);
            Controls.Add(passwordEntry);
            Controls.Add(label1);
            Controls.Add(usernameEntry);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "MovieNight";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox usernameEntry;
        private Label label1;
        private Label label2;
        private TextBox passwordEntry;
    }
}