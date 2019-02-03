using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    class MySqlController
    {
        MySqlConnection conn = null;
        DataGridView grid = null;

        public MySqlController(MySqlConnection conn,DataGridView grid) {
            this.conn = conn;
            this.grid = grid;
        }

        public bool loadTable(string nameOfTable)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + nameOfTable + ";", conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            grid.DataSource = DS.Tables[0];

            return true;
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
    }
}
