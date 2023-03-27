namespace MPP_Problema1
{
    partial class MainForm
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
            this.buttonStartCautare = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.addressInput = new System.Windows.Forms.TextBox();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(788, 332);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // buttonStartCautare
            // 
            this.buttonStartCautare.Location = new System.Drawing.Point(12, 12);
            this.buttonStartCautare.Name = "buttonStartCautare";
            this.buttonStartCautare.Size = new System.Drawing.Size(75, 23);
            this.buttonStartCautare.TabIndex = 1;
            this.buttonStartCautare.Text = "cautare";
            this.buttonStartCautare.UseVisualStyleBackColor = true;
            this.buttonStartCautare.Click += new System.EventHandler(this.buttonStartCautare_Click);
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(638, 519);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(105, 23);
            this.buyButton.TabIndex = 2;
            this.buyButton.Text = "cumparare";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(89, 453);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 22);
            this.nameInput.TabIndex = 3;
            // 
            // addressInput
            // 
            this.addressInput.Location = new System.Drawing.Point(89, 541);
            this.addressInput.Name = "addressInput";
            this.addressInput.Size = new System.Drawing.Size(100, 22);
            this.addressInput.TabIndex = 4;
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(89, 493);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(100, 22);
            this.emailInput.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 541);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 575);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.addressInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.buttonStartCautare);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
        private System.Windows.Forms.Button buttonStartCautare;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox addressInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}