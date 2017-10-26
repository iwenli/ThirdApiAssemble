namespace Test
{
    partial class BaiduFace
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
            this.txtLog1 = new System.Windows.Forms.RichTextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFaceMatch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIdentify);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtUserInfo);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.txtGroupId);
            this.groupBox1.Controls.Add(this.txtLog1);
            this.groupBox1.Controls.Add(this.btnVerify);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.btnFaceMatch);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.picBoxImage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 526);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtLog1
            // 
            this.txtLog1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog1.Location = new System.Drawing.Point(3, 355);
            this.txtLog1.Name = "txtLog1";
            this.txtLog1.ReadOnly = true;
            this.txtLog1.Size = new System.Drawing.Size(319, 168);
            this.txtLog1.TabIndex = 4;
            this.txtLog1.Text = "";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 197);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(72, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "人脸检测";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // picBoxImage
            // 
            this.picBoxImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxImage.Location = new System.Drawing.Point(3, 17);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(319, 174);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 2;
            this.picBoxImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(325, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 526);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 17);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(384, 506);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // txtGroupId
            // 
            this.txtGroupId.Location = new System.Drawing.Point(5, 315);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.ReadOnly = true;
            this.txtGroupId.Size = new System.Drawing.Size(100, 21);
            this.txtGroupId.TabIndex = 5;
            this.txtGroupId.Text = "iwenli";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(111, 315);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 21);
            this.txtUserId.TabIndex = 5;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.Location = new System.Drawing.Point(217, 315);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.Size = new System.Drawing.Size(100, 21);
            this.txtUserInfo.TabIndex = 5;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(6, 277);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(72, 23);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "人脸注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(6, 248);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(72, 23);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "人脸认证";
            this.btnVerify.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 277);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "人脸删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(83, 248);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(72, 23);
            this.btnIdentify.TabIndex = 7;
            this.btnIdentify.Text = "人脸识别";
            this.btnIdentify.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(84, 277);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "人脸更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnFaceMatch
            // 
            this.btnFaceMatch.Location = new System.Drawing.Point(83, 197);
            this.btnFaceMatch.Name = "btnFaceMatch";
            this.btnFaceMatch.Size = new System.Drawing.Size(72, 23);
            this.btnFaceMatch.TabIndex = 3;
            this.btnFaceMatch.Text = "人脸对比";
            this.btnFaceMatch.UseVisualStyleBackColor = true;
            // 
            // BaiduFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 526);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaiduFace";
            this.Text = "人脸识别";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtLog1;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFaceMatch;
    }
}