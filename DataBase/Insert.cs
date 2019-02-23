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
    public partial class Insert : Form
    {
        private Dictionary<Label, Control> map;
        private string tableName, database;
        private MySqlController controller;

        public Insert(DataGridViewColumnCollection columns, MySqlController controller, string tableName)
        {
            InitializeComponent();
            map = new Dictionary<Label, Control>();
            this.tableName = tableName;
            this.database = controller.getDataBase;
            this.controller = controller;
            addComponents(columns);
        }

        public string ReturnValue { get; set; }

        private void addComponents(DataGridViewColumnCollection columns) {

            Dictionary<string, List<string>> keys = getListOfKeys(controller.getKeys(tableName, database));

            int x = 10, y = 20;

            for (int a = 0; a < columns.Count; a++) {
                Label l = new Label();
                l.AutoSize = true;
                l.Text = columns[a].HeaderText;
                l.Parent = panel1;
                Control box;
                if (keys != null && keys.ContainsKey(columns[a].HeaderText))
                {
                    box = new ComboBox();
                    foreach (string s in keys[columns[a].HeaderText])
                    {
                        ((ComboBox) box).Items.Add(s);
                        box.Size = new Size(100,20);
                    }
                }
                else {
                    box = new TextBox();
                }
                if (a != 0) {
                    x += box.Location.X + box.Width + 10;
                }
                box.Location = new Point(x, y);
                l.Location = new Point(x, y / 4);
                box.Parent = panel1;
                map.Add(l, box);
            }
        }

        private Dictionary<string, List<string>> getListOfKeys(MySqlDataReader keys)
        {
            if (keys == null || !keys.HasRows)
            {
                Console.WriteLine("Null");
                keys.Close();
                return null;
            }

            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
            List<string> thisColumns = new List<string>();
            List<string> tables = new List<string>();
            List<string> columns = new List<string>();

            while (keys.Read()){
                 thisColumns.Add(keys.GetString("COLUMN_NAME"));
                 tables.Add(keys.GetString("REFERENCED_TABLE_NAME"));
                 columns.Add(keys.GetString("REFERENCED_COLUMN_NAME"));
            }

            keys.Close();

            for (int a = 0; a < columns.Count; a++) {
                List<string> list = getListOfColumn(tables[a], database, columns[a]);
                pairs.Add(thisColumns[a], list);
            }

            foreach (KeyValuePair<string, List<string>> entry in pairs)
            {
                Console.WriteLine(entry.Key + " = " );
                foreach (string s in entry.Value) {
                    Console.Write(" " + s);
                }
            }

            return pairs;
        }

        private List<string> getListOfColumn(string table, string database, string column)
        {
            MySqlDataReader columns = controller.executeReader("SELECT "+ column +" FROM " + table+ ";");
           
            if (columns == null) {
                columns.Close();
                return new List<string>();
            }
            List<string> list = new List<string>();
            while (columns.Read()) {
                list.Add(columns.GetString(column));
            }
            columns.Close();
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string request = "Insert into " + tableName + createInsert("key") + "values" + createInsert("value") + ";";
            this.ReturnValue = request;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string createInsert(string keyOrvalue) {

            string request = " (";

            for (int index = 0; index < map.Count; index++)
            {
                var item = map.ElementAt(index);
                Control itemValue;
                if (keyOrvalue == "key")
                {
                    itemValue = item.Key;
                }
                else {
                    itemValue = item.Value;

                }

                if (itemValue.Text != "" && item.Value.Text != "")
                {
                    if (index != 0)
                    {
                        request += ",";
                    }

                    request += keyOrvalue == "value"?DB.getByType(itemValue.Text).Substring(3): itemValue.Text;
                }
                else {
                    continue;
                }
             
            }
            request += ") ";
            return request;
        }
    }
}
