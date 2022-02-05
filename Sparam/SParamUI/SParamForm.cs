using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SParameters;


namespace SParamUI
{
    public partial class SParamForm : Form
    {
        /// <summary>
        /// Значения по умолчанию.
        /// </summary>
        private SParams _sParameters;
        
        public SParamForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку и расчёт S-параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                var mode = 0;

                var c = new double[4, 4];
                var k = 0;
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        c[i, j] = Convert.ToDouble(dataGridView1.Rows[k].Cells[0].Value);
                        k++;
                    }
                }

                k = 0;
                var l = new double[4, 4];
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        l[i, j] = Convert.ToDouble(dataGridView1.Rows[k].Cells[1].Value);
                        k++;
                    }
                }
                
                var z = new double[4];
                z[0] = Convert.ToDouble(z1TextBox.Text);
                z[1] = Convert.ToDouble(z2TextBox.Text);
                z[2] = Convert.ToDouble(z3TextBox.Text);
                z[3] = Convert.ToDouble(z4TextBox.Text);
                _sParameters = new SParams(
                    Convert.ToInt32(NfTextBox.Text),
                    Convert.ToInt32(FminTextBox.Text),
                    Convert.ToInt32(FmaxTextBox.Text),
                    Convert.ToDouble(LenTextBox.Text),
                    l,
                    c,
                    z
                );
                _sParameters.CalculateSParameters(mode);
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                S1Label.Enabled = true;
                S2Label.Enabled = true;
                S3Label.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                DrawGraphics(_sParameters);
            //}
            //catch
            //{
            //    MessageBox.Show(@"Проверьте данные.", @"Ошибка",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        
        /// <summary>
        /// Рисование графиков.
        /// </summary>
        /// <param name="sParameters"></param>
        private void DrawGraphics(SParams sParameters)
        {
            for (var i = 0; i < 6; i++)
            {
                chart1.Series[i].Points.Clear();
            }
            var interval = Convert.ToDouble(
                (Convert.ToDouble(sParameters.Fmax) - 
                 Convert.ToDouble(sParameters.Fmin)) /
                 Convert.ToDouble(sParameters.Nf));
            var points = Convert.ToDouble(sParameters.Fmin);
            for (var i = 2; i < sParameters.Nf; i++)
            {
                chart1.Series[0].Points.AddXY(points, sParameters.S[0][i]);
                chart1.Series[1].Points.AddXY(points, sParameters.S[1][i]);
                chart1.Series[2].Points.AddXY(points, sParameters.S[2][i]);
                chart1.Series[3].Points.AddXY(points, sParameters.Fi[0][i]);
                chart1.Series[4].Points.AddXY(points, sParameters.Fi[1][i]);
                chart1.Series[5].Points.AddXY(points, sParameters.Fi[2][i]);
                points += interval;
            }
            chart1.ChartAreas[0].AxisX.Minimum = sParameters.Fmin;
            chart1.ChartAreas[0].AxisX.Maximum = sParameters.Fmax;
        }

        /// <summary>
        /// Построение ФЧХ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ResetAutoValues();
            if (!radioButton2.Checked) return;
            chart1.Series[0].Enabled = false;
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
            if(checkBox1.Checked)
            {
                chart1.Series[3].Enabled = true;
            }
            if (checkBox2.Checked)
            {
                chart1.Series[4].Enabled = true;
            }
            if (checkBox3.Checked)
            {
                chart1.Series[5].Enabled = true;
            }
            S1Label.Text = @"φ11";
            S2Label.Text = @"φ12";
            S3Label.Text = @"φ22";
        }

        /// <summary>
        /// Построение АЧХ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ResetAutoValues();
            if (!radioButton1.Checked) return;
            if (checkBox1.Checked)
            {
                chart1.Series[0].Enabled = true;
            }
            if (checkBox2.Checked)
            {
                chart1.Series[1].Enabled = true;
            }
            if (checkBox3.Checked)
            {
                chart1.Series[2].Enabled = true;
            }
            chart1.Series[3].Enabled = false;
            chart1.Series[4].Enabled = false;
            chart1.Series[5].Enabled = false;
            S1Label.Text = @"S11";
            S2Label.Text = @"S12";
            S3Label.Text = @"S22";
        }

        /// <summary>
        /// Событие ввода с клавиатуры в текстбокс.
        /// </summary>
        private void ValidateDoubleTextBoxes_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(),
                @"[\d\b,]");
        }

        /// <summary>
        /// Показ графиков при изменении чекбоксов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(checkBox1) && radioButton1.Checked && checkBox1.Checked)
            {
                chart1.Series[0].Enabled = true;
            }
            if (sender.Equals(checkBox2) && radioButton1.Checked && checkBox2.Checked)
            {
                chart1.Series[1].Enabled = true;
            }
            if (sender.Equals(checkBox3) && radioButton1.Checked && checkBox3.Checked)
            {
                chart1.Series[2].Enabled = true;
            }
            if (sender.Equals(checkBox1) && radioButton2.Checked && checkBox1.Checked)
            {
                chart1.Series[3].Enabled = true;
            }
            if (sender.Equals(checkBox2) && radioButton2.Checked && checkBox2.Checked)
            {
                chart1.Series[4].Enabled = true;
            }
            if (sender.Equals(checkBox3) && radioButton2.Checked && checkBox3.Checked)
            {
                chart1.Series[5].Enabled = true;
            }
            if (sender.Equals(checkBox1) && radioButton1.Checked && !checkBox1.Checked)
            {
                chart1.Series[0].Enabled = false;
            }
            if (sender.Equals(checkBox2) && radioButton1.Checked && !checkBox2.Checked)
            {
                chart1.Series[1].Enabled = false;
            }
            if (sender.Equals(checkBox3) && radioButton1.Checked && !checkBox3.Checked)
            {
                chart1.Series[2].Enabled = false;
            }
            if (sender.Equals(checkBox1) && radioButton2.Checked && !checkBox1.Checked)
            {
                chart1.Series[3].Enabled = false;
            }
            if (sender.Equals(checkBox2) && radioButton2.Checked && !checkBox2.Checked)
            {
                chart1.Series[4].Enabled = false;
            }
            if (sender.Equals(checkBox3) && radioButton2.Checked && !checkBox3.Checked)
            {
                chart1.Series[5].Enabled = false;
            }
        }

        /// <summary>
        /// Изменение чекбоксов при нажатии на текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SLabel_Click(object sender, EventArgs e)
        {
            if (sender.Equals(S1Label))
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
            if (sender.Equals(S2Label))
            {
                checkBox2.Checked = !checkBox2.Checked;
            }
            if (sender.Equals(S3Label))
            {
                checkBox3.Checked = !checkBox3.Checked;
            }
        }

        private void Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == mode0)
            {
                z3TextBox.Enabled = false;
                z4TextBox.Enabled = false;
                CL1Label.Enabled = false;
                CL2Label.Enabled = false;
                CL1Label.Text = @"C1";
                CL2Label.Text = @"C2";
                z3TextBox.Text = "";
                z4TextBox.Text = "";
            }
            if (sender == mode1)
            {
                z3TextBox.Enabled = true;
                z4TextBox.Enabled = true;
                CL1Label.Enabled = true;
                CL2Label.Enabled = true;
            }
            if (sender == mode2)
            {
                z3TextBox.Enabled = true;
                z4TextBox.Enabled = true;
                CL1Label.Enabled = true;
                CL2Label.Enabled = true;
            }
        }

        private void SParamForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("111", "0,766");
            dataGridView1.Rows.Add("-41", "0,363");
            dataGridView1.Rows.Add("-6,6", "0,238");
            dataGridView1.Rows.Add("-2,4", "0,172");
            dataGridView1.Rows.Add("-41", "0,363");
            dataGridView1.Rows.Add("127", "0,757");
            dataGridView1.Rows.Add("-39", "0,360");
            dataGridView1.Rows.Add("-6,6", "0,238");
            dataGridView1.Rows.Add("-6,6", "0,238");
            dataGridView1.Rows.Add("-39", "0,360");
            dataGridView1.Rows.Add("127", "0,757");
            dataGridView1.Rows.Add("-41", "0,363");
            dataGridView1.Rows.Add("-2,4", "0,172");
            dataGridView1.Rows.Add("-6,6", "0,238");
            dataGridView1.Rows.Add("-41", "0,363");
            dataGridView1.Rows.Add("111", "0,766");
            dataGridView1.Rows[0].HeaderCell.Value = "1 1";
            dataGridView1.Rows[1].HeaderCell.Value = "1 2";
            dataGridView1.Rows[2].HeaderCell.Value = "1 3";
            dataGridView1.Rows[3].HeaderCell.Value = "1 4";

            dataGridView1.Rows[4].HeaderCell.Value = "2 1";
            dataGridView1.Rows[5].HeaderCell.Value = "2 2";
            dataGridView1.Rows[6].HeaderCell.Value = "2 3";
            dataGridView1.Rows[7].HeaderCell.Value = "2 4";

            dataGridView1.Rows[8].HeaderCell.Value = "3 1";
            dataGridView1.Rows[9].HeaderCell.Value = "3 2";
            dataGridView1.Rows[10].HeaderCell.Value = "3 3";
            dataGridView1.Rows[11].HeaderCell.Value = "3 4";

            dataGridView1.Rows[12].HeaderCell.Value = "4 1";
            dataGridView1.Rows[13].HeaderCell.Value = "4 2";
            dataGridView1.Rows[14].HeaderCell.Value = "4 3";
            dataGridView1.Rows[15].HeaderCell.Value = "4 4";
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
