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

namespace DataBase
{
    public partial class DB : Form
    {
        MySqlController controller = null;
        string selectedItem;

        public DB(MySqlConnection conn)
        {
            InitializeComponent();
            controller = new MySqlController(conn,dataGridView1);
        }

        private void DB_Load(object sender, EventArgs e)
        {
            if (controller.loadListView(listBox1))
            {
                Console.WriteLine("ListBox is filled");
            }
            else
            {
                Console.WriteLine("ListBox is not filled");
            }
        }

        private void DB_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (controller.closeConnection())
            {
                Console.WriteLine("Connection is closed");
            }
            else
            {
                Console.WriteLine("Connection is not closed");

            }
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) { return; }

            string item = listBox1.SelectedItem.ToString();

            if (selectedItem == item) { return; }

            selectedItem = item;
            if (!controller.loadTable(selectedItem))
            {
                MessageBox.Show("Can't load table " + selectedItem);
            }
        }
    }
}
