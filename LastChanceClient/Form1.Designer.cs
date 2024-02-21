namespace LastChanceClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            QueryTextBox = new TextBox();
            dataGridView1 = new DataGridView();
            ConnectButton_Click = new Button();
            SendQueryButton_Click = new Button();
            DisconnectButton_Click = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // QueryTextBox
            // 
            QueryTextBox.Location = new Point(19, 23);
            QueryTextBox.Name = "QueryTextBox";
            QueryTextBox.Size = new Size(395, 43);
            QueryTextBox.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 92;
            dataGridView1.Size = new Size(1139, 514);
            dataGridView1.TabIndex = 1;
            // 
            // ConnectButton_Click
            // 
            ConnectButton_Click.Location = new Point(817, 18);
            ConnectButton_Click.Name = "ConnectButton_Click";
            ConnectButton_Click.Size = new Size(169, 52);
            ConnectButton_Click.TabIndex = 2;
            ConnectButton_Click.Text = "connect";
            ConnectButton_Click.UseVisualStyleBackColor = true;
            ConnectButton_Click.Click += ConnectButton_Click_Click;
            // 
            // SendQueryButton_Click
            // 
            SendQueryButton_Click.Location = new Point(437, 18);
            SendQueryButton_Click.Name = "SendQueryButton_Click";
            SendQueryButton_Click.Size = new Size(169, 52);
            SendQueryButton_Click.TabIndex = 3;
            SendQueryButton_Click.Text = "Send query";
            SendQueryButton_Click.UseVisualStyleBackColor = true;
            SendQueryButton_Click.Click += SendQueryButton_Click_Click;
            // 
            // DisconnectButton_Click
            // 
            DisconnectButton_Click.Location = new Point(992, 18);
            DisconnectButton_Click.Name = "DisconnectButton_Click";
            DisconnectButton_Click.Size = new Size(169, 52);
            DisconnectButton_Click.TabIndex = 4;
            DisconnectButton_Click.Text = "button1";
            DisconnectButton_Click.UseVisualStyleBackColor = true;
            DisconnectButton_Click.Click += DisconnectButton_Click_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 681);
            Controls.Add(DisconnectButton_Click);
            Controls.Add(SendQueryButton_Click);
            Controls.Add(ConnectButton_Click);
            Controls.Add(dataGridView1);
            Controls.Add(QueryTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox QueryTextBox;
        private DataGridView dataGridView1;
        private Button ConnectButton_Click;
        private Button SendQueryButton_Click;
        private Button DisconnectButton_Click;
    }
}
