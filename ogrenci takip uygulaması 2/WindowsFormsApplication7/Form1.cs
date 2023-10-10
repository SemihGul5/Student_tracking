using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tablom2' table. You can move, or remove it, as needed.
            this.tablom2TableAdapter.Fill(this.dataSet1.tablom2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox5.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = pictureBox1.ImageLocation;
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "insert into tablom2(ad,soyad,no,adres,resim) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "','" + textBox5.Text + "')";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("kayıt yapıldı");
            this.tablom2TableAdapter.Fill(this.dataSet1.tablom2);
            sqlConnection1.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "delete from tablom2 where no=" + textBox6.Text + "";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("kayıt silindi");
            this.tablom2TableAdapter.Fill(this.dataSet1.tablom2);
            sqlConnection1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "update tablom2 set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',no='" + textBox4.Text + "',adres='" + richTextBox1.Text + "',resim='" + textBox5.Text + "'";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("kayıt güncelllendi");
            this.tablom2TableAdapter.Fill(this.dataSet1.tablom2);
            sqlConnection1.Close();
        }
    }
}
