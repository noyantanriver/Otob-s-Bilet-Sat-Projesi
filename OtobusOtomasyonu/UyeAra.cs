using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
namespace OtobusOtomasyonu
{   
    class UyeAra:Uye
    {

        public void UyeGetir(ListView lw, string aranan)
        {

            lw.Items.Clear();
            cmd = new OleDbCommand("select * from UyeKayit where TC like '%" + aranan + "%'", con);
           

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["TC"].ToString());
                    item.SubItems.Add(dr["Ad"].ToString());
                    item.SubItems.Add(dr["Soyad"].ToString());
                    item.SubItems.Add(dr["Telefon"].ToString());
                    item.SubItems.Add(dr["Cinsiyet"].ToString());
                    

                    lw.Items.Add(item);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {

                string hata = ex.Message;
            }



        }



    }
}
