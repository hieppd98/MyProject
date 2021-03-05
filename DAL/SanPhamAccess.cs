using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class SanPhamAccess:DataAccess
    {
        public List<SanPham>LayToanBoSanPham()
        {
            List<SanPham> Dssp = new List<SanPham>();
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select*from SanPham";
            command.Connection = Conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int maSP = reader.GetInt32(0);
                string tenSP = reader.GetString(1);
                int donGia = reader.GetInt32(2);
                int maDM = reader.GetInt32(3);

                SanPham sp = new SanPham();
                sp.MaSP = maSP;
                sp.TenSP = tenSP;
                sp.DonGia = donGia;
                sp.MaDM = maDM;
                Dssp.Add(sp);
            }
            reader.Close();
            return Dssp;
        }
        public bool XoaSanPham(int ma)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from SanPham where masp=@ma";
            command.Connection = Conn;

            command.Parameters.Add("@ma", SqlDbType.Int).Value = ma;
            int kq = command.ExecuteNonQuery();
            return kq>0;
        }

        public bool ThemSanPham(int ma,string tenSP,int donGia,int maDM)
        {
            
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = 
                "insert into SanPham (MaSP,TenSP,DonGia,MaDM) values(@maSP,@tenSP,@donGia,@maDM)";
            command.Connection = Conn;

            command.Parameters.Add("@maSP", SqlDbType.Int).Value = ma;
            command.Parameters.Add("@tenSP", SqlDbType.NVarChar).Value = tenSP;
            command.Parameters.Add("@donGia", SqlDbType.Int).Value = donGia;
            command.Parameters.Add("@maDM", SqlDbType.Int).Value = maDM;

            int kq = command.ExecuteNonQuery();
            return kq > 0;

        }
        public bool SuaSanPham( int maSP,string tenSP,int donGia,int maDM)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                "update SanPham set TenSP=@tenSP,DonGia=@donGia,MaDM=@maDM where MaSP=@maSP";
            command.Connection = Conn;

            command.Parameters.Add("@maSP", SqlDbType.Int).Value = maSP;
            command.Parameters.Add("@tenSP", SqlDbType.NVarChar).Value = tenSP;
            command.Parameters.Add("@donGia", SqlDbType.Int).Value = donGia;
            command.Parameters.Add("@maDM", SqlDbType.Int).Value = maDM;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
