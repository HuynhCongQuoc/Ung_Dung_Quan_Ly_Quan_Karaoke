
namespace Bao_cao
{
    partial class DN
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TenDN = new System.Windows.Forms.TextBox();
            this.btn_DN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_matKhau = new System.Windows.Forms.TextBox();
            this.ck_Show = new System.Windows.Forms.CheckBox();
            this.button_thoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(292, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // txt_TenDN
            // 
            this.txt_TenDN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDN.Location = new System.Drawing.Point(285, 150);
            this.txt_TenDN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TenDN.Name = "txt_TenDN";
            this.txt_TenDN.Size = new System.Drawing.Size(282, 27);
            this.txt_TenDN.TabIndex = 0;
     
            this.txt_TenDN.Leave += new System.EventHandler(this.txt_TenDN_Leave);
            // 
            // btn_DN
            // 
            this.btn_DN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_DN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DN.Location = new System.Drawing.Point(285, 296);
            this.btn_DN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_DN.Name = "btn_DN";
            this.btn_DN.Size = new System.Drawing.Size(133, 44);
            this.btn_DN.TabIndex = 3;
            this.btn_DN.Text = "Đăng nhập";
            this.btn_DN.UseVisualStyleBackColor = false;
            this.btn_DN.Click += new System.EventHandler(this.btn_DN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu";
            // 
            // txt_matKhau
            // 
            this.txt_matKhau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_matKhau.Location = new System.Drawing.Point(285, 223);
            this.txt_matKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_matKhau.Name = "txt_matKhau";
            this.txt_matKhau.PasswordChar = '*';
            this.txt_matKhau.Size = new System.Drawing.Size(282, 27);
            this.txt_matKhau.TabIndex = 1;
            this.txt_matKhau.Leave += new System.EventHandler(this.txt_matKhau_Leave);
            // 
            // ck_Show
            // 
            this.ck_Show.AutoSize = true;
            this.ck_Show.Location = new System.Drawing.Point(575, 239);
            this.ck_Show.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ck_Show.Name = "ck_Show";
            this.ck_Show.Size = new System.Drawing.Size(128, 23);
            this.ck_Show.TabIndex = 2;
            this.ck_Show.Text = "Hiện mật khẩu";
            this.ck_Show.UseVisualStyleBackColor = true;
            this.ck_Show.CheckedChanged += new System.EventHandler(this.ck_Show_CheckedChanged);
            // 
            // button_thoat
            // 
            this.button_thoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_thoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(434, 296);
            this.button_thoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(133, 44);
            this.button_thoat.TabIndex = 4;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = false;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DN
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(773, 534);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.ck_Show);
            this.Controls.Add(this.txt_matKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_DN);
            this.Controls.Add(this.txt_TenDN);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "DN";
            this.Text = "DN";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TenDN;
        private System.Windows.Forms.Button btn_DN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_matKhau;
        private System.Windows.Forms.CheckBox ck_Show;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}