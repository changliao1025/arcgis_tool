namespace ArcGISTool
{
    partial class Projection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_prefixout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_project1 = new System.Windows.Forms.ComboBox();
            this.textBox_prefixin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_out = new System.Windows.Forms.Button();
            this.textBox_pathout = new System.Windows.Forms.TextBox();
            this.button_in = new System.Windows.Forms.Button();
            this.textBox_pathin = new System.Windows.Forms.TextBox();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_cellsize = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_cellsize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_prefixout);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_project1);
            this.groupBox1.Controls.Add(this.textBox_prefixin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button_out);
            this.groupBox1.Controls.Add(this.textBox_pathout);
            this.groupBox1.Controls.Add(this.button_in);
            this.groupBox1.Controls.Add(this.textBox_pathin);
            this.groupBox1.Controls.Add(this.end_date);
            this.groupBox1.Controls.Add(this.start_date);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(65, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 300);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // textBox_prefixout
            // 
            this.textBox_prefixout.Location = new System.Drawing.Point(360, 146);
            this.textBox_prefixout.Name = "textBox_prefixout";
            this.textBox_prefixout.Size = new System.Drawing.Size(83, 20);
            this.textBox_prefixout.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Output File Prefix";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "To";
            // 
            // comboBox_project1
            // 
            this.comboBox_project1.FormattingEnabled = true;
            this.comboBox_project1.Location = new System.Drawing.Point(143, 93);
            this.comboBox_project1.Name = "comboBox_project1";
            this.comboBox_project1.Size = new System.Drawing.Size(83, 21);
            this.comboBox_project1.TabIndex = 57;
            // 
            // textBox_prefixin
            // 
            this.textBox_prefixin.Location = new System.Drawing.Point(143, 146);
            this.textBox_prefixin.Name = "textBox_prefixin";
            this.textBox_prefixin.Size = new System.Drawing.Size(83, 20);
            this.textBox_prefixin.TabIndex = 56;
            this.textBox_prefixin.TextChanged += new System.EventHandler(this.textBox_prefixin_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Input File Prefix";
            // 
            // button_out
            // 
            this.button_out.Location = new System.Drawing.Point(361, 249);
            this.button_out.Name = "button_out";
            this.button_out.Size = new System.Drawing.Size(83, 25);
            this.button_out.TabIndex = 42;
            this.button_out.Text = "Open";
            this.button_out.UseVisualStyleBackColor = true;
            this.button_out.Click += new System.EventHandler(this.button_out_Click);
            // 
            // textBox_pathout
            // 
            this.textBox_pathout.Location = new System.Drawing.Point(143, 252);
            this.textBox_pathout.Name = "textBox_pathout";
            this.textBox_pathout.Size = new System.Drawing.Size(179, 20);
            this.textBox_pathout.TabIndex = 41;
            // 
            // button_in
            // 
            this.button_in.Location = new System.Drawing.Point(361, 196);
            this.button_in.Name = "button_in";
            this.button_in.Size = new System.Drawing.Size(83, 25);
            this.button_in.TabIndex = 40;
            this.button_in.Text = "Open";
            this.button_in.UseVisualStyleBackColor = true;
            this.button_in.Click += new System.EventHandler(this.button_in_Click);
            // 
            // textBox_pathin
            // 
            this.textBox_pathin.Location = new System.Drawing.Point(143, 199);
            this.textBox_pathin.Name = "textBox_pathin";
            this.textBox_pathin.Size = new System.Drawing.Size(179, 20);
            this.textBox_pathin.TabIndex = 37;
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(361, 37);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(83, 20);
            this.end_date.TabIndex = 33;
            this.end_date.ValueChanged += new System.EventHandler(this.end_date_ValueChanged);
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(143, 37);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(83, 20);
            this.start_date.TabIndex = 32;
            this.start_date.ValueChanged += new System.EventHandler(this.start_date_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(44, 255);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 27;
            this.label24.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "EndYear:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "StartYear:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Input";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(426, 377);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(83, 25);
            this.button_cancel.TabIndex = 61;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(306, 377);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(81, 25);
            this.button_ok.TabIndex = 60;
            this.button_ok.Text = "Execute";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Cellsize";
            // 
            // textBox_cellsize
            // 
            this.textBox_cellsize.Location = new System.Drawing.Point(360, 94);
            this.textBox_cellsize.Name = "textBox_cellsize";
            this.textBox_cellsize.Size = new System.Drawing.Size(83, 20);
            this.textBox_cellsize.TabIndex = 62;
            // 
            // Projection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 429);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox1);
            this.Name = "Projection";
            this.Text = "Projection";
            this.Load += new System.EventHandler(this.Projection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_prefixout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_project1;
        private System.Windows.Forms.TextBox textBox_prefixin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_out;
        private System.Windows.Forms.TextBox textBox_pathout;
        private System.Windows.Forms.Button button_in;
        private System.Windows.Forms.TextBox textBox_pathin;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_cellsize;
        private System.Windows.Forms.Label label7;

    }
}