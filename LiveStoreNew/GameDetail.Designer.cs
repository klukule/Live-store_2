namespace LiveStoreNew
{
    partial class GameDetail
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
            this.popisek = new MetroFramework.Controls.MetroTextBox();
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // popisek
            // 
            this.popisek.Location = new System.Drawing.Point(23, 269);
            this.popisek.MaxLength = 32767;
            this.popisek.Multiline = true;
            this.popisek.Name = "popisek";
            this.popisek.PasswordChar = '\0';
            this.popisek.ReadOnly = true;
            this.popisek.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.popisek.SelectedText = "";
            this.popisek.Size = new System.Drawing.Size(650, 132);
            this.popisek.TabIndex = 0;
            this.popisek.Text = "metroTextBox1";
            this.popisek.UseSelectable = true;
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(23, 63);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(650, 200);
            this.image.TabIndex = 1;
            this.image.TabStop = false;
            // 
            // GameDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 424);
            this.Controls.Add(this.image);
            this.Controls.Add(this.popisek);
            this.MaximizeBox = false;
            this.Name = "GameDetail";
            this.Resizable = false;
            this.Text = "Detail of game - ";
            this.Load += new System.EventHandler(this.GameDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox popisek;
        private System.Windows.Forms.PictureBox image;

    }
}