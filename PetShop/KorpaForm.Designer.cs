namespace PetShop
{
    partial class KorpaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorpaForm));
            this.nazadButton = new System.Windows.Forms.Button();
            this.napredButton = new System.Windows.Forms.Button();
            this.ukloniButton = new System.Windows.Forms.Button();
            this.naruciButton = new System.Windows.Forms.Button();
            this.tbCijena = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nazadButton
            // 
            resources.ApplyResources(this.nazadButton, "nazadButton");
            this.nazadButton.Name = "nazadButton";
            this.nazadButton.UseVisualStyleBackColor = true;
            this.nazadButton.Click += new System.EventHandler(this.nazadButton_Click);
            // 
            // napredButton
            // 
            resources.ApplyResources(this.napredButton, "napredButton");
            this.napredButton.Name = "napredButton";
            this.napredButton.UseVisualStyleBackColor = true;
            this.napredButton.Click += new System.EventHandler(this.napredButton_Click);
            // 
            // ukloniButton
            // 
            resources.ApplyResources(this.ukloniButton, "ukloniButton");
            this.ukloniButton.Name = "ukloniButton";
            this.ukloniButton.UseVisualStyleBackColor = true;
            this.ukloniButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // naruciButton
            // 
            resources.ApplyResources(this.naruciButton, "naruciButton");
            this.naruciButton.Name = "naruciButton";
            this.naruciButton.UseVisualStyleBackColor = true;
            this.naruciButton.Click += new System.EventHandler(this.naruciButton_Click);
            // 
            // tbCijena
            // 
            resources.ApplyResources(this.tbCijena, "tbCijena");
            this.tbCijena.Name = "tbCijena";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // KorpaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbCijena);
            this.Controls.Add(this.naruciButton);
            this.Controls.Add(this.ukloniButton);
            this.Controls.Add(this.napredButton);
            this.Controls.Add(this.nazadButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KorpaForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button nazadButton;
        private System.Windows.Forms.Button napredButton;
        private System.Windows.Forms.Button ukloniButton;
        private System.Windows.Forms.Button naruciButton;
        private System.Windows.Forms.TextBox tbCijena;
    }
}