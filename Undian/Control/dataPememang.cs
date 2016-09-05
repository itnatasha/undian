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
using Undian.Entity;

namespace Undian.Control
{
    class dataPememang
    {
        
        public void tampildataUndian(string noundian, Label _nama,Label _no_rek, Label _noCif, Label _ket)
        {
            try
            {
                MySqlConnection conn = connectionstring.getKoneksi();
                MySqlDataReader myReader = null;
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select nama, no_rek,cif,ket from master where awal <= " + noundian.ToString() + "  and akhir > " + noundian.ToString() + "";
                conn.Open();
                myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _nama.Text = myReader.GetValue(0).ToString();
                        _no_rek.Text = myReader.GetValue(1).ToString();
                        _noCif.Text = myReader.GetValue(2).ToString();
                        _ket.Text = myReader.GetValue(3).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Maaf, no undian "+noundian.Trim()+" tidak ada dalam database");
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
