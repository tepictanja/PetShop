namespace PetShop
{
    partial class AzurirajCijenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AzurirajCijenuForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCijena = new System.Windows.Forms.TextBox();
            this.buttonAzuriraj = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(21)))), ((int)(((byte)(150)))));
            this.label1.Name = "label1";
            // 
            // tbSifra
            // 
            resources.ApplyResources(this.tbSifra, "tbSifra");
            this.tbSifra.Name = "tbSifra";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(21)))), ((int)(((byte)(150)))));
            this.label2.Name = "label2";
            // 
            // tbCijena
            // 
            resources.ApplyResources(this.tbCijena, "tbCijena");
            this.tbCijena.Name = "tbCijena";
            // 
            // buttonAzuriraj
            // 
            this.buttonAzuriraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(21)))), ((int)(((byte)(150)))));
            resources.ApplyResources(this.buttonAzuriraj, "buttonAzuriraj");
            this.buttonAzuriraj.ForeColor = System.Drawing.Color.White;
            this.buttonAzuriraj.Name = "buttonAzuriraj";
            this.buttonAzuriraj.UseVisualStyleBackColor = false;
            this.buttonAzuriraj.Click += new System.EventHandler(this.buttonAzuriraj_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PetShop.Properties.Resources.BAHlogo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // AzurirajCijenuForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(232)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAzuriraj);
            this.Controls.Add(this.tbCijena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSifra);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AzurirajCijenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCijena;
        private System.Windows.Forms.Button buttonAzuriraj;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}