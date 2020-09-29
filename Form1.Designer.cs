namespace Mid
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Go = new System.Windows.Forms.RadioButton();
            this.btn_Jung = new System.Windows.Forms.RadioButton();
            this.btn_Cho = new System.Windows.Forms.RadioButton();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Go);
            this.groupBox1.Controls.Add(this.btn_Jung);
            this.groupBox1.Controls.Add(this.btn_Cho);
            this.groupBox1.Location = new System.Drawing.Point(30, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "난이도 선택";
            // 
            // btn_Go
            // 
            this.btn_Go.AutoSize = true;
            this.btn_Go.Location = new System.Drawing.Point(90, 218);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(116, 19);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.TabStop = true;
            this.btn_Go.Text = "고급 (30x16)";
            this.btn_Go.UseVisualStyleBackColor = true;
            // 
            // btn_Jung
            // 
            this.btn_Jung.AutoSize = true;
            this.btn_Jung.Location = new System.Drawing.Point(90, 145);
            this.btn_Jung.Name = "btn_Jung";
            this.btn_Jung.Size = new System.Drawing.Size(116, 19);
            this.btn_Jung.TabIndex = 1;
            this.btn_Jung.TabStop = true;
            this.btn_Jung.Text = "중급 (16x16)";
            this.btn_Jung.UseVisualStyleBackColor = true;
            // 
            // btn_Cho
            // 
            this.btn_Cho.AutoSize = true;
            this.btn_Cho.Location = new System.Drawing.Point(90, 74);
            this.btn_Cho.Name = "btn_Cho";
            this.btn_Cho.Size = new System.Drawing.Size(100, 19);
            this.btn_Cho.TabIndex = 0;
            this.btn_Cho.TabStop = true;
            this.btn_Cho.Text = "초급 (9x9)";
            this.btn_Cho.UseVisualStyleBackColor = true;
            // 
            // btn_Select
            // 
            this.btn_Select.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Select.Location = new System.Drawing.Point(135, 348);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(57, 53);
            this.btn_Select.TabIndex = 1;
            this.btn_Select.Text = "확인";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 413);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btn_Go;
        private System.Windows.Forms.RadioButton btn_Jung;
        private System.Windows.Forms.RadioButton btn_Cho;
        private System.Windows.Forms.Button btn_Select;
    }
}

