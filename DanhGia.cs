using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGia
{
    public partial class Form1 : Form
    {
        public static List<string> list = new List<string>() {"Mô tả chi tiết đánh giá"};

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Cảm ơn bạn đã đánh giá!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
