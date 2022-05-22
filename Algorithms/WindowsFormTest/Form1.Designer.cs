
namespace WindowsFormTest
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
            this.Lloyd = new System.Windows.Forms.Button();
            this.Lucinda = new System.Windows.Forms.Button();
            this.Swap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lloyd
            // 
            this.Lloyd.Location = new System.Drawing.Point(84, 38);
            this.Lloyd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Lloyd.Name = "Lloyd";
            this.Lloyd.Size = new System.Drawing.Size(65, 40);
            this.Lloyd.TabIndex = 0;
            this.Lloyd.Text = "Lloyd";
            this.Lloyd.UseVisualStyleBackColor = true;
            this.Lloyd.Click += new System.EventHandler(this.Lloyd_Click);
            // 
            // Lucinda
            // 
            this.Lucinda.Location = new System.Drawing.Point(191, 38);
            this.Lucinda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Lucinda.Name = "Lucinda";
            this.Lucinda.Size = new System.Drawing.Size(73, 40);
            this.Lucinda.TabIndex = 1;
            this.Lucinda.Text = "Lucinda";
            this.Lucinda.UseVisualStyleBackColor = true;
            this.Lucinda.Click += new System.EventHandler(this.Lucinda_Click);
            // 
            // Swap
            // 
            this.Swap.Location = new System.Drawing.Point(129, 98);
            this.Swap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(90, 45);
            this.Swap.TabIndex = 2;
            this.Swap.Text = "Swap!";
            this.Swap.UseVisualStyleBackColor = true;
            this.Swap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 238);
            this.Controls.Add(this.Swap);
            this.Controls.Add(this.Lucinda);
            this.Controls.Add(this.Lloyd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Mileage Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lloyd;
        private System.Windows.Forms.Button Lucinda;
        private System.Windows.Forms.Button Swap;
    }
}

