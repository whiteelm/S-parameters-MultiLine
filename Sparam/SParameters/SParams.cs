using System;
using System.Collections.Generic;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace SParameters
{
    public class SParams
    {
        /// <summary>
        /// Количество точек.
        /// </summary>
        public int Nf { get; set; }

        /// <summary>
        /// Начало частотных точек.
        /// </summary>
        public int Fmin { get; set; }

        /// <summary>
        /// Конец частотных точек.
        /// </summary>
        public int Fmax { get; set; }

        /// <summary>
        /// Длина линии.
        /// </summary>
        public double Len { get; set; }

        /// <summary>
        /// Индуктивность.
        /// </summary>
        private readonly double[,] _l = new double[4, 4];

        /// <summary>
        /// Индуктивность.
        /// </summary>
        public double[,] L
        {
            get => _l;
            set
            {
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        _l[i, j] = value[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Ёмкость.
        /// </summary>
        private readonly double[,] _c = new double[4, 4];

        /// <summary>
        /// Ёмкость.
        /// </summary>
        public double[,] C
        {
            get => _c;
            set
            {
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        _c[i, j] = value[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Входная нагрузка.
        /// </summary>
        public double[] Z { get; set; }

        ///// <summary>
        ///// S - параметры.
        ///// </summary>
        public List<double[]> S = new List<double[]>();

        /// <summary>
        /// Fi-параметры.
        /// </summary>
        public List<double[]> Fi = new List<double[]>();

        /// <summary>
        /// Мнимая единица.
        /// </summary>
        public Complex32 Zi = new Complex32(0, 1);

        /// <summary>
        /// Расчёт S-параметров.
        /// </summary>
        /// <param name="nf">Количество точек.</param>
        /// <param name="fmin">Начало частотных точек.</param>
        /// <param name="fmax">Конец частотных точек.</param>
        /// <param name="len">Длина линии.</param>
        /// <param name="l">Индуктивность.</param>
        /// <param name="c">Ёмкость.</param>
        /// <param name="z">Входная нагрузка.</param>
        public SParams(int nf, int fmin, int fmax, double len,
            double[,] l, double[,] c, double[] z)
        {
            Nf = nf;
            Fmin = fmin;
            Fmax = fmax;
            Len = len;

            L = l;
            C = c;

            Z = z;
        }

        /// <summary>
        /// Расчёт S-параметров.
        /// <param name="mode">Режим:
        /// 0 - Lange;
        /// 1 - Meander;
        /// 2 - InterDigital</param>
        /// </summary>
        public void CalculateSParameters(int mode)
        {
            var f = Vector<double>.Build.Dense(Nf);
            var w = Vector<double>.Build.Dense(Nf);
            var dl = Matrix<double>.Build.DenseOfArray(L);
            var dc = Matrix<double>.Build.DenseOfArray(C);
            var q = dl * dc;
            var eigen = q.Evd();
            const double c = 0.2998;
            var eps = c * c * eigen.EigenValues.Real();
            for (var i = 0; i < Nf; i++)
            {
                f[i] = Fmin + ((double)Fmax - Fmin) /
                    ((double)Nf - 1) * i;
                w[i] = 2 * Math.PI * f[i];
            }
            var um = eigen.EigenVectors;
            var dz = Matrix<Complex32>.Build.Dense(4, 4);
            for (var i = 0; i < Z.Length; i++)
            {
                dz[i, i] = (Complex32)Math.Sqrt(Z[i]);
            }
            var v = Matrix<double>.Build.Dense(4, 4);
            var vivec = Vector<double>.Build.Dense(4);
            for (var i = 0; i < eps.Count; i++)
            {
                v[i, i] = c / Math.Sqrt(eps[i]);
                vivec[i] = c / Math.Sqrt(eps[i]);
            }
            
            var im = dc * um * v * 0.001;
            var co = new List<Matrix<Complex32>>();
            var sc = new List<Matrix<Complex32>>();
            var tempM = Matrix<Complex32>.Build.Dense(4, 4);
            for (var i = 0; i < Nf; i++)
            {
                var tempV = (w[i] / vivec) * Len;
                for (var k = 0; k < 4; k++)
                {
                    Console.WriteLine(tempV[k]);
                }
                for (var j = 0; j < v.ColumnCount; j++)
                {
                    tempM[j, j] = 1 / Complex32.Tanh(
                        (Complex32)tempV[j] * Zi);
                }
                co.Add(tempM);
                for (var j = 0; j < v.ColumnCount; j++) 
                {
                    tempM[j, j] = 1 / Complex32.Sinh(
                        (Complex32)tempV[j] * Zi);
                }
                sc.Add(tempM);
            }
            
            //var zm = um * im.Inverse();
            var yaa = new List<Matrix<Complex32>>();
            var yab = new List<Matrix<Complex32>>();
            var imComplex = Matrix<Complex32>.Build.Dense(4, 4);
            var umComplex = Matrix<Complex32>.Build.Dense(4, 4);
            for (var i = 0; i < im.ColumnCount; i++)
            {
                for (var j = 0; j < im.ColumnCount; j++)
                {
                    imComplex[i, j] = (Complex32)im[i, j];
                    umComplex[i, j] = (Complex32)um[i, j];
                }
            }
            for (var i = 0; i < Nf; i++)
            {
                yaa.Add(imComplex * co[i] * (umComplex.Inverse()));
                yab.Add(imComplex * sc[i] * (umComplex.Inverse()));
            }
            var y = new List<Matrix<Complex32>>();
            var tempY = Matrix<Complex32>.Build.Dense(8, 8);
            for (var i = 0; i < Nf; i++)
            {
                tempY[0, 0] = yaa[i][0, 0];
                tempY[0, 1] = yaa[i][0, 1];
                tempY[0, 2] = yaa[i][0, 2];
                tempY[0, 3] = yaa[i][0, 3];
                tempY[0, 4] = yab[i][0, 0];
                tempY[0, 5] = yab[i][0, 1];
                tempY[0, 6] = yab[i][0, 2];
                tempY[0, 7] = yab[i][0, 3];
                tempY[1, 0] = yaa[i][1, 0];
                tempY[1, 1] = yaa[i][1, 1];
                tempY[1, 2] = yaa[i][1, 2];
                tempY[1, 3] = yaa[i][1, 3];
                tempY[1, 4] = yab[i][1, 0];
                tempY[1, 5] = yab[i][1, 1];
                tempY[1, 6] = yab[i][1, 2];
                tempY[1, 7] = yab[i][1, 3];
                tempY[2, 0] = yaa[i][2, 0];
                tempY[2, 1] = yaa[i][2, 1];
                tempY[2, 2] = yaa[i][2, 2];
                tempY[2, 3] = yaa[i][2, 3];
                tempY[2, 4] = yab[i][2, 0];
                tempY[2, 5] = yab[i][2, 1];
                tempY[2, 6] = yab[i][2, 2];
                tempY[2, 7] = yab[i][2, 3];
                tempY[3, 0] = yaa[i][3, 0];
                tempY[3, 1] = yaa[i][3, 1];
                tempY[3, 2] = yaa[i][3, 2];
                tempY[3, 3] = yaa[i][3, 3];
                tempY[3, 4] = yab[i][3, 0];
                tempY[3, 5] = yab[i][3, 1];
                tempY[3, 6] = yab[i][3, 2];
                tempY[3, 7] = yab[i][3, 3];
                tempY[4, 0] = yaa[i][0, 0];
                tempY[4, 1] = yaa[i][0, 1];
                tempY[4, 2] = yaa[i][0, 2];
                tempY[4, 3] = yaa[i][0, 3];
                tempY[4, 4] = yab[i][0, 0];
                tempY[4, 5] = yab[i][0, 1];
                tempY[4, 6] = yab[i][0, 2];
                tempY[4, 7] = yab[i][0, 3];
                tempY[5, 0] = yaa[i][1, 0];
                tempY[5, 1] = yaa[i][1, 1];
                tempY[5, 2] = yaa[i][1, 2];
                tempY[5, 3] = yaa[i][1, 3];
                tempY[5, 4] = yab[i][1, 0];
                tempY[5, 5] = yab[i][1, 1];
                tempY[5, 6] = yab[i][1, 2];
                tempY[5, 7] = yab[i][1, 3];
                tempY[6, 0] = yaa[i][2, 0];
                tempY[6, 1] = yaa[i][2, 1];
                tempY[6, 2] = yaa[i][2, 2];
                tempY[6, 3] = yaa[i][2, 3];
                tempY[6, 4] = yab[i][2, 0];
                tempY[6, 5] = yab[i][2, 1];
                tempY[6, 6] = yab[i][2, 2];
                tempY[6, 7] = yab[i][2, 3];
                tempY[7, 0] = yaa[i][3, 0];
                tempY[7, 1] = yaa[i][3, 1];
                tempY[7, 2] = yaa[i][3, 2];
                tempY[7, 3] = yaa[i][3, 3];
                tempY[7, 4] = yab[i][3, 0];
                tempY[7, 5] = yab[i][3, 1];
                tempY[7, 6] = yab[i][3, 2];
                tempY[7, 7] = yab[i][3, 3];
                y.Add(tempY);
            }

            var yo = new List<Matrix<Complex32>>();

            for (var i = 0; i < Nf; i++)
            {
                tempM[0, 0] = y[i][0, 0] + y[i][0, 2] + y[i][2, 0] + y[i][2, 2];
                tempM[0, 1] = y[i][0, 1] + y[i][0, 3] + y[i][2, 1] + y[i][2, 3];
                tempM[0, 2] = y[i][0, 4] + y[i][0, 6] + y[i][2, 4] + y[i][2, 6];
                tempM[0, 3] = y[i][0, 5] + y[i][0, 7] + y[i][2, 5] + y[i][2, 6];
                tempM[1, 0] = y[i][0, 0] + y[i][0, 2] + y[i][2, 0] + y[i][2, 2];
                tempM[1, 1] = y[i][1, 1] + y[i][1, 3] + y[i][3, 1] + y[i][3, 3];
                tempM[1, 2] = y[i][1, 4] + y[i][1, 6] + y[i][3, 4] + y[i][3, 6];
                tempM[1, 3] = y[i][1, 5] + y[i][1, 7] + y[i][3, 5] + y[i][3, 7];
                tempM[2, 0] = y[i][0, 4] + y[i][0, 6] + y[i][2, 4] + y[i][2, 6];
                tempM[2, 1] = y[i][1, 4] + y[i][1, 6] + y[i][3, 4] + y[i][3, 6];
                tempM[2, 2] = y[i][4, 4] + y[i][4, 6] + y[i][6, 4] + y[i][6, 6];
                tempM[2, 3] = y[i][4, 5] + y[i][4, 7] + y[i][6, 5] + y[i][6, 7];
                tempM[3, 0] = y[i][0, 5] + y[i][0, 7] + y[i][2, 5] + y[i][2, 6];
                tempM[3, 1] = y[i][1, 5] + y[i][1, 7] + y[i][3, 5] + y[i][3, 7];
                tempM[3, 2] = y[i][4, 5] + y[i][4, 7] + y[i][6, 5] + y[i][6, 7];
                tempM[3, 3] = y[i][4, 5] + y[i][4, 7] + y[i][6, 5] + y[i][6, 7];
                yo.Add(tempM);
            }

            var upsilon = new List<Matrix<Complex32>>();

            for (var i = 0; i < Nf; i++)
            {
                upsilon.Add(dz * yo[i] * dz);
            }

            var e1 = Matrix<Complex32>.Build.Dense(4, 4, 0);
            for (var i = 0; i < e1.ColumnCount; i++)
            {
                e1[i, i] = 1;
            }
            var ss = new List<Matrix<Complex32>>();
            for (var i = 0; i < Nf; i++)
            {
                ss.Add(2 * (e1 + upsilon[i]).Inverse() - e1);
            }

            var s11 = new double[Nf];
            var s12 = new double[Nf];
            var s13 = new double[Nf];
            var s14 = new double[Nf];
            var s22 = new double[Nf];
            var s23 = new double[Nf];
            var s24 = new double[Nf];
            var s33 = new double[Nf];
            var s34 = new double[Nf];
            var s44 = new double[Nf];
            var fi11 = new double[Nf];
            var fi12 = new double[Nf];
            var fi13 = new double[Nf];
            var fi14 = new double[Nf];
            var fi22 = new double[Nf];
            var fi23 = new double[Nf];
            var fi24 = new double[Nf];
            var fi33 = new double[Nf];
            var fi34 = new double[Nf];
            var fi44 = new double[Nf];
            for (var i = 2; i < Nf; i++)
            {
                s11[i] = 20 * Math.Log10(Complex32.Abs(ss[i][0, 0]));
                s12[i] = 20 * Math.Log10(Complex32.Abs(ss[i][0, 1]));
                s13[i] = 20 * Math.Log10(Complex32.Abs(ss[i][0, 2]));
                s14[i] = 20 * Math.Log10(Complex32.Abs(ss[i][0, 3]));
                s22[i] = 20 * Math.Log10(Complex32.Abs(ss[i][1, 1]));
                s23[i] = 20 * Math.Log10(Complex32.Abs(ss[i][1, 2]));
                s24[i] = 20 * Math.Log10(Complex32.Abs(ss[i][1, 3]));
                s33[i] = 20 * Math.Log10(Complex32.Abs(ss[i][2, 2]));
                s34[i] = 20 * Math.Log10(Complex32.Abs(ss[i][2, 3]));
                s44[i] = 20 * Math.Log10(Complex32.Abs(ss[i][3, 3]));
                fi11[i] = ss[i][0, 0].Phase * 57.3;
                fi12[i] = ss[i][0, 1].Phase * 57.3;
                fi13[i] = ss[i][0, 2].Phase * 57.3;
                fi14[i] = ss[i][0, 3].Phase * 57.3;
                fi22[i] = ss[i][1, 1].Phase * 57.3;
                fi23[i] = ss[i][1, 2].Phase * 57.3;
                fi24[i] = ss[i][1, 3].Phase * 57.3;
                fi33[i] = ss[i][2, 2].Phase * 57.3;
                fi34[i] = ss[i][2, 3].Phase * 57.3;
                fi44[i] = ss[i][3, 3].Phase * 57.3;
            }
            S.Add(s11);
            S.Add(s12);
            S.Add(s13);
            S.Add(s14);
            S.Add(s22);
            S.Add(s23);
            S.Add(s24);
            S.Add(s33);
            S.Add(s34);
            S.Add(s44);
            Fi.Add(fi11);
            Fi.Add(fi12);
            Fi.Add(fi13);
            Fi.Add(fi14);
            Fi.Add(fi22);
            Fi.Add(fi23);
            Fi.Add(fi24);
            Fi.Add(fi33);
            Fi.Add(fi34);
            Fi.Add(fi44);
        }
    }
}


