namespace MasterMInd
{
    partial class Form1
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
            this.ColorChooser = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Single = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.AIButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColorChooser
            // 
            this.ColorChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorChooser.FormattingEnabled = true;
            this.ColorChooser.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Yellow",
            "Green",
            "White",
            "Black"});
            this.ColorChooser.Location = new System.Drawing.Point(151, 13);
            this.ColorChooser.Name = "ColorChooser";
            this.ColorChooser.Size = new System.Drawing.Size(121, 21);
            this.ColorChooser.TabIndex = 0;
            this.ColorChooser.SelectedIndexChanged += new System.EventHandler(this.ColorChooser_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // Single
            // 
            this.Single.Location = new System.Drawing.Point(109, 107);
            this.Single.Name = "Single";
            this.Single.Size = new System.Drawing.Size(77, 23);
            this.Single.TabIndex = 3;
            this.Single.Text = "Single Player";
            this.Single.UseVisualStyleBackColor = true;
            this.Single.Click += new System.EventHandler(this.Single_Click);
            // 
            // Two
            // 
            this.Two.Location = new System.Drawing.Point(109, 150);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(77, 23);
            this.Two.TabIndex = 5;
            this.Two.Text = "Two Player";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.Two_Click);
            // 
            // AIButton
            // 
            this.AIButton.Location = new System.Drawing.Point(109, 195);
            this.AIButton.Name = "AIButton";
            this.AIButton.Size = new System.Drawing.Size(77, 51);
            this.AIButton.TabIndex = 6;
            this.AIButton.Text = "Have Computer Guess!";
            this.AIButton.UseVisualStyleBackColor = true;
            this.AIButton.Click += new System.EventHandler(this.AIButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(340, 425);
            this.Controls.Add(this.AIButton);
            this.Controls.Add(this.Two);
            this.Controls.Add(this.Single);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ColorChooser);
            this.Name = "Form1";
            this.Text = "MasterMind";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ColorChooser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Single;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button AIButton;
    }
}

