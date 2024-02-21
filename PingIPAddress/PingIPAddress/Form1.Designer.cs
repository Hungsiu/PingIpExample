namespace PingIPAddress
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
            textBoxBaseAddress = new TextBox();
            textBoxMinAddress = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxMaxAddress = new TextBox();
            buttonSearch = new Button();
            dataGridViewResult = new DataGridView();
            labelStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // textBoxBaseAddress
            // 
            textBoxBaseAddress.Location = new Point(12, 27);
            textBoxBaseAddress.Name = "textBoxBaseAddress";
            textBoxBaseAddress.Size = new Size(87, 23);
            textBoxBaseAddress.TabIndex = 0;
            textBoxBaseAddress.Text = "192.168.1";
            textBoxBaseAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxMinAddress
            // 
            textBoxMinAddress.Location = new Point(121, 27);
            textBoxMinAddress.Name = "textBoxMinAddress";
            textBoxMinAddress.Size = new Size(34, 23);
            textBoxMinAddress.TabIndex = 1;
            textBoxMinAddress.Text = "1";
            textBoxMinAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "IP區段";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 35);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 3;
            label2.Text = ".";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(161, 30);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 4;
            label3.Text = "~";
            // 
            // textBoxMaxAddress
            // 
            textBoxMaxAddress.Location = new Point(183, 27);
            textBoxMaxAddress.Name = "textBoxMaxAddress";
            textBoxMaxAddress.Size = new Size(34, 23);
            textBoxMaxAddress.TabIndex = 5;
            textBoxMaxAddress.Text = "255";
            textBoxMaxAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(223, 27);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "搜尋";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Location = new Point(12, 67);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.Size = new Size(286, 188);
            dataGridViewResult.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 267);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(43, 15);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "狀態列";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 291);
            Controls.Add(labelStatus);
            Controls.Add(dataGridViewResult);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxMaxAddress);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxMinAddress);
            Controls.Add(textBoxBaseAddress);
            Name = "Form1";
            Text = "IP蒐尋器";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxBaseAddress;
        private TextBox textBoxMinAddress;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxMaxAddress;
        private Button buttonSearch;
        private DataGridView dataGridViewResult;
        private Label labelStatus;
    }
}
