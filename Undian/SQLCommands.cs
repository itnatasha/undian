using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Undian
{
    public class SQLCommands
    {
        MySqlConnection SQLCon = new MySqlConnection();

        public SQLCommands()
        {
            try
            {

                String conSTR = "SERVER=localhost;" +
                "DATABASE=undian;" +
                "UID=root;" +
                "PASSWORD=;";
                SQLCon = new MySqlConnection(conSTR);
                SQLCon.Open();

            }
            catch (Exception ex)
            {
                 MessageBox.Show("SQLCommands ERROR----" + ex.Message);
                SQLCon.Dispose();
                SQLCon.Close();
                throw ex;
            }

        }

        public void SQLConnectionClose()
        {
            try
            {
                SQLCon.Dispose();
                SQLCon.Close();
            }
            catch (MySqlException err)
            {
                 MessageBox.Show("SQLConnectionClose ERROR----" + err.Message);
            }
        }

        public MySqlDataReader SQLSelect(string SQLCommand)
        {
            MySqlDataReader reader = null;

            MySqlCommand SQLCmd = new MySqlCommand(SQLCommand, SQLCon);
            try
            {
                SQLCmd.ExecuteNonQuery();
                reader = SQLCmd.ExecuteReader();
            }
            catch (MySqlException err)
            {
                 MessageBox.Show("'SQLSelect' ERROR---->" + err.Message);
                throw new Exception(err.Message);
            }
            return reader;
        }

        public void SQLStringCmd(string SQLCommand)
        {
            MySqlCommand SQLCmd = new MySqlCommand(SQLCommand, SQLCon);
            try
            {
                SQLCmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Exception ex = new Exception();
                 MessageBox.Show("'SQLStringCmd' ERROR---->" + err.Message);
                 MessageBox.Show("'SQLStringCmd' ERROR---->" + ex.Message);
            }
        }

        public int SQLCOUNT(string SQLCommand)
        {
            object result;
            int row;

            MySqlCommand SQLCmd = new MySqlCommand(SQLCommand, SQLCon);
            try
            {
                result = SQLCmd.ExecuteScalar();

                if (result != null)
                {
                    row = Convert.ToInt32(result);
                }
                else
                {
                    row = 0;
                }
            }
            catch (MySqlException err)
            {
                 MessageBox.Show("'SQLCountCmd' ERROR---->" + err.Message);
                throw new Exception(err.Message);
            }
            return row;
        }

    }






    //public class SQLServer
    //{
    //    MySqlConnection SQLCon = new MySqlConnection();

    //    public SQLServer()
    //    {
    //        try
    //        {
    //            string conSTR = "SERVER=192.168.202.65 ; USER ID=root ; PASSWORD= ; DATABASE=antrian_naava;";
    //            SQLCon = new MySqlConnection(conSTR);
    //            SQLCon.Open();

    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("SQLCommands ERROR----" + ex.Message);
    //            SQLCon.Dispose();
    //            SQLCon.Close();
    //            throw ex;
    //        }

    //    }

    //    public void SQLConnectionClose()
    //    {
    //        try
    //        {
    //            SQLCon.Dispose();
    //            SQLCon.Close();
    //        }
    //        catch (MySqlException err)
    //        {
    //            MessageBox.Show("SQLConnectionClose ERROR----" + err.Message);
    //        }
    //    }

    //    public MySqlDataReader SQLSelect(string SQLCommand)
    //    {
    //        MySqlDataReader reader = null;

    //        MySqlCommand SQLCmd = new MySqlCommand(SQLCommand, SQLCon);
    //        try
    //        {
    //            SQLCmd.ExecuteNonQuery();
    //            reader = SQLCmd.ExecuteReader();
    //        }
    //        catch (MySqlException err)
    //        {
    //            MessageBox.Show("'SQLSelect' ERROR---->" + err.Message);
    //            throw new Exception(err.Message);
    //        }
    //        return reader;
    //    }

    //    public void SQLStringCmd(string SQLCommand)
    //    {
    //        MySqlCommand SQLCmd = new MySqlCommand(SQLCommand, SQLCon);
    //        try
    //        {
    //            SQLCmd.ExecuteNonQuery();
    //        }
    //        catch (MySqlException err)
    //        {
    //            Exception ex = new Exception();
    //            MessageBox.Show("'SQLStringCmd' ERROR---->" + err.Message);
    //            MessageBox.Show("'SQLStringCmd' ERROR---->" + ex.Message);
    //        }
    //    }

    //    public int SQLCOUNT(string SQLCommand)
    //    {
    //        object result;
    //        int row;

    //        MySqlCommand SQLCmd = new MySqlCommand(SQLCommand, SQLCon);
    //        try
    //        {
    //            result = SQLCmd.ExecuteScalar();

    //            if (result != null)
    //            {
    //                row = Convert.ToInt32(result);
    //            }
    //            else
    //            {
    //                row = 0;
    //            }
    //        }
    //        catch (MySqlException err)
    //        {
    //            MessageBox.Show("'SQLCountCmd' ERROR---->" + err.Message);
    //            throw new Exception(err.Message);
    //        }
    //        return row;
    //    }

    //}
}
