namespace _2_Simple_Image_Processing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.filteredImage = new System.Windows.Forms.PictureBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.filterBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredImage)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.Image = ((System.Drawing.Image)(resources.GetObject("originalImage.Image")));
            this.originalImage.Location = new System.Drawing.Point(12, 18);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(350, 350);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImage.TabIndex = 0;
            this.originalImage.TabStop = false;
            // 
            // filteredImage
            // 
            this.filteredImage.Location = new System.Drawing.Point(507, 18);
            this.filteredImage.Name = "filteredImage";
            this.filteredImage.Size = new System.Drawing.Size(350, 350);
            this.filteredImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.filteredImage.TabIndex = 1;
            this.filteredImage.TabStop = false;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(395, 93);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(81, 63);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = ">";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // filterBox
            // 
            this.filterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Location = new System.Drawing.Point(368, 162);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(133, 21);
            this.filterBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 380);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.filteredImage);
            this.Controls.Add(this.originalImage);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitmap playground";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox filteredImage;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.ComboBox filterBox;
    }
}

