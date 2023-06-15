using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CHIBANTHAN
{ 
    public partial class frmChiBanThan : Form
    {
        public static string
            connectionString = "data source = localhost; database = QLTCCaNhan; user id = sa; password = 123";
        DataSet ds;

        public static string Status = "";

        public frmChiBanThan()
        {
            InitializeComponent();
            Loadcboboxid("SELECT *FROM TaiKhoan", "id", "id");
            Status = "Reset";
            SetControlStatus("Status");
            BindingData();
        }

        public void Loadcboboxid(string query, string dis, string valu)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            cbo_id.DataSource = ds.Tables[0];
            cbo_id.DisplayMember = dis;
            cbo_id.ValueMember = valu;

        }

        public void SetControlStatus(string State)
        {
            switch (State)
            {
                case "Reset":
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                    btnTongChi.Enabled = false;

                    txt_machi.Enabled = false;
                    txt_sotien.Enabled = false;
                    txt_ghichu.Enabled = false;
                    cbo_tenloaichi.Enabled = false;
                    dtp_ngaychi.Enabled = false;
                    cbo_id.Enabled = false;
                    break;

                case "Insert":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuy.Enabled = true;

                    txt_machi.Enabled = false;
                    txt_sotien.Enabled = true;
                    txt_ghichu.Enabled = true;
                    cbo_tenloaichi.Enabled = true;
                    dtp_ngaychi.Enabled = true;
                    cbo_id.Enabled = true;

                    txt_machi.Text = "";
                    cbo_tenloaichi.Text = "";
                    cbo_tenloaichi.Focus();
                    txt_sotien.Text = "";
                    txt_ghichu.Text = "";
                    cbo_id.Text = "";
                    break;

                case "Edit":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuy.Enabled = true;

                    txt_machi.Enabled = true;
                    txt_sotien.Enabled = true;
                    txt_ghichu.Enabled = true;
                    cbo_tenloaichi.Enabled = true;
                    dtp_ngaychi.Enabled = true;
                    cbo_id .Enabled = true;
                    break;

                default:
                    break;
            }
        }

        public void BindingData()
        {
            try
            {

                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT * FROM QLChiBanThan ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvMain.DataSource = ds.Tables[0];
                    txt_machi.Text = ds.Tables[0].Rows[0]["MaChi"].ToString();
                    cbo_tenloaichi.SelectedItem = ds.Tables[0].Rows[0]["TenLoaiChi"].ToString();
                    txt_sotien.Text = ds.Tables[0].Rows[0]["SoTien"].ToString();
                    dtp_ngaychi.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayChi"]);
                    txt_ghichu.Text = ds.Tables[0].Rows[0]["GhiChu"].ToString();
                    cbo_id.SelectedValue = ds.Tables[0].Rows[0]["id"].ToString();


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            btnTongChi.Enabled = false;

            txt_machi.Enabled = false;
            dtp_ngaychi.Enabled = false;
            cbo_tenloaichi.Enabled = false;
            txt_sotien.Enabled = false;
            txt_ghichu.Enabled = false;
            cbo_id.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Status = "Insert";
            SetControlStatus(Status);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Status = "Edit";
            SetControlStatus(Status);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
           
            DateTime selectedDate = dtp_ngaychi.Value;

            if (DateTime.Compare(selectedDate, DateTime.Today) > 0)
            {
                MessageBox.Show("Ngày nhập không hợp lệ!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbo_tenloaichi.Text != "")
            {
            }
            else
            {
                MessageBox.Show("Tên loại chi đang để trống!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_tenloaichi.Focus();
                return;
            }

            if (txt_sotien.Text != "")
            {
            }
            else
            {
                MessageBox.Show("Số tiền đang để trống!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_sotien.Focus();
                return;
            }

            if (Status == "Insert")
            {
                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "INSERT INTO QLChiBanThan VALUES('" + txt_machi.Text.Trim() + "', N'" + cbo_tenloaichi.SelectedItem.ToString() + "','" + dtp_ngaychi.Value.ToString("MM/dd/yyyy") + "','" + Convert.ToDecimal(txt_sotien.Text.Trim()).ToString() + "',N'" + txt_ghichu.Text.Trim() + "', '"+cbo_id.SelectedValue.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    Status = "Reset";
                    SetControlStatus(Status);
                    BindingData();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }


            else if (Status == "Edit")
            {

                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "UPDATE QLChiBanThan SET TenLoaiChi=N'" + cbo_tenloaichi.SelectedItem.ToString() + "', NgayChi= '" + dtp_ngaychi.Value.ToString("MM/dd/yyyy") + "',GhiChu= N'" + txt_ghichu.Text.Trim() + "',SoTien = '" + Convert.ToDecimal(txt_sotien.Text.Trim()).ToString("0,0") + "'  WHERE MaChi= '" + txt_machi.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    Status = "Reset";
                    SetControlStatus(Status);
                    BindingData();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvMain.Rows[e.RowIndex];
                //var row = (DataGridViewRow)dgv_main.Rows[e.RowIndex];
                txt_machi.Text = row.Cells["MaChi"].Value.ToString();
                cbo_tenloaichi.Text = row.Cells["TenLoaiChi"].Value.ToString();
                txt_sotien.Text = row.Cells["SoTien"].Value.ToString();
                dtp_ngaychi.Value = Convert.ToDateTime(row.Cells["NgayChi"].Value);
                txt_ghichu.Text = row.Cells["GhiChu"].Value.ToString();
                cbo_id.SelectedValue = row.Cells["id"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    string query = "DELETE FROM QLChiBanThan WHERE MaChi= '" + txt_machi.Text.Trim() + " '";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var resultDelete = cmd.ExecuteNonQuery();
                    if (resultDelete > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        Status = "Reset";
                        SetControlStatus(Status);
                        BindingData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Status = "Reset";
            SetControlStatus(Status);
            BindingData();
            DialogResult tb = MessageBox.Show("Bạn có muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                frmChiBanThan frmchibt = new frmChiBanThan();
                frmchibt.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void btnTongChi_Click(object sender, EventArgs e)
        {
            // Tính tổng tiền chi trên cột số tiền
            decimal tongChi = 0;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                tongChi += Convert.ToDecimal(row.Cells["SoTien"].Value);

            }
            MessageBox.Show("Tổng tiền chi cho bản thân là: " + tongChi.ToString());
        }
    }
}
