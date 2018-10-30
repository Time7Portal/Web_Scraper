namespace LoginProgram
{
    partial class Form2
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
            this.CafeLabel = new System.Windows.Forms.Label();
            this.CafeListBox = new System.Windows.Forms.ListBox();
            this.CafeRefreshButton = new System.Windows.Forms.Button();
            this.DebugBox = new System.Windows.Forms.TextBox();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.ItemRefreshButton = new System.Windows.Forms.Button();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.ItemSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CafeLabel
            // 
            this.CafeLabel.AutoSize = true;
            this.CafeLabel.Location = new System.Drawing.Point(13, 7);
            this.CafeLabel.Name = "CafeLabel";
            this.CafeLabel.Size = new System.Drawing.Size(69, 12);
            this.CafeLabel.TabIndex = 0;
            this.CafeLabel.Text = "카페 게시글";
            // 
            // CafeListBox
            // 
            this.CafeListBox.Font = new System.Drawing.Font("DotumChe", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CafeListBox.FormattingEnabled = true;
            this.CafeListBox.HorizontalScrollbar = true;
            this.CafeListBox.ItemHeight = 12;
            this.CafeListBox.Location = new System.Drawing.Point(10, 23);
            this.CafeListBox.Name = "CafeListBox";
            this.CafeListBox.Size = new System.Drawing.Size(460, 328);
            this.CafeListBox.TabIndex = 1;
            this.CafeListBox.DoubleClick += new System.EventHandler(this.NaverCafeListBox_DoubleClick);
            // 
            // CafeRefreshButton
            // 
            this.CafeRefreshButton.Location = new System.Drawing.Point(768, 357);
            this.CafeRefreshButton.Name = "CafeRefreshButton";
            this.CafeRefreshButton.Size = new System.Drawing.Size(170, 35);
            this.CafeRefreshButton.TabIndex = 4;
            this.CafeRefreshButton.Text = "카페글 새로고침";
            this.CafeRefreshButton.UseVisualStyleBackColor = true;
            this.CafeRefreshButton.Click += new System.EventHandler(this.NaverCafeLinkButton_Click);
            // 
            // DebugBox
            // 
            this.DebugBox.Location = new System.Drawing.Point(10, 357);
            this.DebugBox.Multiline = true;
            this.DebugBox.Name = "DebugBox";
            this.DebugBox.Size = new System.Drawing.Size(230, 76);
            this.DebugBox.TabIndex = 9;
            // 
            // ItemListBox
            // 
            this.ItemListBox.Font = new System.Drawing.Font("DotumChe", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.HorizontalScrollbar = true;
            this.ItemListBox.ItemHeight = 12;
            this.ItemListBox.Location = new System.Drawing.Point(478, 23);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(460, 328);
            this.ItemListBox.TabIndex = 3;
            this.ItemListBox.DoubleClick += new System.EventHandler(this.ItemListBox_DoubleClick);
            this.ItemListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemListBox_KeyDown);
            // 
            // ItemRefreshButton
            // 
            this.ItemRefreshButton.Location = new System.Drawing.Point(768, 398);
            this.ItemRefreshButton.Name = "ItemRefreshButton";
            this.ItemRefreshButton.Size = new System.Drawing.Size(170, 35);
            this.ItemRefreshButton.TabIndex = 5;
            this.ItemRefreshButton.Text = "매니아글 새로고침";
            this.ItemRefreshButton.UseVisualStyleBackColor = true;
            this.ItemRefreshButton.Click += new System.EventHandler(this.ItemRefreshButton_Click);
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(481, 7);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(117, 12);
            this.ItemLabel.TabIndex = 2;
            this.ItemLabel.Text = "아이템매니아 게시글";
            // 
            // ItemSearch
            // 
            this.ItemSearch.Location = new System.Drawing.Point(478, 371);
            this.ItemSearch.Name = "ItemSearch";
            this.ItemSearch.Size = new System.Drawing.Size(230, 21);
            this.ItemSearch.TabIndex = 7;
            this.ItemSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "아이템매니아 단어 필터링";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "글 선택후 엔터를 누르면 빠른 글쓰기가 가능합니다";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemSearch);
            this.Controls.Add(this.ItemLabel);
            this.Controls.Add(this.ItemRefreshButton);
            this.Controls.Add(this.ItemListBox);
            this.Controls.Add(this.DebugBox);
            this.Controls.Add(this.CafeRefreshButton);
            this.Controls.Add(this.CafeListBox);
            this.Controls.Add(this.CafeLabel);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인 되었습니다";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.From2_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CafeLabel;
        private System.Windows.Forms.ListBox CafeListBox;
        private System.Windows.Forms.Button CafeRefreshButton;
        private System.Windows.Forms.TextBox DebugBox;
        private System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.Button ItemRefreshButton;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.TextBox ItemSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}