namespace MovieNightOOD.UserControls
{
    partial class MenuButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button = new Button();
            SuspendLayout();
            // 
            // Button
            // 
            Button.BackColor = Color.FromArgb(117, 54, 112);
            Button.FlatStyle = FlatStyle.Flat;
            Button.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            Button.ForeColor = Color.WhiteSmoke;
            Button.Location = new Point(0, 0);
            Button.Name = "Button";
            Button.Size = new Size(283, 60);
            Button.TabIndex = 1;
            Button.Text = "Logout";
            Button.UseVisualStyleBackColor = false;
            Button.Click += Button_Click;
            // 
            // MenuButton
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Button);
            Name = "MenuButton";
            Size = new Size(283, 60);
            ResumeLayout(false);
        }

        #endregion

        private Button Button;
    }
}
