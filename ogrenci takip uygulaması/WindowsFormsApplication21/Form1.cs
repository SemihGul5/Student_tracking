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

namespace WindowsFormsApplication21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ogrenci.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();



        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from ogrenci", baglanti);
            adtr.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables["ogrenci"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.kayitog' table. You can move, or remove it, as needed.
            this.kayitogTableAdapter.Fill(this.dataSet1.kayitog);

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = pictureBox1.ImageLocation;
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "insert into kayitog(ad,soyad,tc,resim) values ('" + textBox2.Text + "','" + textBox3.Text + "'," +Convert.ToInt32(textBox4.Text) + ",'" + textBox5.Text + "')";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("KAYIT YAPILDI");
            this.kayitogTableAdapter.Fill(this.dataSet1.kayitog);
            sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "delete from kayitog where tc=('"+textBox6.Text+"')";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("KAYIT SİLİNDİ");
            this.kayitogTableAdapter.Fill(this.dataSet1.kayitog);
            sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "update kayitog set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',resim='" + textBox5.Text + "'where tc='" + textBox4.Text + "'";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("KAYIT GÜNCELLENDİ");
            this.kayitogTableAdapter.Fill(this.dataSet1.kayitog);
            sqlConnection1.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
       
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            
            adtr = new OleDbDataAdapter("SElect *from ogrenci where ogr_ad like '" + textBox2.Text + "%'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            adtr.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables["ogrenci"];
            baglanti.Close();
        }
    }
}
