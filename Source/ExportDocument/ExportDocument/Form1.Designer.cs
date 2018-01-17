namespace ExportDocument
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExportPosition = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnPositionGrade = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportPosition
            // 
            this.btnExportPosition.Location = new System.Drawing.Point(12, 12);
            this.btnExportPosition.Name = "btnExportPosition";
            this.btnExportPosition.Size = new System.Drawing.Size(73, 26);
            this.btnExportPosition.TabIndex = 0;
            this.btnExportPosition.Text = "导出职位";
            this.btnExportPosition.UseVisualStyleBackColor = true;
            this.btnExportPosition.Click += new System.EventHandler(this.btnExportPosition_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 434);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 12);
            this.lblMessage.TabIndex = 1;
            // 
            // btnPositionGrade
            // 
            this.btnPositionGrade.Location = new System.Drawing.Point(104, 12);
            this.btnPositionGrade.Name = "btnPositionGrade";
            this.btnPositionGrade.Size = new System.Drawing.Size(91, 26);
            this.btnPositionGrade.TabIndex = 2;
            this.btnPositionGrade.Text = "导出职位等级";
            this.btnPositionGrade.UseVisualStyleBackColor = true;
            this.btnPositionGrade.Click += new System.EventHandler(this.btnPositionGrade_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 455);
            this.Controls.Add(this.btnPositionGrade);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnExportPosition);
            this.Name = "Form1";
            this.Text = "文档导出";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportPosition;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnPositionGrade;
    }
}

