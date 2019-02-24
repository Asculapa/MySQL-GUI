using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public class MySqlController
    {
        private MySqlConnection conn = null;
        private DataGridView grid = null;
        private List<string> listOfCommands;

        public MySqlController(MySqlConnection conn,DataGridView grid) {
            this.conn = conn;
            this.grid = grid;
            listOfCommands = new List<string>();
        }

        public bool loadTable(string nameOfTable, string searchLine)
        {
            if (searchLine == null) {
                searchLine = "";
            }

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + nameOfTable + "" + searchLine + ";", conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            grid.DataSource = DS.Tables[0];
            return true;
        }

        public string getDataBase {

            get{
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                return conn.Database;
            }
        }

        public bool loadListView(ListBox list) {
            try
            {
                DataTable t = conn.GetSchema("Tables");
                foreach (DataRow dr in t.Rows)
                {
                    list.Items.Add(dr[2].ToString());
                }
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }

        public bool closeConnection() {

            try
            {
                conn.Close();
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }
        public void addCommand(string command) {
            listOfCommands.Add(command);
        }

        public void backup() {
            MySqlCommand mySql = new MySqlCommand();
            mySql.Connection = conn;

            if (conn.State != ConnectionState.Open) {
                conn.Open();
            }

            MySqlBackup backup = new MySqlBackup(mySql);
            var folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                try
                {
                    backup.ExportToFile(folderName + "MySqlDataBase.sql");
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Error!");
                }

            }
        }

        public MySqlDataReader getKeys(string table,string sschema) {
            string request = "SELECT TABLE_NAME,COLUMN_NAME,CONSTRAINT_NAME, REFERENCED_TABLE_NAME,REFERENCED_COLUMN_NAME " +
          "FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
          "WHERE REFERENCED_TABLE_SCHEMA = '" + sschema + "' ";
            if (table != null) {
                request += "And TABLE_NAME = '" + table + "'; "; 
            }
            else {
                request += ";";
            }
            return executeReader(request);

        }

        public MySqlDataReader executeReader(string command)
        {
            Console.WriteLine(command);
            if (conn.State.ToString() != ConnectionState.Open.ToString())
            {
                conn.Open();
            }

            MySqlCommand myCommand = new MySqlCommand(command, conn);

            try
            {
                MySqlDataReader dr;
                dr = myCommand.ExecuteReader();
                Console.WriteLine("Ok!");
                return dr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Console.WriteLine("executeReader - Error");
                return null;
            }
        }

        public void import()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            MySqlCommand mySql = new MySqlCommand();

            mySql.Connection = conn;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            MySqlBackup backup = new MySqlBackup(mySql);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                try
                {
                    backup.ImportFromFile(selectedFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Error!");
                }
            }
        }

        public bool RunTransactions()
        {
            if (listOfCommands.Count == 0)
            {
                return true;
            }
            if (conn.State.ToString() != ConnectionState.Open.ToString()) {
                conn.Open();
            }
            MySqlCommand myCommand = conn.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = conn.BeginTransaction();
            myCommand.Connection = conn;
            myCommand.Transaction = myTrans;

            try
            {
                foreach (String s in listOfCommands) {
                    myCommand.CommandText = s;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                Console.WriteLine("Both records are written to database.");
                listOfCommands.Clear();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
                listOfCommands.Clear();
                return false;
            }
        }
    }
}
