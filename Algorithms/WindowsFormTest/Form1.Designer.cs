
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calculate_Button = new System.Windows.Forms.Button();
            this.money = new System.Windows.Forms.Label();
            this.MileageOnStart = new System.Windows.Forms.NumericUpDown();
            this.MileageOnEnd = new System.Windows.Forms.NumericUpDown();
            this.display_miles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MileageOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MileageOnEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Startring Mileage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ending Mileage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount Owned";
            // 
            // calculate_Button
            // 
            this.calculate_Button.Location = new System.Drawing.Point(46, 171);
            this.calculate_Button.Name = "calculate_Button";
            this.calculate_Button.Size = new System.Drawing.Size(75, 23);
            this.calculate_Button.TabIndex = 3;
            this.calculate_Button.Text = "Calculate";
            this.calculate_Button.UseVisualStyleBackColor = true;
            this.calculate_Button.Click += new System.EventHandler(this.calculate_Button_Click);
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money.Location = new System.Drawing.Point(137, 123);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(51, 13);
            this.money.TabIndex = 4;
            this.money.Text = "label4";
            // 
            // MileageOnStart
            // 
            this.MileageOnStart.Location = new System.Drawing.Point(137, 28);
            this.MileageOnStart.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.MileageOnStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MileageOnStart.Name = "MileageOnStart";
            this.MileageOnStart.Size = new System.Drawing.Size(120, 20);
            this.MileageOnStart.TabIndex = 5;
            this.MileageOnStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MileageOnEnd
            // 
            this.MileageOnEnd.Location = new System.Drawing.Point(137, 73);
            this.MileageOnEnd.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.MileageOnEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MileageOnEnd.Name = "MileageOnEnd";
            this.MileageOnEnd.Size = new System.Drawing.Size(120, 20);
            this.MileageOnEnd.TabIndex = 6;
            this.MileageOnEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // display_miles
            // 
            this.display_miles.Location = new System.Drawing.Point(201, 171);
            this.display_miles.Name = "display_miles";
            this.display_miles.Size = new System.Drawing.Size(90, 23);
            this.display_miles.TabIndex = 7;
            this.display_miles.Text = "Display Miles";
            this.display_miles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.display_miles.UseVisualStyleBackColor = true;
            this.display_miles.Click += new System.EventHandler(this.display_miles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 238);
            this.Controls.Add(this.display_miles);
            this.Controls.Add(this.MileageOnEnd);
            this.Controls.Add(this.MileageOnStart);
            this.Controls.Add(this.money);
            this.Controls.Add(this.calculate_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Mileage Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.MileageOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MileageOnEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button calculate_Button;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.NumericUpDown MileageOnStart;
        private System.Windows.Forms.NumericUpDown MileageOnEnd;
        private System.Windows.Forms.Button display_miles;
    }
}

