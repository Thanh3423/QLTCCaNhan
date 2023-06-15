namespace DanhMucThu1
{
    partial class DanhMucChi
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
            this.btnLuong = new System.Windows.Forms.Button();
            this.btnThuong = new System.Windows.Forms.Button();
            this.btnDauTu = new System.Windows.Forms.Button();
            this.btnLamThem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLuong
            // 
            this.btnLuong.Location = new System.Drawing.Point(97, 73);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(128, 80);
            this.btnLuong.TabIndex = 0;
            this.btnLuong.Text = "Lương";
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // btnThuong
            // 
            this.btnThuong.Location = new System.Drawing.Point(394, 239);
            this.btnThuong.Name = "btnThuong";
            this.btnThuong.Size = new System.Drawing.Size(128, 80);
            this.btnThuong.TabIndex = 1;
            this.btnThuong.Text = "Thưởng";
            this.btnThuong.UseVisualStyleBackColor = true;
            this.btnThuong.Click += new System.EventHandler(this.btnThuong_Click);
            // 
            // btnDauTu
            // 
            this.btnDauTu.Location = new System.Drawing.Point(97, 239);
            this.btnDauTu.Name = "btnDauTu";
            this.btnDauTu.Size = new System.Drawing.Size(128, 80);
            this.btnDauTu.TabIndex = 2;
            this.btnDauTu.Text = "Đầu Tư";
            this.btnDauTu.UseVisualStyleBackColor = true;
            this.btnDauTu.Click += new System.EventHandler(this.btnDauTu_Click);
            // 
            // btnLamThem
            // 
            this.btnLamThem.Location = new System.Drawing.Point(394, 73);
            this.btnLamThem.Name = "btnLamThem";
            this.btnLamThem.Size = new System.Drawing.Size(128, 80);
            this.btnLamThem.TabIndex = 3;
            this.btnLamThem.Text = "Làm thêm";
            this.btnLamThem.UseVisualStyleBackColor = true;
            this.btnLamThem.Click += new System.EventHandler(this.btnLamThem_Click);
            // 
            // DanhMucChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLamThem);
            this.Controls.Add(this.btnDauTu);
            this.Controls.Add(this.btnThuong);
            this.Controls.Add(this.btnLuong);
            this.Name = "DanhMucChi";
            this.Text = "Danh mục chi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.Button btnThuong;
        private System.Windows.Forms.Button btnDauTu;
        private System.Windows.Forms.Button btnLamThem;
    }
}

