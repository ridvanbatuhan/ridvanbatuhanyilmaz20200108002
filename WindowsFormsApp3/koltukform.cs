using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class koltukForm : Form
    {
        public koltukForm()
        {
            InitializeComponent();
        }
        koltukEntities2 db = new koltukEntities2();
        private void SalonEkle_Load(object sender, EventArgs e)
        {
            dataGridkoltuk.DataSource = (from x in db.Salon
                                       select new
                                       {
                                           x.koltuk_Id,
                                           x.koltuk_Adı,
                                           x.Koltuk_Sayısı,


                                       }).ToList();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Yenile_btn_Click(object sender, EventArgs e)
        {
            dataGridkoltuk.DataSource = (from x in db.koltuk
                                        select new
                                        {
                                            x.koltuk_Id,
                                            x.koltuk_Adı,
                                            x.Koltuk_Sayısı,


                                        }).ToList();
        }

        private void Kaydet_btn_Click(object sender, EventArgs e)
        {
            koltuk koltuk = new koltuk();
            koltuk.koltukn_Adı = koltukAd_txt.Text;
            koltuk.Koltuk_Sayısı = int.Parse(KoltukSys_txt.Text.ToString());
            db.koltuk.Add(koltuk);
            db.SaveChanges();
            MessageBox.Show("koltuk Eklendi");
        }

        private void dataGridkoltuk_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridSalon.SelectedCells[0].RowIndex;
            koltuk salon = new koltuk();

            label3.Text = dataGridSalon.Rows[selected].Cells[0].Value.ToString();
            SalonAd_txt.Text = dataGridSalon.Rows[selected].Cells[1].Value.ToString();
            KoltukSys_txt.Text = dataGridSalon.Rows[selected].Cells[2].Value.ToString();

            
            
        }

        private void Güncelle_btn_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(label3.Text);
            var koltuk = db.koltuk.Find(x);
            salon.Koltuk_Adı = koltukAd_txt.Text;
            salon.Koltuk_Sayısı = int.Parse(KoltukSys_txt.Text.ToString());
            db.SaveChanges();
            MessageBox.Show("koltuk Güncellendi");
        }

        private void Sil_btn_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(label3.Text);
            var koltuk = db.koltuk.Find(x);
            db.koltuk.Remove(koltuk);
            db.SaveChanges();
            MessageBox.Show("Koltuk Silindi");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
