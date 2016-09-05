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

namespace Undian
{
    public partial class Tampilan : Form
    {
        public static int constant = 3000;
        public static int loop = 0;
        public static int loop1 = 0;


        Label lbl;

        public Tampilan()
        {
            InitializeComponent();
            SetTimer(); 
            SetTimer2();
            lblrunning.Text = "Pemenang hanya berhak 1 (satu) hadiah. Pemberitahuan pemenang hanya melalui surat resmi bank. Pengambilan hadiah di kantor Bank";
        }

        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        
        public void hadiahchange()
        {
            switch(loop)
            {
                case 1: prize.Text = "SmartPhone Samsung";
                    break;
                case 2: prize.Text = "Mesin Cuci Sanyo";
                    break;
                case 3: prize.Text = "Lemari Es Sharp";
                    break;
                case 4: prize.Text = "TV LED LG";
                    break;
                case 5: prize.Text = "Honda Scoopy";
                    break;
                case 6: prize.Text = "Honda Mobilio";
                    break;
            }
               
        }
        private void slideshow(int lvl)
        {
            List<DataSet> dataSets = new List<DataSet>();
            try
            {
                MySqlConnection conn = connectionstring.getKoneksi();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select hadiah,no_undian,nama from transaksi where level = '"+lvl+"'";
                conn.Open();
                DataSet ds = new DataSet("undian");
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds, "data");
                dataSets.Add(ds);
                //dataSlideShow.DataSource = ds;
                //dataSlideShow.DataMember = "data";
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void checktime()
        {
            int a;
            
            slideshow(loop);
            a = loop + 1;
            loop = a;
        }

        private void SetTimer()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = constant;//menit = xx * 60 detik
            timer1.Enabled = true;
            timer1.Start();
            loop = loop + 1;
            timer1.Tick += new System.EventHandler(timer1_Tick);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hadiahchange();
            checktime();
            if(loop > 6)
            {
                loop = 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>

        private void SetTimer2()
        {
            System.Windows.Forms.Timer timerruningtext = new System.Windows.Forms.Timer();
            timerruningtext.Interval = 100;//menit = xx * 60 detik
            timerruningtext.Enabled = true;
            timerruningtext.Start();
            loop1 = loop1 - 10;
            timerruningtext.Tick += new System.EventHandler(timerruningtext_Tick);

        }

        private void timerruningtext_Tick(object sender, EventArgs e)
        {
            checklocationx();
            if (loop1 <= -1400)
            {
                loop1 = 800;
            }
        }
        public void checklocationx()
        {
            int a;

            lblrunning.Location = new System.Drawing.Point(loop1);
            a = loop1 - 10;
            loop1 = a;
        }

        
    }
}
