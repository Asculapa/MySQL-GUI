using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Insert : Form
    {
        private Dictionary<Label,TextBox> map;
        private int x = 10, y = 20;
        private string tableName;
        public Insert(DataGridViewColumnCollection columns,string table)
        {
            InitializeComponent();
            map = new Dictionary<Label, TextBox>();
            tableName = table;
            addComponents(columns);
        }

        public string ReturnValue { get; set; }

        private void addComponents(DataGridViewColumnCollection columns) {

            for (int a = 0; a < columns.Count; a++) {
                Label l = new Label();
                l.AutoSize = true;
                l.Text = columns[a].HeaderText;
                l.Parent = panel1;
                TextBox textBox = new TextBox();
                if (a != 0) {
                    x += textBox.Location.X + textBox.Width + 10;
                }
                textBox.Location = new Point(x,y);
                l.Location = new Point(x,y/4);
                textBox.Parent = panel1;
                map.Add(l, textBox);
            }
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
