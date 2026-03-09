namespace BMS_Data_Decoder
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
            btnLoad = new Button();
            btnDecode = new Button();
            dataGridView1 = new DataGridView();
            StackVoltage = new DataGridViewTextBoxColumn();
            BatteryCapacity = new DataGridViewTextBoxColumn();
            CycleCount = new DataGridViewTextBoxColumn();
            SOC = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(347, 165);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load CSV";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDecode
            // 
            btnDecode.Location = new Point(250, 165);
            btnDecode.Name = "btnDecode";
            btnDecode.Size = new Size(75, 23);
            btnDecode.TabIndex = 2;
            btnDecode.Text = "Decode Data";
            btnDecode.UseVisualStyleBackColor = true;
            btnDecode.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { StackVoltage, BatteryCapacity, CycleCount, SOC });
            dataGridView1.Location = new Point(33, 208);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(670, 220);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // StackVoltage
            // 
            StackVoltage.HeaderText = "StackVoltage";
            StackVoltage.Name = "StackVoltage";
            // 
            // BatteryCapacity
            // 
            BatteryCapacity.HeaderText = "BatteryCapacity";
            BatteryCapacity.Name = "BatteryCapacity";
            // 
            // CycleCount
            // 
            CycleCount.HeaderText = "CycleCount";
            CycleCount.Name = "CycleCount";
            // 
            // SOC
            // 
            SOC.HeaderText = "SOC";
            SOC.Name = "SOC";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnDecode);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnLoad;
        private Button btnDecode;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn StackVoltage;
        private DataGridViewTextBoxColumn BatteryCapacity;
        private DataGridViewTextBoxColumn CycleCount;
        private DataGridViewTextBoxColumn SOC;
    }
}
