using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace OtobusOtomasyonu
{
    public partial class Anasayfa : Form
    {
        public OleDbConnection con;
        public OleDbCommand cmd;
        public OleDbDataAdapter da;

        public void baglan()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=|DataDirectory|//VeriTabani.mdb");
            cmd = new OleDbCommand();
            cmd.Connection = con;
        }
        
        public Anasayfa()
        {
            baglan();
            InitializeComponent();
        }
        void Listele()
        {
            dataGridView1.DataSource = uye.Listele();
           
        }
        void Listele2()
        {
            dataGridView2.DataSource = sefer.Listele2();
        }
        uyekayit uye = new uyekayit();
        SeferEkle sefer = new SeferEkle();
        BiletAl bilet = new BiletAl();
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOtobusAra_Click(object sender, EventArgs e)
        {

           
            if (CBBiletTip.Text == "Class")
            {
                gBClass.Visible = true;
                gBSuit.Visible = false;
                
            }
            else if(CBBiletTip.Text == "Suit")
            {
                gBSuit.Visible = true;
                gBClass.Visible = false;
                
            }
           

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(TxtUyeTC.TextLength<11)
            { MessageBox.Show("Tc Kimlik No 11 Haneden Küçük!!!");}
            else { 
            Uye yeniuye = new Uye();
            yeniuye.TCNO =Convert.ToDouble( TxtUyeTC.Text);
           
            yeniuye.AD = TxtUyeAd.Text;
            yeniuye.SOYAD = TxtUyeSoyad.Text;
            yeniuye.TELEFON = MTxtUyeTelNo.Text;
            yeniuye.CINSIYET = CBUyeCinsiyet.Text;
            uye.uyeekle(yeniuye);
            Listele();
            TxtUyeAd.Clear();
            TxtUyeSoyad.Clear();
            TxtUyeTC.Clear();
            MTxtUyeTelNo.Clear();
            CBUyeCinsiyet.Text = " ";}
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Uye eskiuye = new Uye();
            eskiuye = (Uye)dataGridView1.CurrentRow.DataBoundItem;
            Uye yeniuye = new Uye();
            yeniuye.TCNO =Convert.ToDouble( TxtUyeTC.Text);
            yeniuye.AD = TxtUyeAd.Text;
            yeniuye.SOYAD = TxtUyeSoyad.Text;
            yeniuye.TELEFON =MTxtUyeTelNo.Text;
            yeniuye.CINSIYET = CBUyeCinsiyet.Text;
            uye.uyeguncelle(eskiuye, yeniuye);
            Listele();
            TxtUyeAd.Clear();
            TxtUyeSoyad.Clear();
            TxtUyeTC.Clear();
            MTxtUyeTelNo.Clear();
            CBUyeCinsiyet.Text = " ";


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

            try
            {

                cmd.CommandText = "select DISTINCT Kalkis_Yeri from Seferler";
                cmd.CommandType = CommandType.Text;
                con.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    CBKalkis.Items.Add(Reader["Kalkis_Yeri"]);


                }


            }

            finally
            {
                if (con != null)
                {
                    con.Close();

                }
            }
            Listele();
            Listele2();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtUyeTC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            TxtUyeAd.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
           TxtUyeSoyad.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            MTxtUyeTelNo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            CBUyeCinsiyet.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Uye silicenekuye = new Uye();
            silicenekuye = (Uye)dataGridView1.CurrentRow.DataBoundItem;
            uye.uyesil(silicenekuye);
            Listele();
            TxtUyeAd.Clear();
            TxtUyeSoyad.Clear();
            TxtUyeTC.Clear();
            MTxtUyeTelNo.Clear();
            CBUyeCinsiyet.Text = " ";


        }

        private void TxtUyeTelNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeferEkle_Click(object sender, EventArgs e)
        {
            if (TxtSeferKalkis.Text == TxtSeferVaris.Text)
            {
                MessageBox.Show("Kalkis Ve Varis Yeri Aynı Olmamalı....");

            }
            else
            {
            Seferler yenisefer = new Seferler();
            yenisefer.KALKIS = TxtSeferKalkis.Text;
            yenisefer.VARIS = TxtSeferVaris.Text;
            sefer.seferekle(yenisefer);
            
            
            Listele2();
            TxtSeferKalkis.Clear();
            TxtSeferVaris.Clear();
            }
            
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtSeferKalkis.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            TxtSeferVaris.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();           
        }

        private void BtnSeferSil_Click(object sender, EventArgs e)
        {
            Seferler silineceksefer = new Seferler();
            silineceksefer = (Seferler)dataGridView2.CurrentRow.DataBoundItem;
            sefer.sefersil(silineceksefer);
            Listele2();
            TxtSeferKalkis.Clear();
            TxtSeferVaris.Clear();
        }



        private void btnKayitAra_Click(object sender, EventArgs e)
        {
            string TC = TxtBiletTC.Text;
            UyeAra tcara = new UyeAra();
            tcara.UyeGetir(listView1, TC);

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {


                ListViewItem item = listView1.SelectedItems[0];
                TxtBiletTC.Text = item.SubItems[0].Text;
                TxtBiletAd.Text = item.SubItems[1].Text;
                TxtBiletSoyad.Text = item.SubItems[2].Text;
                MTxtBiletTelNo.Text = item.SubItems[3].Text;
                CBBiletCinsiyet.Text = item.SubItems[4].Text;
                



            }
        }

        private void btnAsılBiletAl_Click(object sender, EventArgs e)
        {
            if(TxtBiletTC.TextLength<11)
            {
                MessageBox.Show("Tc Kimlik No 11 Haneden Küçük!!!");
            }
            else { 
            BiletAl biletalan = new BiletAl();
            biletalan.TCNO = Convert.ToDouble(TxtBiletTC.Text);

            biletalan.AD = TxtBiletAd.Text;
            biletalan.SOYAD = TxtBiletSoyad.Text;
            biletalan.TELEFON = MTxtBiletTelNo.Text;
            biletalan.CINSIYET = CBBiletCinsiyet.Text;
            biletalan.KALKIS = CBKalkis.Text;
            biletalan.VARIS = CBVarısYer.Text;
            biletalan.TARIH = Convert.ToDateTime(dTimeTarih.Text);
            biletalan.SAAT = CBBiletSaat.Text;
            biletalan.OTOBUSTIP = CBBiletTip.Text;
            biletalan.SERVISDURUMU = CBBiletServis.Text;
            biletalan.KOLTUKNO = CBBiletKoltuk.Text;



            bilet.biletal(biletalan);

            TxtBiletTC.Clear();
            TxtBiletAd.Clear();
            TxtBiletSoyad.Clear();
            MTxtBiletTelNo.Clear();
            CBBiletCinsiyet.Text = " ";
            CBBiletKoltuk.Text = " ";
            CBBiletSaat.Text = " ";
            CBBiletServis.Text = " ";
            CBBiletTip.Text = " ";
            CBKalkis.Text = " ";
            CBVarısYer.Text = " ";

            MessageBox.Show("Biletiniz Başarıyla Satılmıştır.");
        }
        }

        private void CBKalkis_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            try
            {

                cmd.CommandText = "select * from Seferler Where Kalkis_Yeri='" + CBKalkis.Text + "'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    CBVarısYer.Items.Add(Reader["Inis_Yeri"]);


                }



            }

            finally
            {
                if (con != null)
                {
                    con.Close();

                }
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if(CBBiletCinsiyet.Text=="Bay")
            {
                button52.BackColor = Color.Blue;
                button52.Enabled = false;
            }
            else if(CBBiletCinsiyet.Text=="Bayan")
            {
                button52.BackColor = Color.Red;
                button52.Enabled = false;
            }
            CBBiletKoltuk.Text = "1"; 
        }
    }
}
