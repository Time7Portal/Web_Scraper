namespace LoginProgram
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.AllLoginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemLoginId = new System.Windows.Forms.TextBox();
            this.ItemLoginPw = new System.Windows.Forms.TextBox();
            this.NaverLoginPw = new System.Windows.Forms.TextBox();
            this.NaverLoginId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AllLoginButton
            // 
            this.AllLoginButton.Location = new System.Drawing.Point(187, 26);
            this.AllLoginButton.Name = "AllLoginButton";
            this.AllLoginButton.Size = new System.Drawing.Size(100, 124);
            this.AllLoginButton.TabIndex = 6;
            this.AllLoginButton.Text = "로그인";
            this.AllLoginButton.UseVisualStyleBackColor = true;
            this.AllLoginButton.Click += new System.EventHandler(this.NaverLoginButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "아이템매니아 로그인";
            // 
            // ItemLoginId
            // 
            this.ItemLoginId.Location = new System.Drawing.Point(15, 101);
            this.ItemLoginId.Name = "ItemLoginId";
            this.ItemLoginId.Size = new System.Drawing.Size(163, 21);
            this.ItemLoginId.TabIndex = 4;
            // 
            // ItemLoginPw
            // 
            this.ItemLoginPw.Location = new System.Drawing.Point(15, 125);
            this.ItemLoginPw.Name = "ItemLoginPw";
            this.ItemLoginPw.Size = new System.Drawing.Size(163, 21);
            this.ItemLoginPw.TabIndex = 5;
            this.ItemLoginPw.UseSystemPasswordChar = true;
            this.ItemLoginPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginButton_KeyDown);
            // 
            // NaverLoginPw
            // 
            this.NaverLoginPw.Location = new System.Drawing.Point(15, 52);
            this.NaverLoginPw.Name = "NaverLoginPw";
            this.NaverLoginPw.Size = new System.Drawing.Size(163, 21);
            this.NaverLoginPw.TabIndex = 2;
            this.NaverLoginPw.UseSystemPasswordChar = true;
            // 
            // NaverLoginId
            // 
            this.NaverLoginId.Location = new System.Drawing.Point(15, 28);
            this.NaverLoginId.Name = "NaverLoginId";
            this.NaverLoginId.Size = new System.Drawing.Size(163, 21);
            this.NaverLoginId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "네이버 로그인 (생략시 비회원 권한 접근)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 161);
            this.Controls.Add(this.ItemLoginPw);
            this.Controls.Add(this.ItemLoginId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AllLoginButton);
            this.Controls.Add(this.NaverLoginPw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NaverLoginId);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인이 필요합니다";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AllLoginButton;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox ItemLoginId;
        private System.Windows.Forms.TextBox ItemLoginPw;
        private System.Windows.Forms.TextBox NaverLoginPw;
        public System.Windows.Forms.TextBox NaverLoginId;
        private System.Windows.Forms.Label label1;
    }
}

