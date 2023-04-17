using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace OtobusOtomasyonu
{
    class Uye
    {
       public OleDbConnection con;
      public  OleDbCommand cmd;
        public OleDbDataAdapter da;
        public Uye()
        {
            baglan();
        }
        public void baglan()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=|DataDirectory|//VeriTabani.mdb");
            cmd = new OleDbCommand();
            cmd.Connection = con;
        }


        public List<Uye> Listele()
        {
            try
            {
                List<Uye> uyeListesi = new List<Uye>();
                cmd.CommandText = "select * from UyeKayit";
                cmd.CommandType = CommandType.Text;
                con.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    Uye k = new Uye();
                    k.TCNO = Convert.ToDouble(Reader[0].ToString());
                    k.AD = Reader[1].ToString();
                    k.SOYAD = Reader[2].ToString();
                    k.TELEFON = Reader[3].ToString();
                    k.CINSIYET = Reader[4].ToString();
                    uyeListesi.Add(k);

                }
                return uyeListesi;

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


        double TC;
        public double TCNO
        {
            get { return TC; }
            set
            {
                
                TC = value;
            }
        }

        string Ad;
        public string AD
        {
            get { return Ad; }
            set { Ad = value; }
        }

         string Soyad;
        public string SOYAD
        {
            get { return Soyad; }
            set { Soyad = value; }
        }

         string Telefon;
        public string TELEFON
        {
            get { return Telefon; }
            set { Telefon = value; }
        }

        string Cinsiyet;
        public string CINSIYET
        {
            get { return Cinsiyet; }
            set { Cinsiyet = value; }
        }

        string kalkis;
        public string KALKIS
        {
            get { return kalkis; }
            set { kalkis = value; }
        }

        string varis;
        public string VARIS
        {
            get { return varis; }
            set { varis = value; }
        }

       private DateTime tarih;
        public DateTime TARIH
        {
            get { return tarih; }
            set { tarih = value; }
        }

        string saat;
        public string SAAT
        {
            get { return saat; }
            set { saat = value; }
        }

        string otobustip;
        public string OTOBUSTIP
        {
            get { return otobustip; }
            set { otobustip = value; }
        }

        string servisdurumu;
        public string SERVISDURUMU
        {
            get { return servisdurumu; }
            set { servisdurumu = value; }
        }

        string koltukno;
        public string KOLTUKNO
        {
            get { return koltukno; }
            set { koltukno = value; }
        }
        
        

    }
}
