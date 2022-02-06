using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SParameters;


namespace SParamUI
{
    public partial class SParamForm : Form
    {
        /// <summary>
        /// Параметры.
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
            if (mode0.Checked)
            {
                mode = 0;
            }
            if (mode1.Checked)
            {
                mode = 1;
            }
            if (mode2.Checked)
            {
                mode = 2;
            }
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
                l, c, z
            );
            _sParameters.CalculateSParameters(mode);
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            DrawGraphics(_sParameters);
            //}
            //    catch
            //    {
            //        MessageBox.Show(@"Проверьте данные.", @"Ошибка",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        /// <summary>
        /// Рисование графиков.
        /// </summary>
        /// <param name="sParameters"></param>
        private void DrawGraphics(SParams sParameters)
        {
            for (var i = 0; i < 20; i++)
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
                chart1.Series[10].Points.AddXY(points, sParameters.Fi[0][i]);
                chart1.Series[11].Points.AddXY(points, sParameters.Fi[1][i]);
                chart1.Series[12].Points.AddXY(points, sParameters.Fi[2][i]);
                if (mode0.Checked)
                {
                    chart1.Series[3].Points.AddXY(points, sParameters.S[3][i]);
                    chart1.Series[4].Points.AddXY(points, sParameters.S[4][i]);
                    chart1.Series[5].Points.AddXY(points, sParameters.S[5][i]);
                    chart1.Series[6].Points.AddXY(points, sParameters.S[6][i]);
                    chart1.Series[7].Points.AddXY(points, sParameters.S[7][i]);
                    chart1.Series[8].Points.AddXY(points, sParameters.S[8][i]);
                    chart1.Series[9].Points.AddXY(points, sParameters.S[9][i]);
                    chart1.Series[13].Points.AddXY(points, sParameters.Fi[3][i]);
                    chart1.Series[14].Points.AddXY(points, sParameters.Fi[4][i]);
                    chart1.Series[15].Points.AddXY(points, sParameters.Fi[5][i]);
                    chart1.Series[16].Points.AddXY(points, sParameters.Fi[6][i]);
                    chart1.Series[17].Points.AddXY(points, sParameters.Fi[7][i]);
                    chart1.Series[18].Points.AddXY(points, sParameters.Fi[8][i]);
                    chart1.Series[19].Points.AddXY(points, sParameters.Fi[9][i]);
                }
                points += interval;
            }
            chart1.ChartAreas[0].AxisX.Minimum = sParameters.Fmin;
            chart1.ChartAreas[0].AxisX.Maximum = sParameters.Fmax;
            if (radioButton1.Checked)
            {
                ChangeGraphics(true, false);
            }
            if (radioButton2.Checked)
            {
                ChangeGraphics(false, true);
            }
        }

        /// <summary>
        /// Построение ФЧХ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked) return;
            chart1.ResetAutoValues();
            ChangeGraphics(false, true);
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
            ChangeGraphics(true, false);
        }

        /// <summary>
        /// Переключение между графиками.
        /// </summary>
        /// <param name="a">Включение АЧХ.</param>
        /// <param name="b">Включение ФЧХ.</param>
        private void ChangeGraphics(bool a, bool b)
        {
            chart1.Series[0].Enabled = a;
            chart1.Series[1].Enabled = a;
            chart1.Series[2].Enabled = a;
            chart1.Series[10].Enabled = b;
            chart1.Series[11].Enabled = b;
            chart1.Series[12].Enabled = b;
            if (!mode0.Checked) return;
            chart1.Series[3].Enabled = a;
            chart1.Series[4].Enabled = a;
            chart1.Series[5].Enabled = a;
            chart1.Series[6].Enabled = a;
            chart1.Series[7].Enabled = a;
            chart1.Series[8].Enabled = a;
            chart1.Series[9].Enabled = a;
            chart1.Series[13].Enabled = b;
            chart1.Series[14].Enabled = b;
            chart1.Series[15].Enabled = b;
            chart1.Series[16].Enabled = b;
            chart1.Series[17].Enabled = b;
            chart1.Series[18].Enabled = b;
            chart1.Series[19].Enabled = b;
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

        private void Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == mode0)
            {
                z3TextBox.Enabled = true;
                z4TextBox.Enabled = true;
                Z3Label.Enabled = true;
                Z4Label.Enabled = true;
                Z3Label.Text = @"Z3, Ω";
                Z4Label.Text = @"Z4, Ω";
                z3TextBox.Text = @"50";
                z4TextBox.Text = @"50";
            }
            if (sender == mode1)
            {
                z3TextBox.Enabled = false;
                z4TextBox.Enabled = false;
                Z3Label.Enabled = false;
                Z4Label.Enabled = false;
            }
            if (sender == mode2)
            {
                z3TextBox.Enabled = false;
                z4TextBox.Enabled = false;
                Z3Label.Enabled = false;
                Z4Label.Enabled = false;
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
