using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace OtobusOtomasyonu
{
    class SeferEkle:Uye
    {
        


        public List<Seferler> Listele2()
        {
            try
            {
                List<Seferler> seferListesi = new List<Seferler>();
                cmd.CommandText = "select * from Seferler";
                cmd.CommandType = CommandType.Text;
                con.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    Seferler s = new Seferler();
                    s.KALKIS = Reader[0].ToString();
                    s.VARIS = Reader[1].ToString();
                    seferListesi.Add(s);
                    

                }
                return seferListesi;

            }
            catch
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


        public void seferekle(Seferler S)
        {
            try
            {

                OleDbCommand cmd = new OleDbCommand("insert into Seferler (Kalkis_Yeri, Inis_Yeri) Values ('" +S.KALKIS.ToString() + "','" + S.VARIS.ToString() + "')", con);
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

        public void sefersil(Seferler S)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete  From Seferler Where Kalkis_Yeri='" + S.KALKIS.ToString() + "'and Inis_Yeri='"+S.VARIS.ToString()+"'", con);
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
