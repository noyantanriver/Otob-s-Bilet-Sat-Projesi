using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace OtobusOtomasyonu
{
    class uyekayit:Uye
    {
       
        


        public void uyeekle(Uye K)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("insert into UyeKayit (TC,Ad,Soyad,Telefon,Cinsiyet) Values ('" +Convert.ToDouble( K.TCNO) + "','" + K.AD.ToString() + "','" + K.SOYAD.ToString() + "','" + K.TELEFON.ToString() + "','" + K.CINSIYET.ToString() + "')",con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        public void uyeguncelle(Uye eskiuye, Uye yeniuye)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("update  UyeKayit SET Ad='" + yeniuye.AD.ToString() + "',Soyad='" + yeniuye.SOYAD.ToString() + "',Telefon='" +yeniuye.TELEFON.ToString() + "',Cinsiyet='" + yeniuye.CINSIYET.ToString() + "'Where TC= '" +eskiuye.TCNO.ToString() + "'",con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void uyesil(Uye K)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete  From UyeKayit Where TC='"+Convert.ToDouble( K.TCNO)+"'",con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

    }
}
