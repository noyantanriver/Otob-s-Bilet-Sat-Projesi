using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace OtobusOtomasyonu
{
    class BiletAl:Uye
    {
        public void biletal(BiletAl B)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("insert into BiletAl (TC,Ad,Soyad,Telefon,Cinsiyet,Kalkis_Yeri,Inis_Yeri,Tarih,Saat,OtobusTip,ServisDurumu,KoltukNo) Values ('" + Convert.ToDouble(B.TCNO) + "','" + B.AD.ToString() + "','" + B.SOYAD.ToString() + "','" + B.TELEFON.ToString() + "','" + B.CINSIYET.ToString() + "','"+B.KALKIS.ToString()+"','"+B.VARIS.ToString()+"','"+Convert.ToDateTime(B.TARIH)+"','"+B.SAAT.ToString()+"','"+B.OTOBUSTIP.ToString()+"','"+B.SERVISDURUMU.ToString()+"','"+B.KOLTUKNO.ToString()+"')", con);
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
