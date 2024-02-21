namespace LastChanceClient_backup
{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            SendQueryButton_Click = new Button();
            ConnectButton_Click = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 92;
            dataGridView1.Size = new Size(703, 587);
            dataGridView1.TabIndex = 0;
            // 
            // SendQueryButton_Click
            // 
            SendQueryButton_Click.Location = new Point(758, 28);
            SendQueryButton_Click.Name = "SendQueryButton_Click";
            SendQueryButton_Click.Size = new Size(169, 52);
            SendQueryButton_Click.TabIndex = 1;
            SendQueryButton_Click.Text = "products";
            SendQueryButton_Click.UseVisualStyleBackColor = true;
            SendQueryButton_Click.Click += button1_Click;
            // 
            // ConnectButton_Click
            // 
            ConnectButton_Click.Location = new Point(743, 563);
            ConnectButton_Click.Name = "ConnectButton_Click";
            ConnectButton_Click.Size = new Size(169, 52);
            ConnectButton_Click.TabIndex = 2;
            ConnectButton_Click.Text = "connect";
            ConnectButton_Click.UseVisualStyleBackColor = true;
            ConnectButton_Click.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(963, 28);
            button3.Name = "button3";
            button3.Size = new Size(169, 52);
            button3.TabIndex = 3;
            button3.Text = "categories";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(758, 193);
            button4.Name = "button4";
            button4.Size = new Size(228, 52);
            button4.TabIndex = 4;
            button4.Text = "manufacturers";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(758, 108);
            button5.Name = "button5";
            button5.Size = new Size(169, 52);
            button5.TabIndex = 5;
            button5.Text = "stores";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(954, 108);
            button6.Name = "button6";
            button6.Size = new Size(169, 52);
            button6.TabIndex = 6;
            button6.Text = "overall";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 627);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(ConnectButton_Click);
            Controls.Add(SendQueryButton_Click);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button SendQueryButton_Click;
        private Button ConnectButton_Click;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}