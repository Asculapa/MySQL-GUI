using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Report : Form
    {
        List<TextBox> textBoxes = new List<TextBox>();
        List<TextBox> textBoxesSql = new List<TextBox>();
        int labelSize = 16;

        MySqlConnection conn;
        public Report(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void LabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTextBox(false);
        }

        private void Report_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void SqlLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTextBox(true);
        }

        private void createTextBox(bool sql) {
            TextBox textBox = new TextBox();
            textBox.AutoSize = true;
            textBox.Parent = this;
            textBox.Location = new Point(10, 10);
            textBox.Font = new Font(Font.FontFamily, labelSize);
            textBox.Visible = true;
            textBox.Text = "Label " + textBoxes.Count;
            textBox.TextChanged += delegate (object sender, EventArgs e)
            {
                Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
                if (textBox.Text.Length == 0) {
                    if (sql)
                    {
                        textBoxesSql.Remove(textBox);
                    }
                    else {
                        textBoxes.Remove(textBox);
                    }
                    this.Controls.Remove(textBox);
                }
                textBox.Width = size.Width;
                textBox.Height = size.Height;
            };
            Helper.ControlMover.Init(textBox);
            if (sql) {
                textBoxesSql.Add(textBox);
                textBox.BackColor = Color.Red;
                return;
            }
            textBoxes.Add(textBox);
        }

        private void MakeSQLQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = Interaction.InputBox("SQL", "Input SQL code here", "");

            if (sql.Length == 0)
            {
                return;
            }

            try
            {
                DataSet DS = getDataSet(sql);

                if (DS.Tables.Count != 0)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = DS.Tables[0];
                    DataGridViewColumn dataGrid = new DataGridViewColumn();
                    dataGrid.HeaderText = "#";
                    dataGrid.CellTemplate = new DataGridViewTextBoxCell();
                    dataGridView1.Columns.Insert(0, dataGrid);
                    int counter = 1;
                    foreach(DataGridViewRow rows in dataGridView1.Rows) {
                        rows.Cells[0].Value = counter++;
                    }
                }
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
            }
        }

        private void ExecuteSQLLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var tx in textBoxesSql) {
                try
                {
                    DataTable dataTable = getDataSet(tx.Text).Tables[0];
                    tx.Text = dataTable.Rows[0].Field<object>(dataTable.Columns[0].ColumnName).ToString();
                    tx.BackColor = Color.Green;
                }catch(Exception ex)
                {
                    MessageBox.Show("Error!\n" + tx.Text);
                }
            }
        }

        private DataSet getDataSet(string sql) {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            return DS;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            labelSize = 12;
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            labelSize = 16;
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            labelSize = 24;
        }

        private void MakePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Bitmap bmp = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                bmp.Save(@"C:\\reports\\sample.png", ImageFormat.Png); // make sure path exists!
            }
            MessageBox.Show("OK!");
        }

        private void ImportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("DataGrid is empty!");
                return;
            }

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Report";

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            worksheet.Range["A1", "S1"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    var value = dataGridView1.Rows[i].Cells[j].Value;

                    if (value == null)
                    {
                        value = "null";
                    }

                    worksheet.Cells[i + 2, j + 1] = value.ToString();
                }
            }

            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = "Report " + DateTime.UtcNow.Date.ToString("dd.MM.yyyy");
            saveDialog.DefaultExt = ".xlsx";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        
        }

        private void ImportSQLQueryFromTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] fileines = File.ReadAllLines(theDialog.FileName);
                    string sqlQ = "";
                    foreach (var s in fileines) {
                        sqlQ += s + " ";
                    }

                    DataSet ds = getDataSet(sqlQ);

                    if(ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                    MessageBox.Show("Ok!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
