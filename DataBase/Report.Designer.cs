namespace DataBase
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeSQLQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeSQLLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.makePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.importSQLQueryFromTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.makeSQLQueryToolStripMenuItem,
            this.executeSQLLabelsToolStripMenuItem,
            this.labelSizeToolStripMenuItem,
            this.makePictureToolStripMenuItem,
            this.importToExcelToolStripMenuItem,
            this.importSQLQueryFromTxtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelToolStripMenuItem,
            this.sqlLabelToolStripMenuItem});
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.newItemToolStripMenuItem.Text = "New item";
            // 
            // labelToolStripMenuItem
            // 
            this.labelToolStripMenuItem.Name = "labelToolStripMenuItem";
            this.labelToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.labelToolStripMenuItem.Text = "Label";
            this.labelToolStripMenuItem.Click += new System.EventHandler(this.LabelToolStripMenuItem_Click);
            // 
            // sqlLabelToolStripMenuItem
            // 
            this.sqlLabelToolStripMenuItem.Name = "sqlLabelToolStripMenuItem";
            this.sqlLabelToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.sqlLabelToolStripMenuItem.Text = "SQLLabel";
            this.sqlLabelToolStripMenuItem.Click += new System.EventHandler(this.SqlLabelToolStripMenuItem_Click);
            // 
            // makeSQLQueryToolStripMenuItem
            // 
            this.makeSQLQueryToolStripMenuItem.Name = "makeSQLQueryToolStripMenuItem";
            this.makeSQLQueryToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.makeSQLQueryToolStripMenuItem.Text = "Make SQL query";
            this.makeSQLQueryToolStripMenuItem.Click += new System.EventHandler(this.MakeSQLQueryToolStripMenuItem_Click);
            // 
            // executeSQLLabelsToolStripMenuItem
            // 
            this.executeSQLLabelsToolStripMenuItem.Name = "executeSQLLabelsToolStripMenuItem";
            this.executeSQLLabelsToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.executeSQLLabelsToolStripMenuItem.Text = "Execute SQL labels";
            this.executeSQLLabelsToolStripMenuItem.Click += new System.EventHandler(this.ExecuteSQLLabelsToolStripMenuItem_Click);
            // 
            // labelSizeToolStripMenuItem
            // 
            this.labelSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.labelSizeToolStripMenuItem.Name = "labelSizeToolStripMenuItem";
            this.labelSizeToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.labelSizeToolStripMenuItem.Text = "Label Size";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem2.Text = "12";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem3.Text = "16";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "24";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // makePictureToolStripMenuItem
            // 
            this.makePictureToolStripMenuItem.Name = "makePictureToolStripMenuItem";
            this.makePictureToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.makePictureToolStripMenuItem.Text = "Make picture";
            this.makePictureToolStripMenuItem.Click += new System.EventHandler(this.MakePictureToolStripMenuItem_Click);
            // 
            // importToExcelToolStripMenuItem
            // 
            this.importToExcelToolStripMenuItem.Name = "importToExcelToolStripMenuItem";
            this.importToExcelToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.importToExcelToolStripMenuItem.Text = "Import to Excel";
            this.importToExcelToolStripMenuItem.Click += new System.EventHandler(this.ImportToExcelToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 271);
            this.dataGridView1.TabIndex = 1;
            // 
            // importSQLQueryFromTxtToolStripMenuItem
            // 
            this.importSQLQueryFromTxtToolStripMenuItem.Name = "importSQLQueryFromTxtToolStripMenuItem";
            this.importSQLQueryFromTxtToolStripMenuItem.Size = new System.Drawing.Size(157, 20);
            this.importSQLQueryFromTxtToolStripMenuItem.Text = "Import SQLQuery from txt";
            this.importSQLQueryFromTxtToolStripMenuItem.Click += new System.EventHandler(this.ImportSQLQueryFromTxtToolStripMenuItem_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Report";
            this.Text = "Report";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Report_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeSQLQueryToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem executeSQLLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem makePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSQLQueryFromTxtToolStripMenuItem;
    }
}