
namespace FinalProyectData
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.lstNews = new System.Windows.Forms.ListBox();
            this.rbtnKeyword = new System.Windows.Forms.RadioButton();
            this.rbtnTime = new System.Windows.Forms.RadioButton();
            this.rbtnKeywordsTime = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtSetTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Keyword:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(175, 159);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(223, 22);
            this.txtTime.TabIndex = 12;
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(175, 111);
            this.txtKeywords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(223, 22);
            this.txtKeywords.TabIndex = 11;
            this.txtKeywords.TextChanged += new System.EventHandler(this.txtKeywords_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search By:";
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "Recent",
            "Trending",
            "Id"});
            this.cmbSearchBy.Location = new System.Drawing.Point(175, 22);
            this.cmbSearchBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(223, 24);
            this.cmbSearchBy.TabIndex = 9;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(502, 15);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(131, 38);
            this.btnShow.TabIndex = 8;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lstNews
            // 
            this.lstNews.FormattingEnabled = true;
            this.lstNews.HorizontalScrollbar = true;
            this.lstNews.ItemHeight = 16;
            this.lstNews.Location = new System.Drawing.Point(64, 278);
            this.lstNews.Margin = new System.Windows.Forms.Padding(4);
            this.lstNews.Name = "lstNews";
            this.lstNews.Size = new System.Drawing.Size(1088, 228);
            this.lstNews.TabIndex = 15;
            // 
            // rbtnKeyword
            // 
            this.rbtnKeyword.AutoSize = true;
            this.rbtnKeyword.Location = new System.Drawing.Point(175, 70);
            this.rbtnKeyword.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnKeyword.Name = "rbtnKeyword";
            this.rbtnKeyword.Size = new System.Drawing.Size(87, 20);
            this.rbtnKeyword.TabIndex = 16;
            this.rbtnKeyword.TabStop = true;
            this.rbtnKeyword.Text = "Keywords";
            this.rbtnKeyword.UseVisualStyleBackColor = true;
            this.rbtnKeyword.CheckedChanged += new System.EventHandler(this.rbtnKeyword_CheckedChanged);
            // 
            // rbtnTime
            // 
            this.rbtnTime.AutoSize = true;
            this.rbtnTime.Location = new System.Drawing.Point(271, 70);
            this.rbtnTime.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnTime.Name = "rbtnTime";
            this.rbtnTime.Size = new System.Drawing.Size(59, 20);
            this.rbtnTime.TabIndex = 17;
            this.rbtnTime.TabStop = true;
            this.rbtnTime.Text = "Time";
            this.rbtnTime.UseVisualStyleBackColor = true;
            this.rbtnTime.CheckedChanged += new System.EventHandler(this.rbtnTime_CheckedChanged);
            // 
            // rbtnKeywordsTime
            // 
            this.rbtnKeywordsTime.AutoSize = true;
            this.rbtnKeywordsTime.Location = new System.Drawing.Point(350, 70);
            this.rbtnKeywordsTime.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnKeywordsTime.Name = "rbtnKeywordsTime";
            this.rbtnKeywordsTime.Size = new System.Drawing.Size(122, 20);
            this.rbtnKeywordsTime.TabIndex = 18;
            this.rbtnKeywordsTime.TabStop = true;
            this.rbtnKeywordsTime.Text = "Keywords-Time";
            this.rbtnKeywordsTime.UseVisualStyleBackColor = true;
            this.rbtnKeywordsTime.CheckedChanged += new System.EventHandler(this.rbtnKeywordsTime_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Turquoise;
            this.txtId.Location = new System.Drawing.Point(175, 208);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(223, 22);
            this.txtId.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "ID:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1021, 233);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 38);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtSetTime
            // 
            this.txtSetTime.Location = new System.Drawing.Point(804, 23);
            this.txtSetTime.Name = "txtSetTime";
            this.txtSetTime.Size = new System.Drawing.Size(202, 22);
            this.txtSetTime.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(730, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Time:";
            // 
            // btnSetTime
            // 
            this.btnSetTime.Location = new System.Drawing.Point(1031, 19);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(130, 30);
            this.btnSetTime.TabIndex = 24;
            this.btnSetTime.Text = "Set Time";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 577);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSetTime);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.rbtnKeywordsTime);
            this.Controls.Add(this.rbtnTime);
            this.Controls.Add(this.rbtnKeyword);
            this.Controls.Add(this.lstNews);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.btnShow);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListBox lstNews;
        private System.Windows.Forms.RadioButton rbtnKeyword;
        private System.Windows.Forms.RadioButton rbtnTime;
        private System.Windows.Forms.RadioButton rbtnKeywordsTime;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtSetTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetTime;
    }
}

