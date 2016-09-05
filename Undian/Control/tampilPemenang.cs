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
    class tampilPemenang
    {
        SQLCommands mysql;
        public void insertPemenang(string _norek,string _nocif,string _noundian,string _nama,string _status,string _hadiah ,int level)
        {

            //MySqlCommand cmd; 
            MySqlDataReader reader = null;

            try
            {
                mysql = new SQLCommands();
                //MySqlConnection conn = connectionstring.getKoneksi();
                //MySqlCommand command = conn.CreateCommand();
                //conn.Open();               
                //MySqlCommand cmd = new MySqlCommand(cmdtext2, conn);
                //cmd.ExecuteNonQuery();

                string cmdtext2 = "select * from transaksi where no_cif = '" + _nocif.ToString() + "'";

                reader = mysql.SQLSelect(cmdtext2);
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["level"]) < level)
                        {
                            reader.Close();
                            DialogResult dialogResult = MessageBox.Show("NO CIF sudah ada, gantikan hadiahnya ???", "Peringatan", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string update = "Update transaksi set hadiah='" + _hadiah.ToString() + "', level = '" + level.ToString() + "',no_undian = '" + _noundian.ToString() + "' where no_cif = '" + _nocif.ToString() + "'";
                                //MySqlCommand cmd2 = new MySqlCommand(update, conn);
                                //cmd2.ExecuteNonQuery();
                                mysql.SQLStringCmd(update);
                            }
                            else if (dialogResult == DialogResult.No)
                            {

                                //do something else
                            }
                        }
                    }
                    else
                    {
                        reader.Close();
                        string cmdText = "INSERT INTO transaksi(no_rek,no_cif,no_undian,nama,status,hadiah,level) VALUES ('" + _norek.ToString() + "', '" + _nocif.ToString() + "', '" + _noundian.ToString() + "','" + _nama.ToString() + "','" + _status.ToString() + "','" + _hadiah.ToString() + "','" + level + "')";
                        //MySqlCommand cmd3 = new MySqlCommand(cmdText, conn);
                        //cmd3.ExecuteNonQuery();
                        mysql.SQLStringCmd(cmdText);
                    }

                //conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            finally {
                mysql.SQLConnectionClose();
            }
        }
        
        public void getPemenang(DataGridView dg)
        {
            List<DataSet> dataSets = new List<DataSet>();
            try
            {
                MySqlConnection conn = connectionstring.getKoneksi();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select no_rek as 'No Rekening',no_undian as 'Undian',hadiah from transaksi order by hadiah";
                conn.Open();
                DataSet ds = new DataSet("undian");
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds, "data");
                dataSets.Add(ds);
                dg.DataSource = ds;
                dg.DataMember = "data";
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
