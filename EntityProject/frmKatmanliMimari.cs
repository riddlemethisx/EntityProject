using DAL;              //LIBRARY'E REFERANS OLARAK EKLEMEK YETMİYOR. O LIBRARYLERDEKİ KODLARI KULLANABİLMEK İÇİN
                        //BU KODA KÜTÜPHANE OLARAK O LIBRARYLERİ EKLEMELİYİZ
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProject
{
    public partial class frmKatmanliMimari : Form
    {

       
        

        public frmKatmanliMimari()
        {
            InitializeComponent();
        }


        BirimDAL bdal = new BirimDAL();
        Personeller p = new Personeller();
        PersonelDAL pdal = new PersonelDAL();
        ModelPersonelEntity db = new ModelPersonelEntity();


        public void Yenile()
        {
            dataGridView1.DataSource = pdal.PersonellerGetir(db, x => x.AdiSoyadi.Contains(txtAra.Text));   //arama texttindeki isme sahip veri personeldal'daki PersonellerGetir fonk'na gönderiliyor


            cmbBirim.DataSource = bdal.GetList();   //combobox'a birimdal daki veriler gelecek
        }


        void ClearDataBinding()
        {
            foreach (Control item in this.Controls)
            {
                item.DataBindings.Clear();
            }
        }


        //datagridviewda seçilen kişi bilgileri textboxlara aktarılıyor
        void Data_Binding(Personeller person)   //person1
        {
            ClearDataBinding();
            this.p = person;
            txtPersonelID.DataBindings.Add("Text", p, "PersonelID");
            txtAdiSoyadi.DataBindings.Add("Text", p, "AdiSoyadi");
            txtTelefon.DataBindings.Add("Text", p, "Telefon");
            txtAdres.DataBindings.Add("Text", p, "Adres");
            txtEmail.DataBindings.Add("Text", p, "Email");
            cmbBirim.DataBindings.Add("SelectedValue", p, "BirimID",true);
            dateTimePicker1.DataBindings.Add("Text", p, "Tarih");
            chckIsActive.DataBindings.Add("CheckState", p, "IsActive",true);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            #region ÖRNEK ÇAĞIRMA
            //BU ŞEKİLDE ÇAĞIRABİLİRİZ
            //BirimDAL bdal = new BirimDAL();
            //Birimler b = new Birimler();
            //bdal.GetList(b);

            //PersonelDAL pdal = new PersonelDAL();
            //Personeller p = new Personeller();
            //pdal.GetList(p);
            #endregion

            Yenile();
            Data_Binding(new Personeller());    //personeller tablosundaki veriler Data_Binding fonk.na iletiliyor


        }


        Personeller VerileriCek()
        {
            Personeller b = new Personeller();
            b.PersonelID = int.Parse( txtPersonelID.Text);
            b.AdiSoyadi = txtAdiSoyadi.Text;
            b.Telefon = txtTelefon.Text;
            b.Adres = txtAdres.Text;
            b.Email = txtEmail.Text;
            b.BirimID = cmbBirim.SelectedIndex + 1;
            b.Tarih = dateTimePicker1.Value;
            b.IsActive = chckIsActive.Checked;
            return b;
        }


        private void txtAra_EditValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pdal.PersonellerGetir(db,x => x.AdiSoyadi.Contains(txtAra.Text));
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Birimler model = new Birimler
            //{
            //    Aciklama = "Test",
            //    BirimAdi = "testbirimadi",
            //};
            //pdal.AddorUpdate(model);


            pdal.AddorUpdate(VerileriCek());
            Yenile();
            Data_Binding(new Personeller());

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int personelid = int.Parse(dataGridView1.CurrentRow.Cells["PersonelID"].Value.ToString());
            Data_Binding(pdal.GetByFilter(x => x.PersonelID == personelid));    //personeldal'daki veriler arasından tıklanan hücredeki personelid'si aynı olanı getirir---GetByFilter TEK KAYIT ÇEKMEKTİR
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Data_Binding(new Personeller());
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int personelid = int.Parse(dataGridView1.CurrentRow.Cells["PersonelID"].Value.ToString());
            pdal.Delete(p=> p.PersonelID == personelid);
            pdal.Save();
            Yenile();
            Data_Binding(new Personeller());
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Yenile();
        }
    }
}
