using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.DataGridTextBoxColumn;
namespace csvFile
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)

        {

            //dataGridView a 3 sütun ekliyoruz.
           


        }



            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void getData(string filePath)
        {
            DataTable dataTable = new DataTable();
            string[] satir = System.IO.File.ReadAllLines(filePath);
            if (satir.Length > 0)
            {
                //başlık satırı
                string firstTitle = satir[0];
                string[] title = firstTitle.Split(',');
                foreach (string basliklar in title)
                {
                    dataTable.Columns.Add(new DataColumn(basliklar));
                }
                //Veriler için kodlarımız
                for (int i = 1; i < satir.Length; i++)
                {
                    string[] veriler = satir[i].Split(',');
                    DataRow dataRow = dataTable.NewRow();
                    int columnIndex = 0;
                    foreach (string data in title)
                    {
                        dataRow[data] = veriler[columnIndex++];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            if (dataTable.Rows.Count > 0)
            {
                dataGridView1.DataSource = dataTable;
            }

        }

        private void dosya_oku_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            getData(textBox1.Text);

        }

        private void güncelle_Click(object sender, EventArgs e)
        {

      //oluşan griedviewi csv dosyasına ekleyip yeni dosyayı tekrar gridviewe yazdır
           
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            getData(textBox1.Text);

        }

        private void ekle_Click(object sender, EventArgs e)
        {
            
            int row= 0; 
            dataGridView1.Rows[row].Selected = true;

           
            int column = 0; 
            dataGridView1.Rows[row].Cells[column].Value = textBox2.Text;
            column++;
            dataGridView1.Rows[row].Cells[column].Value = textBox3.Text;
            column  ++;
            dataGridView1.Rows[row].Cells[column].Value = textBox4.Text;



            MessageBox.Show("DEĞİŞİKLİĞİ KAYDETMEK İÇİN OK TUŞUNA BASINIZ...");

        }

        private void sil_Click(object sender, EventArgs e)
        {
            if
(dataGridView1.SelectedRows.Count > 0)

            {

                //seçili satırı siler.


                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("DEĞİŞİKLİĞİ KAYDETMEK İÇİN OK TUŞUNA BASINIZ...");
            }
            else
            {

                MessageBox.Show("SİLİNECEK SATIRI SEÇMEDİNİZ!");

            }




        }

    


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter StreamWriter = new StreamWriter(@"C:\Users\EXCALIBUR\Videos\mammals.csv"))
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    StreamWriter.Write(dataGridView1.Columns[i].HeaderText);
                    if (i != dataGridView1.Columns.Count - 1)
                    {
                        StreamWriter.Write(",");
                    }
                }
                StreamWriter.Write(StreamWriter.NewLine);

                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        StreamWriter.Write(row.Cells[i].Value);
                        if (i != dataGridView1.Columns.Count - 1)
                        {
                            StreamWriter.Write(",");
                        }
                    }
                    StreamWriter.Write(StreamWriter.NewLine);
                }
            }
            MessageBox.Show("DOSYA GÜNCELLENDİ...");

        }
    }
    }


