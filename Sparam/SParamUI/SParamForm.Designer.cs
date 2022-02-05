
namespace SParamUI
{
    partial class SParamForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LenTextBox = new System.Windows.Forms.TextBox();
            this.FmaxTextBox = new System.Windows.Forms.TextBox();
            this.FminTextBox = new System.Windows.Forms.TextBox();
            this.NfTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.S3Label = new System.Windows.Forms.Label();
            this.S2Label = new System.Windows.Forms.Label();
            this.S1Label = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mode2 = new System.Windows.Forms.RadioButton();
            this.mode1 = new System.Windows.Forms.RadioButton();
            this.mode0 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CL2Label = new System.Windows.Forms.Label();
            this.CL1Label = new System.Windows.Forms.Label();
            this.z4TextBox = new System.Windows.Forms.TextBox();
            this.z3TextBox = new System.Windows.Forms.TextBox();
            this.z2TextBox = new System.Windows.Forms.TextBox();
            this.z1TextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DrawButton);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LenTextBox);
            this.groupBox1.Controls.Add(this.FmaxTextBox);
            this.groupBox1.Controls.Add(this.FminTextBox);
            this.groupBox1.Controls.Add(this.NfTextBox);
            this.groupBox1.Location = new System.Drawing.Point(416, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(267, 43);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(65, 23);
            this.DrawButton.TabIndex = 6;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Length, mm =";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Amount of points";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "..";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Frequency, GHz";
            // 
            // LenTextBox
            // 
            this.LenTextBox.Location = new System.Drawing.Point(267, 19);
            this.LenTextBox.Name = "LenTextBox";
            this.LenTextBox.Size = new System.Drawing.Size(65, 20);
            this.LenTextBox.TabIndex = 5;
            this.LenTextBox.Text = "1";
            this.LenTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxes_KeyPress);
            // 
            // FmaxTextBox
            // 
            this.FmaxTextBox.Location = new System.Drawing.Point(193, 45);
            this.FmaxTextBox.Name = "FmaxTextBox";
            this.FmaxTextBox.Size = new System.Drawing.Size(68, 20);
            this.FmaxTextBox.TabIndex = 4;
            this.FmaxTextBox.Text = "15";
            this.FmaxTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxes_KeyPress);
            // 
            // FminTextBox
            // 
            this.FminTextBox.Location = new System.Drawing.Point(96, 45);
            this.FminTextBox.Name = "FminTextBox";
            this.FminTextBox.Size = new System.Drawing.Size(72, 20);
            this.FminTextBox.TabIndex = 3;
            this.FminTextBox.Text = "0";
            this.FminTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxes_KeyPress);
            // 
            // NfTextBox
            // 
            this.NfTextBox.Location = new System.Drawing.Point(96, 19);
            this.NfTextBox.Name = "NfTextBox";
            this.NfTextBox.Size = new System.Drawing.Size(72, 20);
            this.NfTextBox.TabIndex = 3;
            this.NfTextBox.Text = "500";
            this.NfTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxes_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 403);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.Title = "Частота (ГГц)";
            chartArea3.AxisY.Title = "S-параметры (дБ) ";
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 42);
            this.chart1.Name = "chart1";
            series13.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Color = System.Drawing.Color.Red;
            series13.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series13.Legend = "Legend1";
            series13.MarkerBorderColor = System.Drawing.Color.Red;
            series13.MarkerColor = System.Drawing.Color.Red;
            series13.MarkerImageTransparentColor = System.Drawing.Color.Red;
            series13.Name = "S11";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Color = System.Drawing.Color.Red;
            series14.Legend = "Legend1";
            series14.Name = "S12";
            series15.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Color = System.Drawing.Color.Blue;
            series15.Legend = "Legend1";
            series15.Name = "S22";
            series16.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Color = System.Drawing.Color.Red;
            series16.Enabled = false;
            series16.Legend = "Legend1";
            series16.Name = "φ11";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Color = System.Drawing.Color.Red;
            series17.Enabled = false;
            series17.Legend = "Legend1";
            series17.Name = "φ12";
            series18.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Color = System.Drawing.Color.Blue;
            series18.Enabled = false;
            series18.Legend = "Legend1";
            series18.Name = "φ22";
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Series.Add(series17);
            this.chart1.Series.Add(series18);
            this.chart1.Size = new System.Drawing.Size(511, 370);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Magnitude (dB)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(109, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Phase (deg)";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(197, 21);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.S3Label);
            this.groupBox3.Controls.Add(this.S2Label);
            this.groupBox3.Controls.Add(this.S1Label);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Location = new System.Drawing.Point(232, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 418);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // S3Label
            // 
            this.S3Label.AutoSize = true;
            this.S3Label.Enabled = false;
            this.S3Label.Location = new System.Drawing.Point(312, 21);
            this.S3Label.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.S3Label.Name = "S3Label";
            this.S3Label.Size = new System.Drawing.Size(26, 13);
            this.S3Label.TabIndex = 10;
            this.S3Label.Text = "S22";
            this.S3Label.Click += new System.EventHandler(this.SLabel_Click);
            // 
            // S2Label
            // 
            this.S2Label.AutoSize = true;
            this.S2Label.Enabled = false;
            this.S2Label.Location = new System.Drawing.Point(263, 21);
            this.S2Label.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.S2Label.Name = "S2Label";
            this.S2Label.Size = new System.Drawing.Size(26, 13);
            this.S2Label.TabIndex = 9;
            this.S2Label.Text = "S12";
            this.S2Label.Click += new System.EventHandler(this.SLabel_Click);
            // 
            // S1Label
            // 
            this.S1Label.AutoSize = true;
            this.S1Label.Enabled = false;
            this.S1Label.Location = new System.Drawing.Point(214, 21);
            this.S1Label.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.S1Label.Name = "S1Label";
            this.S1Label.Size = new System.Drawing.Size(26, 13);
            this.S1Label.TabIndex = 8;
            this.S1Label.Text = "S11";
            this.S1Label.Click += new System.EventHandler(this.SLabel_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(295, 21);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(246, 21);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mode2);
            this.groupBox4.Controls.Add(this.mode1);
            this.groupBox4.Controls.Add(this.mode0);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(142, 92);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select schematic";
            // 
            // mode2
            // 
            this.mode2.AutoSize = true;
            this.mode2.Location = new System.Drawing.Point(6, 65);
            this.mode2.Name = "mode2";
            this.mode2.Size = new System.Drawing.Size(75, 17);
            this.mode2.TabIndex = 2;
            this.mode2.Text = "InterDigital";
            this.mode2.UseVisualStyleBackColor = true;
            this.mode2.CheckedChanged += new System.EventHandler(this.Mode_CheckedChanged);
            // 
            // mode1
            // 
            this.mode1.AutoSize = true;
            this.mode1.Location = new System.Drawing.Point(6, 42);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(67, 17);
            this.mode1.TabIndex = 1;
            this.mode1.Text = "Meander";
            this.mode1.UseVisualStyleBackColor = true;
            this.mode1.CheckedChanged += new System.EventHandler(this.Mode_CheckedChanged);
            // 
            // mode0
            // 
            this.mode0.AutoSize = true;
            this.mode0.Checked = true;
            this.mode0.Location = new System.Drawing.Point(6, 19);
            this.mode0.Name = "mode0";
            this.mode0.Size = new System.Drawing.Size(55, 17);
            this.mode0.TabIndex = 0;
            this.mode0.TabStop = true;
            this.mode0.Text = "Lange";
            this.mode0.UseVisualStyleBackColor = true;
            this.mode0.CheckedChanged += new System.EventHandler(this.Mode_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CL2Label);
            this.groupBox5.Controls.Add(this.CL1Label);
            this.groupBox5.Controls.Add(this.z4TextBox);
            this.groupBox5.Controls.Add(this.z3TextBox);
            this.groupBox5.Controls.Add(this.z2TextBox);
            this.groupBox5.Controls.Add(this.z1TextBox);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(160, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 77);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            // 
            // CL2Label
            // 
            this.CL2Label.AutoSize = true;
            this.CL2Label.Enabled = false;
            this.CL2Label.Location = new System.Drawing.Point(121, 46);
            this.CL2Label.Name = "CL2Label";
            this.CL2Label.Size = new System.Drawing.Size(35, 13);
            this.CL2Label.TabIndex = 16;
            this.CL2Label.Text = "Z4, Ω";
            // 
            // CL1Label
            // 
            this.CL1Label.AutoSize = true;
            this.CL1Label.Enabled = false;
            this.CL1Label.Location = new System.Drawing.Point(121, 22);
            this.CL1Label.Name = "CL1Label";
            this.CL1Label.Size = new System.Drawing.Size(35, 13);
            this.CL1Label.TabIndex = 15;
            this.CL1Label.Text = "Z3, Ω";
            // 
            // z4TextBox
            // 
            this.z4TextBox.Enabled = false;
            this.z4TextBox.Location = new System.Drawing.Point(171, 43);
            this.z4TextBox.Name = "z4TextBox";
            this.z4TextBox.Size = new System.Drawing.Size(52, 20);
            this.z4TextBox.TabIndex = 14;
            this.z4TextBox.Text = "50";
            // 
            // z3TextBox
            // 
            this.z3TextBox.Enabled = false;
            this.z3TextBox.Location = new System.Drawing.Point(171, 19);
            this.z3TextBox.Name = "z3TextBox";
            this.z3TextBox.Size = new System.Drawing.Size(52, 20);
            this.z3TextBox.TabIndex = 13;
            this.z3TextBox.Text = "50";
            // 
            // z2TextBox
            // 
            this.z2TextBox.Location = new System.Drawing.Point(59, 45);
            this.z2TextBox.Name = "z2TextBox";
            this.z2TextBox.Size = new System.Drawing.Size(52, 20);
            this.z2TextBox.TabIndex = 12;
            this.z2TextBox.Text = "50";
            // 
            // z1TextBox
            // 
            this.z1TextBox.Location = new System.Drawing.Point(59, 19);
            this.z1TextBox.Name = "z1TextBox";
            this.z1TextBox.Size = new System.Drawing.Size(52, 20);
            this.z1TextBox.TabIndex = 11;
            this.z1TextBox.Text = "50";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Z2, Ω";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Z1, Ω";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C,
            this.L});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 55;
            this.dataGridView1.Size = new System.Drawing.Size(208, 384);
            this.dataGridView1.TabIndex = 4;
            // 
            // C
            // 
            this.C.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C.HeaderText = "C, pF/m";
            this.C.Name = "C";
            // 
            // L
            // 
            this.L.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.L.HeaderText = "L, µH/m";
            this.L.Name = "L";
            // 
            // SParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 525);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(688, 504);
            this.Name = "SParamForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S-Parameters";
            this.Load += new System.EventHandler(this.SParamForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LenTextBox;
        private System.Windows.Forms.TextBox FmaxTextBox;
        private System.Windows.Forms.TextBox FminTextBox;
        private System.Windows.Forms.TextBox NfTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label S3Label;
        private System.Windows.Forms.Label S2Label;
        private System.Windows.Forms.Label S1Label;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton mode2;
        private System.Windows.Forms.RadioButton mode1;
        private System.Windows.Forms.RadioButton mode0;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox z2TextBox;
        private System.Windows.Forms.TextBox z1TextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox z4TextBox;
        private System.Windows.Forms.TextBox z3TextBox;
        private System.Windows.Forms.Label CL2Label;
        private System.Windows.Forms.Label CL1Label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
    }
}

