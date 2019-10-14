using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace DataBase
{
    public partial class Search : Form
    {
        List<Control> listOfControls;
        MySqlController controller;
        string table;
        int operatorX, columnsX, equalX, resultX, newLineX, delLineX;
        int y, indent = 45;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Equal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void delLine_Click(object sender, EventArgs e)
        {
            if (listOfControls.Count <= 3)
            {
                return;
            }
            for (int a = listOfControls.Count - 4; a < listOfControls.Count;)
            {
                Control item = listOfControls[a];
                listOfControls.Remove(item);
                item.Dispose();
            }

            y -= indent;
            this.newLine.Location = new Point(newLineX, y);
            this.delLine.Location = new Point(delLineX, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string request = " WHERE ";
            foreach (Control item in listOfControls)
            {
                if (item is TextBox)
                {
                    request += DB.getByType(item.Text).Substring(3) + " ";
                }
                else
                {
                    if (item.Text == "") {
                        MessageBox.Show("Fill in all the fields!");
                        return;
                    }
                    request += item.Text + " ";
                }
            }
            controller.loadTable(table, request);
        }

        public Search(MySqlController controller, string table)
        {
            InitializeComponent();
            listOfControls = new List<Control>();
            this.controller = controller;
            this.table = table;
            this.y = mySqlOperator.Location.Y;

            operatorX = mySqlOperator.Location.X;
            columnsX = columns.Location.X;
            equalX = equal.Location.X;
            resultX = result.Location.X;
            newLineX = newLine.Location.X;
            delLineX = delLine.Location.X;

            foreach (var item in createColumns().Items)
            {
                columns.Items.Add(item.ToString());
            }

            foreach (var item in createOperators().Items)
            {
                equal.Items.Add(item.ToString());
            }

            listOfControls.Add(columns);
            listOfControls.Add(equal);
            listOfControls.Add(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listOfControls.Count >= 23) {
                return;
            }
            y += indent;
            ComboBox operators = new ComboBox();
            operators.Items.Add("AND");
            operators.Items.Add("OR");
            operators.Location = new Point(operatorX,y);
            operators.Size = this.mySqlOperator.Size;
            operators.Parent = panel1;
            listOfControls.Add(operators);

            ComboBox columns = createColumns();
            columns.Location = new Point(columnsX,y);
            columns.Parent = panel1;
            listOfControls.Add(columns);

            ComboBox equal = createOperators();
            equal.Size = this.equal.Size;
            equal.Location = new Point(equalX,y);
            equal.Parent = panel1;
            listOfControls.Add(equal);

            TextBox result = new TextBox();
            result.Size = this.result.Size;
            result.Location = new Point(resultX,y);
            result.Parent = panel1;
            listOfControls.Add(result);

            this.newLine.Location = new Point(newLineX, y);
            this.delLine.Location = new Point(delLineX, y);
            
        }

        private ComboBox createColumns()
        {
            ComboBox columns = new ComboBox();
            MySqlDataReader dataReader = controller.executeReader("SHOW COLUMNS FROM " + table + ";");
            while (dataReader.Read())
            {
                columns.Items.Add(dataReader.GetString("Field"));
            }
            dataReader.Close();
            return columns;
        }

        private ComboBox createOperators()
        {
            ComboBox box = new ComboBox();
            box.Items.Add("=");
            box.Items.Add("<=");
            box.Items.Add(">=");
            box.Items.Add("<");
            box.Items.Add(">");
            box.Items.Add("NOT");
            return box;
        }
    }
}
