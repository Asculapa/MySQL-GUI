namespace DataBase
{
    partial class Search
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.delLine = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.ComboBox();
            this.newLine = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.columns = new System.Windows.Forms.ComboBox();
            this.mySqlOperator = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.delLine);
            this.panel1.Controls.Add(this.equal);
            this.panel1.Controls.Add(this.newLine);
            this.panel1.Controls.Add(this.result);
            this.panel1.Controls.Add(this.columns);
            this.panel1.Controls.Add(this.mySqlOperator);
            this.panel1.Location = new System.Drawing.Point(12, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 284);
            this.panel1.TabIndex = 2;
            // 
            // delLine
            // 
            this.delLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delLine.Location = new System.Drawing.Point(395, 16);
            this.delLine.Name = "delLine";
            this.delLine.Size = new System.Drawing.Size(27, 21);
            this.delLine.TabIndex = 5;
            this.delLine.Text = "-";
            this.delLine.UseVisualStyleBackColor = true;
            this.delLine.Click += new System.EventHandler(this.delLine_Click);
            // 
            // equal
            // 
            this.equal.FormattingEnabled = true;
            this.equal.Location = new System.Drawing.Point(211, 15);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(39, 21);
            this.equal.TabIndex = 4;
            this.equal.SelectedIndexChanged += new System.EventHandler(this.Equal_SelectedIndexChanged);
            // 
            // newLine
            // 
            this.newLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLine.Location = new System.Drawing.Point(363, 15);
            this.newLine.Name = "newLine";
            this.newLine.Size = new System.Drawing.Size(27, 21);
            this.newLine.TabIndex = 3;
            this.newLine.Text = "+";
            this.newLine.UseVisualStyleBackColor = true;
            this.newLine.Click += new System.EventHandler(this.button3_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(256, 15);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(101, 20);
            this.result.TabIndex = 3;
            // 
            // columns
            // 
            this.columns.FormattingEnabled = true;
            this.columns.Location = new System.Drawing.Point(84, 15);
            this.columns.Name = "columns";
            this.columns.Size = new System.Drawing.Size(121, 21);
            this.columns.TabIndex = 1;
            // 
            // mySqlOperator
            // 
            this.mySqlOperator.AutoSize = true;
            this.mySqlOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mySqlOperator.Location = new System.Drawing.Point(3, 15);
            this.mySqlOperator.Name = "mySqlOperator";
            this.mySqlOperator.Size = new System.Drawing.Size(75, 20);
            this.mySqlOperator.TabIndex = 0;
            this.mySqlOperator.Text = "WHERE";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 345);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Search";
            this.Text = "Search";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newLine;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.ComboBox columns;
        private System.Windows.Forms.Label mySqlOperator;
        private System.Windows.Forms.ComboBox equal;
        private System.Windows.Forms.Button delLine;
    }
}