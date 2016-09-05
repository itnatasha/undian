using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Undian.Control;
using Undian.Entity;
using System.Drawing;
namespace Undian
{
    public partial class Kupon : Form
    {

        private int loop=1000;
        //private int slidelocation = 1000;
        public ComboBox box1;


        tampilPemenang tp = new tampilPemenang();
        dataPememang dp = new dataPememang();

        public Kupon()
        {
            InitializeComponent();
            SetTimer();
            labelslide.Text = "Pemenang hanya berhak 1 (satu) hadiah. Pemberitahuan pemenang hanya melalui surat resmi bank. Pengambilan hadiah di kantor Bank";
        }
        public List<DataSet> dataSets = new List<DataSet>();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            

            if (comboHadiah.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtNoUndian.Text))
            {
                MessageBox.Show("Isi dahulu hadiah dan no undiannya!!");
            }
            else
            {
                dp.tampildataUndian(txtNoUndian.Text.Trim(), labelNama, labelnorek, labelCIF, labelStatus);
                labelhadiah.Text = comboHadiah.SelectedItem.ToString();
                //dp.tampildataUndian(txtNoUndian.ToString(),labelNama,labelnorek,labelCIF,labelStatus);
                //tp.insertPemenang(labelnorek.Text.ToString(), labelCIF.Text.ToString(), txtNoUndian.Text.ToString(), labelNama.Text.ToString(), labelStatus.Text.ToString(), labelhadiah.Text.ToString(), comboHadiah.SelectedIndex + 1);
                
                DialogResult dialogResult = MessageBox.Show("Masukkan data ???", "Peringatan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    if(labelStatus.Text.ToString()=="AKTIF")
                    {
                        tp.insertPemenang(labelnorek.Text.ToString(), labelCIF.Text.ToString(), txtNoUndian.Text.ToString(), labelNama.Text.ToString(), labelStatus.Text.ToString(), labelhadiah.Text.ToString(), comboHadiah.SelectedIndex + 1);
                    }
                    else { MessageBox.Show("No Undian Hangus,silahkan masukkan No undian yang lain"); }
                    labelCIF.Visible = true;
                    labelhadiah.Visible = true;
                    labelnorek.Visible = true;
                    labelStatus.Visible = true;
                    tp.getPemenang(dataGridView1);
                    //MessageBox.Show(comboHadiah.SelectedIndex.ToString());
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                    //do something else
                }
            }
            
        }

        private void SetTimer()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 100;//menit = xx * 60 detik
            timer1.Start();
            loop = loop - 10;
            timer1.Tick += new System.EventHandler(timerrunningtext_Tick);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void buttonshow_Click(object sender, EventArgs e)
        {

            Tampilan show = new Tampilan(); 
            Screen[] sc;

            //setting dual monitor

            //sc = Screen.AllScreens;
            //show.Location = new System.Drawing.Point(sc[1].Bounds.X, 0);
            show.Show();
        }

        private void timerrunningtext_Tick(object sender, EventArgs e)
        {
            checklocationx();
            if (loop <= -1400)
            {
                loop = 1000;
            }
        }

        public void checklocationx()
        {
            int a;

            labelslide.Location = new System.Drawing.Point(loop);
            a = loop - 10;
            loop = a;
        }

        private void Kupon_Load(object sender, EventArgs e)
        {

        }


    }
}
