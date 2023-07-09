using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bao_cao
{
    class KetNoi
    {


        SqlConnection conn;
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public KetNoi()
        {

           
          string ketnoi = @"Data Source=DESKTOP-74GC5N8\SQLEXPRESS;Initial Catalog=QL_KARAOKE;Integrated Security=True";
           conn = new SqlConnection(ketnoi);
        }
        
        public DataTable thuchien(string SQLstr,string ten)
        {
            da = new SqlDataAdapter(SQLstr, conn);
            ds = new DataSet();
            da.Fill(ds,ten);
            return ds.Tables[ten];

        }
       public object tiendv( string lenh)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sp = new SqlCommand(lenh, conn);
            object c = sp.ExecuteScalar();
            return c;
        }
        public void thuchienlenh(string strsql)
        {

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

              
                SqlCommand cmn = new SqlCommand(strsql, conn);
                cmn.ExecuteNonQuery();
               
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
                MessageBox.Show("Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ");
            }


        }
        public string LenhTraVe(string lenh)
        {
            string c = "";
            try
            {
                conn.Open();
                SqlCommand sp = new SqlCommand(lenh, conn);
                 c = (string)sp.ExecuteScalar();
                return c;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
            return c;
        }
        public string CreateAutoID(string name)
        {

            string c=null;
          
            try
            {
                conn.Open();
                SqlCommand sp = new SqlCommand(name, conn);
                c = (string)sp.ExecuteScalar();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi id");
            }
            return c;
            

        }
        public string MAHD()
        {

         
                string ma = "SELECT CONCAT('HD', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAHD),3,2),0) + 1),2)) from HOADON where MAHD like 'HD%'";
                SqlCommand sp = new SqlCommand(ma, conn);
                string c = (string)sp.ExecuteScalar();
        
                return c;


        }

        bool KT_khoa(string ma,string name)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(name, conn);
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                if (count >= 1)
                    return false;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
