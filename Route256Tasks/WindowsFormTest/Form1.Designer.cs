
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
            this.MoneyOfJoe = new System.Windows.Forms.Label();
            this.MoneyOfBob = new System.Windows.Forms.Label();
            this.GiveButton = new System.Windows.Forms.Button();
            this.RecieveButton = new System.Windows.Forms.Button();
            this.MoneyOfBank = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MoneyOfJoe
            // 
            this.MoneyOfJoe.AutoSize = true;
            this.MoneyOfJoe.Location = new System.Drawing.Point(22, 33);
            this.MoneyOfJoe.Name = "MoneyOfJoe";
            this.MoneyOfJoe.Size = new System.Drawing.Size(68, 13);
            this.MoneyOfJoe.TabIndex = 0;
            this.MoneyOfJoe.Text = "Joe has 50 $";
            // 
            // MoneyOfBob
            // 
            this.MoneyOfBob.AutoSize = true;
            this.MoneyOfBob.Location = new System.Drawing.Point(22, 65);
            this.MoneyOfBob.Name = "MoneyOfBob";
            this.MoneyOfBob.Size = new System.Drawing.Size(76, 13);
            this.MoneyOfBob.TabIndex = 1;
            this.MoneyOfBob.Text = "Bob has 100 $";
            // 
            // GiveButton
            // 
            this.GiveButton.Location = new System.Drawing.Point(25, 146);
            this.GiveButton.Name = "GiveButton";
            this.GiveButton.Size = new System.Drawing.Size(103, 48);
            this.GiveButton.TabIndex = 2;
            this.GiveButton.Text = "Give 10$ to Joe";
            this.GiveButton.UseVisualStyleBackColor = true;
            this.GiveButton.Click += new System.EventHandler(this.GiveButton_Click);
            // 
            // RecieveButton
            // 
            this.RecieveButton.Location = new System.Drawing.Point(205, 146);
            this.RecieveButton.Name = "RecieveButton";
            this.RecieveButton.Size = new System.Drawing.Size(100, 48);
            this.RecieveButton.TabIndex = 3;
            this.RecieveButton.Text = "Recieve 5$ from Bob";
            this.RecieveButton.UseVisualStyleBackColor = true;
            this.RecieveButton.Click += new System.EventHandler(this.RecieveButton_Click);
            // 
            // MoneyOfBank
            // 
            this.MoneyOfBank.AutoSize = true;
            this.MoneyOfBank.Location = new System.Drawing.Point(25, 99);
            this.MoneyOfBank.Name = "MoneyOfBank";
            this.MoneyOfBank.Size = new System.Drawing.Size(80, 13);
            this.MoneyOfBank.TabIndex = 4;
            this.MoneyOfBank.Text = "The Bank has: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 238);
            this.Controls.Add(this.MoneyOfBank);
            this.Controls.Add(this.RecieveButton);
            this.Controls.Add(this.GiveButton);
            this.Controls.Add(this.MoneyOfBob);
            this.Controls.Add(this.MoneyOfJoe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Money Barter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MoneyOfJoe;
        private System.Windows.Forms.Label MoneyOfBob;
        private System.Windows.Forms.Button GiveButton;
        private System.Windows.Forms.Button RecieveButton;
        private System.Windows.Forms.Label MoneyOfBank;
    }
}

