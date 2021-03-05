using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamAccess spa = new SanPhamAccess();
        public List<SanPham> LayToanBoSanPham()
        {
            return spa.LayToanBoSanPham();
        }
        public bool XoaSanPham(int ma)
        {
            
            return spa.XoaSanPham(ma);
        }
        public bool ThemSanPham(int ma,string tenSP,int donGia,int maDM)
        {
            List<SanPham> dssp = spa.LayToanBoSanPham();
            foreach (SanPham sp in dssp)
            {
                if (ma == sp.MaSP)
                    return false;
            }
            return spa.ThemSanPham(ma,tenSP,donGia,maDM);
        }
        public bool SuaSanPham( int maSP,string tenSP,int donGia,int maDM)
        {
            return spa.SuaSanPham(maSP ,tenSP,donGia,maDM);
        }

    }
}
