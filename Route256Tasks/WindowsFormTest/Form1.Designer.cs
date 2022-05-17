
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
            this.BankGivesJoe = new System.Windows.Forms.Button();
            this.BankGivesToBob = new System.Windows.Forms.Button();
            this.MoneyOfBank = new System.Windows.Forms.Label();
            this.JoeGivesToBob = new System.Windows.Forms.Button();
            this.BobGivesToJoe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MoneyOfJoe
            // 
            this.MoneyOfJoe.AutoSize = true;
            this.MoneyOfJoe.Location = new System.Drawing.Point(22, 9);
            this.MoneyOfJoe.Name = "MoneyOfJoe";
            this.MoneyOfJoe.Size = new System.Drawing.Size(68, 13);
            this.MoneyOfJoe.TabIndex = 0;
            this.MoneyOfJoe.Text = "Joe has 50 $";
            // 
            // MoneyOfBob
            // 
            this.MoneyOfBob.AutoSize = true;
            this.MoneyOfBob.Location = new System.Drawing.Point(22, 33);
            this.MoneyOfBob.Name = "MoneyOfBob";
            this.MoneyOfBob.Size = new System.Drawing.Size(76, 13);
            this.MoneyOfBob.TabIndex = 1;
            this.MoneyOfBob.Text = "Bob has 100 $";
            // 
            // BankGivesJoe
            // 
            this.BankGivesJoe.Location = new System.Drawing.Point(23, 89);
            this.BankGivesJoe.Name = "BankGivesJoe";
            this.BankGivesJoe.Size = new System.Drawing.Size(103, 48);
            this.BankGivesJoe.TabIndex = 2;
            this.BankGivesJoe.Text = "Give 10$ to Joe";
            this.BankGivesJoe.UseVisualStyleBackColor = true;
            this.BankGivesJoe.Click += new System.EventHandler(this.BankGivesJoe_Click);
            // 
            // BankGivesToBob
            // 
            this.BankGivesToBob.Location = new System.Drawing.Point(198, 89);
            this.BankGivesToBob.Name = "BankGivesToBob";
            this.BankGivesToBob.Size = new System.Drawing.Size(100, 48);
            this.BankGivesToBob.TabIndex = 3;
            this.BankGivesToBob.Text = "Recieve 5$ from Bob";
            this.BankGivesToBob.UseVisualStyleBackColor = true;
            this.BankGivesToBob.Click += new System.EventHandler(this.BankGivesToBob_Click);
            // 
            // MoneyOfBank
            // 
            this.MoneyOfBank.AutoSize = true;
            this.MoneyOfBank.Location = new System.Drawing.Point(22, 57);
            this.MoneyOfBank.Name = "MoneyOfBank";
            this.MoneyOfBank.Size = new System.Drawing.Size(104, 13);
            this.MoneyOfBank.TabIndex = 4;
            this.MoneyOfBank.Text = "The Bank has: 100$";
            // 
            // JoeGivesToBob
            // 
            this.JoeGivesToBob.Location = new System.Drawing.Point(25, 158);
            this.JoeGivesToBob.Name = "JoeGivesToBob";
            this.JoeGivesToBob.Size = new System.Drawing.Size(103, 48);
            this.JoeGivesToBob.TabIndex = 5;
            this.JoeGivesToBob.Text = "Joe gives $10 to Bob";
            this.JoeGivesToBob.UseVisualStyleBackColor = true;
            this.JoeGivesToBob.Click += new System.EventHandler(this.JoeGivesToBob_Click);
            // 
            // BobGivesToJoe
            // 
            this.BobGivesToJoe.Location = new System.Drawing.Point(198, 158);
            this.BobGivesToJoe.Name = "BobGivesToJoe";
            this.BobGivesToJoe.Size = new System.Drawing.Size(103, 48);
            this.BobGivesToJoe.TabIndex = 6;
            this.BobGivesToJoe.Text = "Bob gives $5 to Joe";
            this.BobGivesToJoe.UseVisualStyleBackColor = true;
            this.BobGivesToJoe.Click += new System.EventHandler(this.BobGivesToJoe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 238);
            this.Controls.Add(this.BobGivesToJoe);
            this.Controls.Add(this.JoeGivesToBob);
            this.Controls.Add(this.MoneyOfBank);
            this.Controls.Add(this.BankGivesToBob);
            this.Controls.Add(this.BankGivesJoe);
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
        private System.Windows.Forms.Button BankGivesJoe;
        private System.Windows.Forms.Button BankGivesToBob;
        private System.Windows.Forms.Label MoneyOfBank;
        private System.Windows.Forms.Button JoeGivesToBob;
        private System.Windows.Forms.Button BobGivesToJoe;
    }
}

