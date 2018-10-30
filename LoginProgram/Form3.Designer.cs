namespace LoginProgram
{
    partial class Form3
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
            this.IwServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IwItemType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IwMinNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IwMaxNum = new System.Windows.Forms.TextBox();
            this.IwCost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IwOkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "서버명";
            // 
            // IwServerName
            // 
            this.IwServerName.Location = new System.Drawing.Point(12, 31);
            this.IwServerName.Name = "IwServerName";
            this.IwServerName.Size = new System.Drawing.Size(170, 21);
            this.IwServerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "물품종류";
            // 
            // IwItemType
            // 
            this.IwItemType.Location = new System.Drawing.Point(202, 31);
            this.IwItemType.Name = "IwItemType";
            this.IwItemType.Size = new System.Drawing.Size(170, 21);
            this.IwItemType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "판매수량 (최대 판매수량을 적지 않으면 일반판매 입니다)";
            // 
            // IwMinNum
            // 
            this.IwMinNum.Location = new System.Drawing.Point(42, 88);
            this.IwMinNum.Name = "IwMinNum";
            this.IwMinNum.Size = new System.Drawing.Size(150, 21);
            this.IwMinNum.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "최소";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "최대";
            // 
            // IwMaxNum
            // 
            this.IwMaxNum.Location = new System.Drawing.Point(221, 88);
            this.IwMaxNum.Name = "IwMaxNum";
            this.IwMaxNum.Size = new System.Drawing.Size(150, 21);
            this.IwMaxNum.TabIndex = 8;
            // 
            // IwCost
            // 
            this.IwCost.Location = new System.Drawing.Point(12, 139);
            this.IwCost.Name = "IwCost";
            this.IwCost.Size = new System.Drawing.Size(360, 21);
            this.IwCost.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "판매금액";
            // 
            // IwOkButton
            // 
            this.IwOkButton.Location = new System.Drawing.Point(12, 191);
            this.IwOkButton.Name = "IwOkButton";
            this.IwOkButton.Size = new System.Drawing.Size(360, 50);
            this.IwOkButton.TabIndex = 15;
            this.IwOkButton.Text = "등록";
            this.IwOkButton.UseVisualStyleBackColor = true;
            this.IwOkButton.Click += new System.EventHandler(this.IwOkButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 253);
            this.Controls.Add(this.IwOkButton);
            this.Controls.Add(this.IwCost);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.IwMaxNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IwMinNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IwItemType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IwServerName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "빠른 게시글 작성중";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IwServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IwItemType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IwMinNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IwMaxNum;
        private System.Windows.Forms.TextBox IwCost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button IwOkButton;
    }
}