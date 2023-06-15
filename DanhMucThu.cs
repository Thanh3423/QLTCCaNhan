using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhMucThu1
{
    public partial class DanhMucChi : Form
    {
        public DanhMucChi()
        {
            InitializeComponent();
        }

        private void btnDauTu_Click(object sender, EventArgs e)
        {
           Đầu_tư   frmDautu = new Đầu_tư();
           frmDautu.Show();
        }

        private void btnLamThem_Click(object sender, EventArgs e)
        {
            Làm_thêm frmLamthem = new Làm_thêm();
            frmLamthem.Show();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            Lương frmLuong = new Lương();
            frmLuong.Show();
        }

        private void btnThuong_Click(object sender, EventArgs e)
        {
            Thưởng frmThuong = new Thưởng();
            frmThuong.Show();
        }
    }
}
