using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            var n = Convert.ToInt32(NTextBox.Text);
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
            if (mode3.Checked)
            {
                mode = 3;
            }
            var c = new double[n, n];
            var k = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    c[i, j] = Convert.ToDouble(dataGridView1.Rows[k].Cells[0].Value);
                    k++;
                }
            }

            k = 0;
            var l = new double[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    l[i, j] = Convert.ToDouble(dataGridView1.Rows[k].Cells[1].Value);
                    k++;
                }
            }

            var zTextBoxes = new List<TextBox>
            {
                z1TextBox,
                z2TextBox,
                z3TextBox,
                z4TextBox,
                z5TextBox,
                z6TextBox,
                z7TextBox,
                z8TextBox,
                z9TextBox,
                z10TextBox,
                z11TextBox,
                z12TextBox,
            };
            var z = new double[n + n];
            if (mode == 1)
            {
                z = new double[4];
            }
            else if (mode == 2 || mode == 3)
            {
                z = new double[2];
            }
            for (var i = 0; i < z.Length; i++)
            {
                z[i] = Convert.ToDouble(zTextBoxes[i].Text);
                if (n == 4 && i == 4 && mode == 1)
                {
                    break;
                }
                if (n == 4 && i == 2 && (mode == 2 || mode == 3))
                {
                    break;
                }
            }
            _sParameters = new SParams(
                n, Convert.ToInt32(NfTextBox.Text),
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
            foreach (var t in chart1.Series)
            {
                t.Points.Clear();
            }
            for (var i = 1; i < sParameters.Nf; i++)
            {
                chart1.Series[0].Points.AddXY(sParameters.F[i], sParameters.S[0][i]);
                chart1.Series[1].Points.AddXY(sParameters.F[i], sParameters.S[1][i]);
                chart1.Series[2].Points.AddXY(sParameters.F[i], sParameters.S[2][i]);
                chart1.Series[10].Points.AddXY(sParameters.F[i], sParameters.Fi[0][i]);
                chart1.Series[11].Points.AddXY(sParameters.F[i], sParameters.Fi[1][i]);
                chart1.Series[12].Points.AddXY(sParameters.F[i], sParameters.Fi[2][i]);
                if (mode1.Checked)
                {
                    chart1.Series[3].Points.AddXY(sParameters.F[i], sParameters.S[3][i]);
                    chart1.Series[4].Points.AddXY(sParameters.F[i], sParameters.S[4][i]);
                    chart1.Series[5].Points.AddXY(sParameters.F[i], sParameters.S[5][i]);
                    chart1.Series[6].Points.AddXY(sParameters.F[i], sParameters.S[6][i]);
                    chart1.Series[7].Points.AddXY(sParameters.F[i], sParameters.S[7][i]);
                    chart1.Series[8].Points.AddXY(sParameters.F[i], sParameters.S[8][i]);
                    chart1.Series[9].Points.AddXY(sParameters.F[i], sParameters.S[9][i]);
                    chart1.Series[13].Points.AddXY(sParameters.F[i], sParameters.Fi[3][i]);
                    chart1.Series[14].Points.AddXY(sParameters.F[i], sParameters.Fi[4][i]);
                    chart1.Series[15].Points.AddXY(sParameters.F[i], sParameters.Fi[5][i]);
                    chart1.Series[16].Points.AddXY(sParameters.F[i], sParameters.Fi[6][i]);
                    chart1.Series[17].Points.AddXY(sParameters.F[i], sParameters.Fi[7][i]);
                    chart1.Series[18].Points.AddXY(sParameters.F[i], sParameters.Fi[8][i]);
                    chart1.Series[19].Points.AddXY(sParameters.F[i], sParameters.Fi[9][i]);
                }
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
            if (!mode1.Checked) return;
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
            if (sender == mode1)
            {
                z3TextBox.Enabled = true;
                z4TextBox.Enabled = true;
                Z3Label.Enabled = true;
                Z4Label.Enabled = true;
                Z3Label.Text = @"Z3, Ω";
                Z4Label.Text = @"ZN, Ω";
                z3TextBox.Text = @"50";
                z4TextBox.Text = @"50";
            }
            if (sender == mode2)
            {
                z3TextBox.Enabled = false;
                z4TextBox.Enabled = false;
                Z3Label.Enabled = false;
                Z4Label.Enabled = false;
            }
            if (sender == mode3)
            {
                z3TextBox.Enabled = false;
                z4TextBox.Enabled = false;
                Z3Label.Enabled = false;
                Z4Label.Enabled = false;
            }
        }

        private void GridFill()
        {
            switch (NTextBox.Text)
            {
                case @"3":
                    dataGridView1.Rows.Add("105", "0,387");
                    dataGridView1.Rows.Add("-35", "0,163");
                    dataGridView1.Rows.Add("-1,5", "0,082");
                    dataGridView1.Rows.Add("-35", "0,163");
                    dataGridView1.Rows.Add("122", "0,371");
                    dataGridView1.Rows.Add("-35", "0,163");
                    dataGridView1.Rows.Add("-1,5", "0,082");
                    dataGridView1.Rows.Add("-35", "0,163");
                    dataGridView1.Rows.Add("105", "0,387");
                    dataGridView1.Rows[0].HeaderCell.Value = "1 1";
                    dataGridView1.Rows[1].HeaderCell.Value = "1 2";
                    dataGridView1.Rows[2].HeaderCell.Value = "1 3";
                    dataGridView1.Rows[3].HeaderCell.Value = "2 1";
                    dataGridView1.Rows[4].HeaderCell.Value = "2 2";
                    dataGridView1.Rows[5].HeaderCell.Value = "2 3";
                    dataGridView1.Rows[6].HeaderCell.Value = "3 1";
                    dataGridView1.Rows[7].HeaderCell.Value = "3 2";
                    dataGridView1.Rows[8].HeaderCell.Value = "3 3";
                    break;
                case @"4":
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
                    break;
                case @"5":
                    dataGridView1.Rows.Add("14,2725", "0,95276");
                    dataGridView1.Rows.Add("-4,258", "0,42024");
                    dataGridView1.Rows.Add("-1,562", "0,31561");
                    dataGridView1.Rows.Add("-0,4172", "0,24516");
                    dataGridView1.Rows.Add("-0,6212", "0,20493");
                    dataGridView1.Rows.Add("-4,227", "0,41978");
                    dataGridView1.Rows.Add("16,0508", "1,11895");
                    dataGridView1.Rows.Add("-8,249", "0,5982");
                    dataGridView1.Rows.Add("-0,4753", "0,41767");
                    dataGridView1.Rows.Add("-0,5516", "0,32697");
                    dataGridView1.Rows.Add("-1,491", "0,30302");
                    dataGridView1.Rows.Add("-7,881", "0,57167");
                    dataGridView1.Rows.Add("23,2231", "0,94304");
                    dataGridView1.Rows.Add("-8,55", "0,58762");
                    dataGridView1.Rows.Add("-1,992", "0,43101");
                    dataGridView1.Rows.Add("-0,4", "0,22614");
                    dataGridView1.Rows.Add("-0,4304", "0,37993");
                    dataGridView1.Rows.Add("-8,208", "0,55971");
                    dataGridView1.Rows.Add("21,2451", "1,0282");
                    dataGridView1.Rows.Add("-9,341", "0,60617");
                    dataGridView1.Rows.Add("-0,6199", "0,18794");
                    dataGridView1.Rows.Add("-0,4644", "0,29225");
                    dataGridView1.Rows.Add("-1,768", "0,4033");
                    dataGridView1.Rows.Add("-9,333", "0,60134");
                    dataGridView1.Rows.Add("18,2616", "0,97608");

                    dataGridView1.Rows[0].HeaderCell.Value = "1 1";
                    dataGridView1.Rows[1].HeaderCell.Value = "1 2";
                    dataGridView1.Rows[2].HeaderCell.Value = "1 3";
                    dataGridView1.Rows[3].HeaderCell.Value = "1 4";
                    dataGridView1.Rows[4].HeaderCell.Value = "1 5";
                    dataGridView1.Rows[5].HeaderCell.Value = "2 1";
                    dataGridView1.Rows[6].HeaderCell.Value = "2 2";
                    dataGridView1.Rows[7].HeaderCell.Value = "2 3";
                    dataGridView1.Rows[8].HeaderCell.Value = "2 4";
                    dataGridView1.Rows[9].HeaderCell.Value = "2 5";
                    dataGridView1.Rows[10].HeaderCell.Value = "3 1";
                    dataGridView1.Rows[11].HeaderCell.Value = "3 2";
                    dataGridView1.Rows[12].HeaderCell.Value = "3 3";
                    dataGridView1.Rows[13].HeaderCell.Value = "3 4";
                    dataGridView1.Rows[14].HeaderCell.Value = "3 5";
                    dataGridView1.Rows[15].HeaderCell.Value = "4 1";
                    dataGridView1.Rows[16].HeaderCell.Value = "4 2";
                    dataGridView1.Rows[17].HeaderCell.Value = "4 3";
                    dataGridView1.Rows[18].HeaderCell.Value = "4 4";
                    dataGridView1.Rows[19].HeaderCell.Value = "4 5";
                    dataGridView1.Rows[20].HeaderCell.Value = "5 1";
                    dataGridView1.Rows[21].HeaderCell.Value = "5 2";
                    dataGridView1.Rows[22].HeaderCell.Value = "5 3";
                    dataGridView1.Rows[23].HeaderCell.Value = "5 4";
                    dataGridView1.Rows[24].HeaderCell.Value = "5 5";

                    break;
                case @"6":
                    dataGridView1.Rows.Add("14,6231", "0,8893");
                    dataGridView1.Rows.Add("-4,716", "0,34256");
                    dataGridView1.Rows.Add("-1,077", "0,18835");
                    dataGridView1.Rows.Add("-0,2762", "0,11636");
                    dataGridView1.Rows.Add("-0,1482", "0,08904");
                    dataGridView1.Rows.Add("-0,2107", "0,06916");

                    dataGridView1.Rows.Add("-4,716", "0,342565");
                    dataGridView1.Rows.Add("15,192", "0,96152");
                    dataGridView1.Rows.Add("-4,918", "0,35157");
                    dataGridView1.Rows.Add("-0,4365", "0,19378");
                    dataGridView1.Rows.Add("-0,1928", "0,14143");
                    dataGridView1.Rows.Add("-0,2362", "0,10499");

                    dataGridView1.Rows.Add("-1,077", "0,18835");
                    dataGridView1.Rows.Add("-4,918", "0,35157");
                    dataGridView1.Rows.Add("18,0454", "0,85423");
                    dataGridView1.Rows.Add("-5,43", "0,37231");
                    dataGridView1.Rows.Add("-0,8435", "0,25063");
                    dataGridView1.Rows.Add("-0,7148", "0,17322");

                    dataGridView1.Rows.Add("-0,2761", "0,11636");
                    dataGridView1.Rows.Add("-0,4364", "0,19378");
                    dataGridView1.Rows.Add("-5,43", "0,37231");
                    dataGridView1.Rows.Add("18,4318", "0,92665");
                    dataGridView1.Rows.Add("-7,163", "0,48183");
                    dataGridView1.Rows.Add("-1,296", "0,28293");

                    dataGridView1.Rows.Add("-0,1481", "0,08899");
                    dataGridView1.Rows.Add("-0,1926", "0,14135");
                    dataGridView1.Rows.Add("-0,8431", "0,25048");
                    dataGridView1.Rows.Add("-7,158", "0,48151");
                    dataGridView1.Rows.Add("18,1747", "0,96081");
                    dataGridView1.Rows.Add("-6,191", "0,42585");

                    dataGridView1.Rows.Add("-0,2107", "0,06912");
                    dataGridView1.Rows.Add("-0,2362", "0,10491");
                    dataGridView1.Rows.Add("-0,7147", "0,10491");
                    dataGridView1.Rows.Add("-1,294", "0,17308");
                    dataGridView1.Rows.Add("-6,189", "0,4257");
                    dataGridView1.Rows.Add("15,9755", "0,89456");

                    dataGridView1.Rows[0].HeaderCell.Value = "1 1";
                    dataGridView1.Rows[1].HeaderCell.Value = "1 2";
                    dataGridView1.Rows[2].HeaderCell.Value = "1 3";
                    dataGridView1.Rows[3].HeaderCell.Value = "1 4";
                    dataGridView1.Rows[4].HeaderCell.Value = "1 5";
                    dataGridView1.Rows[5].HeaderCell.Value = "1 6";
                    dataGridView1.Rows[6].HeaderCell.Value = "2 1";
                    dataGridView1.Rows[7].HeaderCell.Value = "2 2";
                    dataGridView1.Rows[8].HeaderCell.Value = "2 3";
                    dataGridView1.Rows[9].HeaderCell.Value = "2 4";
                    dataGridView1.Rows[10].HeaderCell.Value = "2 5";
                    dataGridView1.Rows[11].HeaderCell.Value = "2 6";
                    dataGridView1.Rows[12].HeaderCell.Value = "3 1";
                    dataGridView1.Rows[13].HeaderCell.Value = "3 2";
                    dataGridView1.Rows[14].HeaderCell.Value = "3 3";
                    dataGridView1.Rows[15].HeaderCell.Value = "3 4";
                    dataGridView1.Rows[16].HeaderCell.Value = "3 5";
                    dataGridView1.Rows[17].HeaderCell.Value = "3 6";
                    dataGridView1.Rows[18].HeaderCell.Value = "4 1";
                    dataGridView1.Rows[19].HeaderCell.Value = "4 2";
                    dataGridView1.Rows[20].HeaderCell.Value = "4 3";
                    dataGridView1.Rows[21].HeaderCell.Value = "4 4";
                    dataGridView1.Rows[22].HeaderCell.Value = "4 5";
                    dataGridView1.Rows[23].HeaderCell.Value = "4 6";
                    dataGridView1.Rows[24].HeaderCell.Value = "5 1";
                    dataGridView1.Rows[25].HeaderCell.Value = "5 2";
                    dataGridView1.Rows[26].HeaderCell.Value = "5 3";
                    dataGridView1.Rows[27].HeaderCell.Value = "5 4";
                    dataGridView1.Rows[28].HeaderCell.Value = "5 5";
                    dataGridView1.Rows[29].HeaderCell.Value = "5 6";
                    dataGridView1.Rows[30].HeaderCell.Value = "6 1";
                    dataGridView1.Rows[31].HeaderCell.Value = "6 2";
                    dataGridView1.Rows[32].HeaderCell.Value = "6 3";
                    dataGridView1.Rows[33].HeaderCell.Value = "6 4";
                    dataGridView1.Rows[34].HeaderCell.Value = "6 5";
                    dataGridView1.Rows[34].HeaderCell.Value = "6 6";
                    break;                                       
            }
        }

        private void SParamForm_Load(object sender, EventArgs e)
        {
            GridFill();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void NTextBox_TextChanged(object sender, EventArgs e)
        {
            var n = Convert.ToInt32(NTextBox.Text);
            if (n < 3 || n > 6)
            {
                NTextBox.Text = @"4";
            }

            if (n != 4)
            {
                mode1.Enabled = false;
                mode2.Enabled = false;
                mode3.Enabled = false;
            }
            else
            {
                mode1.Enabled = true;
                mode2.Enabled = true;
                mode3.Enabled = true;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Update();

            GridFill();
        }

        private void NTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
