using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            List<SanPham> dsSP = spBLL.LayToanBoSanPham();
            lvSP.Items.Clear();
            foreach(SanPham sp in dsSP)
            {
                ListViewItem lv = new ListViewItem(sp.MaSP + "");
                lv.SubItems.Add(sp.TenSP);
                lv.SubItems.Add(sp.DonGia + "");
                lv.SubItems.Add(sp.MaDM + "");
                lvSP.Items.Add(lv);

                lv.Tag = sp;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvSP.SelectedItems[0];
                SanPham sp = lvi.Tag as SanPham;
                SanPhamBLL spbll = new SanPhamBLL();
                bool kq = spbll.XoaSanPham(sp.MaSP);
                if (kq)
                {
                    btnHienThi.PerformClick();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int ma =Convert.ToInt32(txtMa.Text);
            string tenSP = txtTenSP.Text;
            int donGia = int.Parse(txtDonGia.Text);
            int maDM =Convert.ToInt32(txtMaDM.Text);
            SanPhamBLL spbll = new SanPhamBLL();
            bool kq = spbll.ThemSanPham(ma,tenSP,donGia,maDM);
            if (kq)
            {
                btnHienThi.PerformClick();
                txtMa.Text = "";
                txtTenSP.Text = "";
                txtDonGia.Text = "";
                txtMaDM.Text = "";
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
   
                
                SanPhamBLL spbll = new SanPhamBLL();

                int maSP = Convert.ToInt32(txtMa.Text);
                string tenSP = txtTenSP.Text;
                int donGia = Convert.ToInt32(txtDonGia.Text);
                int maDM = Convert.ToInt32(txtMaDM.Text);

                bool kq = spbll.SuaSanPham(maSP,tenSP,donGia,maDM);
                if (kq)
                {
                    btnHienThi.PerformClick();
                }
         
        }

        private void lvSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvSP.SelectedItems[0];

            txtMa.Text = lvi.SubItems[0].Text;
            txtTenSP.Text = lvi.SubItems[1].Text;
            txtDonGia.Text = lvi.SubItems[2].Text;
            txtMaDM.Text = lvi.SubItems[3].Text;
        }
    }
}
