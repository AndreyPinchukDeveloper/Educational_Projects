namespace Party_Planner
{
    partial class PartyPlanner
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckBox__Fancy_Decorations = new System.Windows.Forms.CheckBox();
            this.CheckBox__Healthy_Options = new System.Windows.Forms.CheckBox();
            this.Button_Calculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(48, 53);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(116, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of people";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cost:";
            // 
            // CheckBox__Fancy_Decorations
            // 
            this.CheckBox__Fancy_Decorations.AutoSize = true;
            this.CheckBox__Fancy_Decorations.Location = new System.Drawing.Point(48, 98);
            this.CheckBox__Fancy_Decorations.Name = "CheckBox__Fancy_Decorations";
            this.CheckBox__Fancy_Decorations.Size = new System.Drawing.Size(115, 17);
            this.CheckBox__Fancy_Decorations.TabIndex = 4;
            this.CheckBox__Fancy_Decorations.Text = "Fancy Decorations";
            this.CheckBox__Fancy_Decorations.UseVisualStyleBackColor = true;
            // 
            // CheckBox__Healthy_Options
            // 
            this.CheckBox__Healthy_Options.AutoSize = true;
            this.CheckBox__Healthy_Options.Location = new System.Drawing.Point(48, 137);
            this.CheckBox__Healthy_Options.Name = "CheckBox__Healthy_Options";
            this.CheckBox__Healthy_Options.Size = new System.Drawing.Size(104, 17);
            this.CheckBox__Healthy_Options.TabIndex = 5;
            this.CheckBox__Healthy_Options.Text = "Healthy_Options";
            this.CheckBox__Healthy_Options.UseVisualStyleBackColor = true;
            // 
            // Button_Calculate
            // 
            this.Button_Calculate.Location = new System.Drawing.Point(48, 225);
            this.Button_Calculate.Name = "Button_Calculate";
            this.Button_Calculate.Size = new System.Drawing.Size(152, 23);
            this.Button_Calculate.TabIndex = 6;
            this.Button_Calculate.Text = "Calculate";
            this.Button_Calculate.UseVisualStyleBackColor = true;
            this.Button_Calculate.Click += new System.EventHandler(this.Button_Calculate_Click);
            // 
            // PartyPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 264);
            this.Controls.Add(this.Button_Calculate);
            this.Controls.Add(this.CheckBox__Healthy_Options);
            this.Controls.Add(this.CheckBox__Fancy_Decorations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartyPlanner";
            this.Text = "PartyPlanner";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckBox__Fancy_Decorations;
        private System.Windows.Forms.CheckBox CheckBox__Healthy_Options;
        private System.Windows.Forms.Button Button_Calculate;
    }
}

