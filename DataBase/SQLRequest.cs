using Microsoft.Office.Interop.Excel;
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

namespace DataBase
{
    public partial class SQLRequest : Form
    {

        MySqlConnection conn;
        public SQLRequest(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0) {
                return;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(richTextBox1.Text, conn);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                if (DS.Tables.Count != 0)
                {
                    dataGridView1.DataSource = DS.Tables[0];
                }
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
            }
        }

        private void ReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(dataGridView1.Rows.Count == 0)
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

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++) {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            worksheet.Range["A1", "S1"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) {
                for (int j = 0; j < dataGridView1.Columns.Count; j++) {

                    var value = dataGridView1.Rows[i].Cells[j].Value;

                    if (value == null){
                        value = "null";
                    }

                    worksheet.Cells[i + 2, j + 1] = value.ToString();
                }
            }

            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = "Report " + DateTime.UtcNow.Date.ToString("dd.MM.yyyy");
            saveDialog.DefaultExt = ".xlsx";

            if (saveDialog.ShowDialog() == DialogResult.OK) {
                workbook.SaveAs(saveDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }
}
