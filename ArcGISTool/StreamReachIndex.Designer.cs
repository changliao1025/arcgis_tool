namespace ArcGISTool
{
    partial class StreamReachIndex
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
            this.button_out = new System.Windows.Forms.Button();
            this.textBox_pathout = new System.Windows.Forms.TextBox();
            this.button_in = new System.Windows.Forms.Button();
            this.textBox_reachfile = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_in1 = new System.Windows.Forms.Button();
            this.textBox_streamfile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_in1);
            this.groupBox1.Controls.Add(this.textBox_streamfile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_out);
            this.groupBox1.Controls.Add(this.textBox_pathout);
            this.groupBox1.Controls.Add(this.button_in);
            this.groupBox1.Controls.Add(this.textBox_reachfile);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(65, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 300);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // button_out
            // 
            this.button_out.Location = new System.Drawing.Point(361, 249);
            this.button_out.Name = "button_out";
            this.button_out.Size = new System.Drawing.Size(83, 25);
            this.button_out.TabIndex = 42;
            this.button_out.Text = "Open";
            this.button_out.UseVisualStyleBackColor = true;
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
            // 
            // textBox_reachfile
            // 
            this.textBox_reachfile.Location = new System.Drawing.Point(143, 199);
            this.textBox_reachfile.Name = "textBox_reachfile";
            this.textBox_reachfile.Size = new System.Drawing.Size(179, 20);
            this.textBox_reachfile.TabIndex = 37;
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
            this.button_cancel.Location = new System.Drawing.Point(426, 358);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(83, 25);
            this.button_cancel.TabIndex = 62;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(306, 358);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(81, 25);
            this.button_ok.TabIndex = 61;
            this.button_ok.Text = "Execute";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_in1
            // 
            this.button_in1.Location = new System.Drawing.Point(361, 145);
            this.button_in1.Name = "button_in1";
            this.button_in1.Size = new System.Drawing.Size(83, 25);
            this.button_in1.TabIndex = 45;
            this.button_in1.Text = "Open";
            this.button_in1.UseVisualStyleBackColor = true;
            // 
            // textBox_streamfile
            // 
            this.textBox_streamfile.Location = new System.Drawing.Point(143, 148);
            this.textBox_streamfile.Name = "textBox_streamfile";
            this.textBox_streamfile.Size = new System.Drawing.Size(179, 20);
            this.textBox_streamfile.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Input";
            // 
            // StreamReachIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 439);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ok);
            this.Name = "StreamReachIndex";
            this.Text = "StreamReachIndex";
            this.Load += new System.EventHandler(this.StreamReachIndex_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_out;
        private System.Windows.Forms.TextBox textBox_pathout;
        private System.Windows.Forms.Button button_in;
        private System.Windows.Forms.TextBox textBox_reachfile;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_in1;
        private System.Windows.Forms.TextBox textBox_streamfile;
        private System.Windows.Forms.Label label2;
    }
}