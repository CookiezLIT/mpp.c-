namespace MPP_Problema1
{
    partial class Cautare
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flightDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departureTextBox = new System.Windows.Forms.TextBox();
            this.buttonCauta = new System.Windows.Forms.Button();
            this.FlightDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.departure,
            this.arrival,
            this.flightDate,
            this.flightTime,
            this.capacity});
            this.dataGridView1.Location = new System.Drawing.Point(0, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(788, 332);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // departure
            // 
            this.departure.HeaderText = "departure";
            this.departure.MinimumWidth = 6;
            this.departure.Name = "departure";
            this.departure.Width = 125;
            // 
            // arrival
            // 
            this.arrival.HeaderText = "arrival";
            this.arrival.MinimumWidth = 6;
            this.arrival.Name = "arrival";
            this.arrival.Width = 125;
            // 
            // flightDate
            // 
            this.flightDate.HeaderText = "flightDate";
            this.flightDate.MinimumWidth = 6;
            this.flightDate.Name = "flightDate";
            this.flightDate.Width = 125;
            // 
            // flightTime
            // 
            this.flightTime.HeaderText = "flightTime";
            this.flightTime.MinimumWidth = 6;
            this.flightTime.Name = "flightTime";
            this.flightTime.Width = 125;
            // 
            // capacity
            // 
            this.capacity.HeaderText = "capacity";
            this.capacity.MinimumWidth = 6;
            this.capacity.Name = "capacity";
            this.capacity.Width = 125;
            // 
            // departureTextBox
            // 
            this.departureTextBox.Location = new System.Drawing.Point(13, 13);
            this.departureTextBox.Name = "departureTextBox";
            this.departureTextBox.Size = new System.Drawing.Size(217, 22);
            this.departureTextBox.TabIndex = 1;
            // 
            // buttonCauta
            // 
            this.buttonCauta.Location = new System.Drawing.Point(608, 13);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(75, 23);
            this.buttonCauta.TabIndex = 2;
            this.buttonCauta.Text = "cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            this.buttonCauta.Click += new System.EventHandler(this.buttonCauta_Click);
            // 
            // FlightDateTimePicker
            // 
            this.FlightDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FlightDateTimePicker.Location = new System.Drawing.Point(254, 13);
            this.FlightDateTimePicker.Name = "FlightDateTimePicker";
            this.FlightDateTimePicker.Size = new System.Drawing.Size(316, 22);
            this.FlightDateTimePicker.TabIndex = 3;
            // 
            // Cautare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FlightDateTimePicker);
            this.Controls.Add(this.buttonCauta);
            this.Controls.Add(this.departureTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Cautare";
            this.Text = "Cautare";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn departure;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn flightDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn flightTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacity;
        private System.Windows.Forms.TextBox departureTextBox;
        private System.Windows.Forms.Button buttonCauta;
        private System.Windows.Forms.DateTimePicker FlightDateTimePicker;
    }
}