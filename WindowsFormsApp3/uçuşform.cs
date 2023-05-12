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
    public partial class UçuşForm : Form
    {
        public UçuşForm()
        {
            InitializeComponent();
        }

        
        UçakEntities2 db = new UçakEntities2();
        private void Form2_Load_1(object sender, EventArgs e)
        {
            dataGridFilm.DataSource = (from x in db.Uçuş
                                          select new
                                          {
                                              x.Uçuş_Id,
                                              x.Uçuş_Adı,
                                              x.Uçuş_Saati,
                                              x.Koltuk.Koltuk_Adı,


                                          }).ToList();

            koltuk_cmb.DisplayMember = "koltuk_Adı";
            koltuk_cmb.ValueMember = "koltuk_Id";

            koltuk_cmb.DataSource = db.koltuk.ToList();
        }

        private void Yenile_btn_Click(object sender, EventArgs e)
        {
            dataGridFilm.DataSource = (from x in db.Uçuş
                                       select new
                                       {
                                           x.Uçuş_Id,
                                           x.Uçuş_Adı,
                                           x.Uçuş_Saati,
                                           x.koltuk.koltuk_Adı,


                                       }).ToList();
        }

        private void Güncelle_btn_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(label4.Text);
            var Uçuş = db.Film.Find(x);
            Uçuş.Film_Adı = FilmAdı_txt.Text;
            Uçuş.Seans_Saati = SeansSaati_txt.Text;
            Uçuş.Salon_Id = (int)Salon_cmb.SelectedValue;
            db.SaveChanges();
            MessageBox.Show("Uçuş Güncellendi");
        }

        private void Sil_btn_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(label4.Text);
            var Uçuş = db.Uçuş.Find(x);
            db.Uçuş.Remove(film);
            db.SaveChanges();
            MessageBox.Show("Uçuş Silindi");
        }

        private void Kaydet_btn_Click(object sender, EventArgs e)
        {
            Uçuş uçuş = new Film();
            uçuş.Uçuş_Adı = FilmAdı_txt.Text;
            uçuş.Uçuş_Adı = SeansSaati_txt.Text;
            Uçuş.koltuk_Id = (int)koltuk_cmb.SelectedValue;
            db.Uçuş.Add(film);
            db.SaveChanges();
            MessageBox.Show("Uçuş Eklendi");
        }

        private void dataGridFilm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridFilm.SelectedCells[0].RowIndex;
            Uçuş film = new Uçuş();

            label4.Text = dataGridFilm.Rows[selected].Cells[0].Value.ToString();
            Uçuşadı_txt.Text = dataGridFilm.Rows[selected].Cells[1].Value.ToString();
            Uçuşsaati_txt.Text = dataGridFilm.Rows[selected].Cells[2].Value.ToString();
            koltuk_cmb.Text = dataGridFilm.Rows[selected].Cells[3].Value.ToString();
        }

    }
}
