using System;
using System.Collections.Generic;
using System.Numerics;
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
        private readonly double[,] _l;

        /// <summary>
        /// Индуктивность.
        /// </summary>
        public double[,] L
        {
            get => _l;
            set
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        _l[i, j] = value[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Индуктивность.
        /// </summary>
        private int _n;

        /// <summary>
        /// Индуктивность.
        /// </summary>
        public int N
        {
            get => _n;
            set
            {
                if (value > 6 || value < 2)
                {
                    throw new ArgumentException("Number of lines can't be " +
                                        "less than 2 and more than 6.");
                }
                _n = value;
            }
        }

        /// <summary>
        /// Ёмкость.
        /// </summary>
        private readonly double[,] _c;

        /// <summary>
        /// Ёмкость.
        /// </summary>
        public double[,] C
        {
            get => _c;
            set
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
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
        public Complex Zi = new Complex(0, 1);

        /// <summary>
        /// Расчёт S-параметров.
        /// </summary>
        /// <param name="n">Количество линий.</param>
        /// <param name="nf">Количество точек.</param>
        /// <param name="fmin">Начало частотных точек.</param>
        /// <param name="fmax">Конец частотных точек.</param>
        /// <param name="len">Длина линии.</param>
        /// <param name="l">Индуктивность.</param>
        /// <param name="c">Ёмкость.</param>
        /// <param name="z">Входная нагрузка.</param>
        public SParams(int n, int nf, int fmin, int fmax, double len,
            double[,] l, double[,] c, double[] z)
        {
            N = n;
            _l = new double[N, N];
            _c = new double[N, N];
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
        /// 0 - General;
        /// 1 - Lange;
        /// 2 - Meander;
        /// 3 - InterDigital</param>
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
            var dz = Matrix<Complex>.Build.Dense(N + N, N + N);
            if (mode == 1)
            {
                dz = Matrix<Complex>.Build.Dense(N, N);
            }
            if (mode == 2 || mode == 3)
            {
                dz = Matrix<Complex>.Build.Dense(2, 2);
            }
            for (var i = 0; i < dz.RowCount; i++)
            {
                dz[i, i] = Math.Sqrt(Z[i]);
            }
            var v = Matrix<double>.Build.Dense(N, N);
            var vivec = Vector<double>.Build.Dense(N);
            for (var i = 0; i < eps.Count; i++)
            {
                v[i, i] = c / Math.Sqrt(eps[i]);
                vivec[i] = c / Math.Sqrt(eps[i]);
            }

            var im = dc * um * v * 0.001;
            var co = new List<Matrix<Complex>>();
            var sc = new List<Matrix<Complex>>();

            for (var i = 0; i < Nf; i++)
            {
                var tempM = Matrix<Complex>.Build.Dense(N, N);
                var tempV = (w[i] / vivec) * Len;

                for (var j = 0; j < v.ColumnCount; j++)
                {
                    tempM[j, j] = 1 / Complex.Tanh(tempV[j] * Zi);
                }
                co.Add(tempM);
                var tet = Matrix<Complex>.Build.Dense(N, N);
                for (var j = 0; j < v.ColumnCount; j++)
                {
                    tet[j, j] = 1 / Complex.Sinh(tempV[j] * Zi);
                }
                sc.Add(tet);
            }

            var yaa = new List<Matrix<Complex>>();
            var yab = new List<Matrix<Complex>>();
            var imComplex = Matrix<Complex>.Build.Dense(N, N);
            var umComplex = Matrix<Complex>.Build.Dense(N, N);
            for (var i = 0; i < im.ColumnCount; i++)
            {
                for (var j = 0; j < im.ColumnCount; j++)
                {
                    imComplex[i, j] = im[i, j];
                    umComplex[i, j] = um[i, j];
                }
            }
            //for (var k = 0; k < Nf; k++)
            //{
            //    for (var i = 0; i < im.ColumnCount; i++)
            //    {
            //        for (var j = 0; j < im.ColumnCount; j++)
            //        {
            //            yaa.Add(Matrix<Complex>.Build.Dense(N, N));
            //            yab.Add(Matrix<Complex>.Build.Dense(N, N));
            //            yaa[k][i, j] = i + j;
            //            yab[k][i, j] = i + j + 10;
            //        }
            //    }
            //}
            for (var i = 0; i < Nf; i++)
            {
                yaa.Add(imComplex * co[i] * (umComplex.Inverse()));
                yab.Add(-imComplex * sc[i] * (umComplex.Inverse()));
            }

            var i1 = 0;
            var j1 = 0;
            var y = new List<Matrix<Complex>>();
            for (var i = 0; i < Nf; i++)
            {
                var tempY = Matrix<Complex>.Build.Dense(N+N, N+N);
                for (var j = 0; j < N + N; j++)
                {
                    for (var k = 0; k < N + N; k++)
                    {
                        if ((j < N && k < N) || (j >= N && k >= N))
                        {
                            tempY[j, k] = yaa[i][i1, j1];
                        }
                        else
                        {
                            tempY[j, k] = yab[i][i1, j1];
                        }
                        j1++;
                        if (j1 >= N)
                        {
                            j1 = 0;
                        }
                    }
                    i1++;
                    if (i1 >= N)
                    {
                        i1 = 0;
                    }
                }
                y.Add(tempY);
            }
            
            var ss = new List<Matrix<Complex>>();
            var dz1 = Matrix<Complex>.Build.Dense(
                2, 2, 0);
            dz1[0, 0] = dz[0, 0];
            dz1[1, 1] = dz[1, 1];
            var yN = y[0].ColumnCount;
            if (mode == 1 && N == 4)
            {
                yN = 4;
            }
            var eN = Matrix<Complex>.Build.Dense(
                yN, yN, 0);
            for (var i = 0; i < yN; i++)
            {
                eN[i, i] = 1;
            }
            switch (mode)
            {
                case 0:
                    {
                        for (var i = 0; i < Nf; i++)
                        {
                            ss.Add(2 * (eN + dz * y[i] * dz).Inverse() - eN);
                        }
                        break;
                    }
                case 1:
                    {
                        var yo = new List<Matrix<Complex>>();
                        for (var i = 0; i < Nf; i++)
                        {
                            var tempM = Matrix<Complex>.Build.Dense(N, N);
                            tempM[0, 0] = y[i][0, 0] + y[i][0, 2] + y[i][2, 0] + y[i][2, 2];
                            tempM[0, 1] = y[i][0, 1] + y[i][0, 3] + y[i][2, 1] + y[i][2, 3];
                            tempM[0, 2] = y[i][0, 4] + y[i][0, 6] + y[i][2, 4] + y[i][2, 6];
                            tempM[0, 3] = y[i][0, 5] + y[i][0, 7] + y[i][2, 5] + y[i][2, 7];

                            tempM[1, 0] = y[i][0, 1] + y[i][0, 3] + y[i][2, 1] + y[i][2, 3];
                            tempM[1, 1] = y[i][1, 1] + y[i][1, 3] + y[i][3, 1] + y[i][3, 3];
                            tempM[1, 2] = y[i][1, 4] + y[i][1, 6] + y[i][3, 4] + y[i][3, 6];
                            tempM[1, 3] = y[i][1, 5] + y[i][1, 7] + y[i][3, 5] + y[i][3, 7];

                            tempM[2, 0] = y[i][0, 4] + y[i][0, 6] + y[i][2, 4] + y[i][2, 6];
                            tempM[2, 1] = y[i][1, 4] + y[i][1, 6] + y[i][3, 4] + y[i][3, 6];
                            tempM[2, 2] = y[i][4, 4] + y[i][4, 6] + y[i][6, 4] + y[i][6, 6];
                            tempM[2, 3] = y[i][4, 5] + y[i][4, 7] + y[i][6, 5] + y[i][6, 7];

                            tempM[3, 0] = y[i][0, 5] + y[i][0, 7] + y[i][2, 5] + y[i][2, 7];
                            tempM[3, 1] = y[i][1, 5] + y[i][1, 7] + y[i][3, 5] + y[i][3, 7];
                            tempM[3, 2] = y[i][4, 5] + y[i][4, 7] + y[i][6, 5] + y[i][6, 7];
                            tempM[3, 3] = y[i][5, 5] + y[i][5, 7] + y[i][7, 5] + y[i][7, 7];
                            yo.Add(tempM);
                        }

                        var upsilon = new List<Matrix<Complex>>();
                        for (var i = 0; i < Nf; i++)
                        {
                            var u = dz * yo[i] * dz;
                            upsilon.Add(u);
                        }

                        for (var i = 0; i < Nf; i++)
                        {
                            ss.Add(2 * (eN + upsilon[i]).Inverse() - eN);
                        }
                        break;
                    }
                case 2:
                    {
                        var meandr = new List<Matrix<Complex>>();
                        var z = new List<Matrix<Complex>>();
                        var zo = new List<Matrix<Complex>>();
                        var zi = new List<Matrix<Complex>>();
                        var e2 = Matrix<Complex>.Build.Dense(
                            2, 2, 0);
                        e2[0, 0] = 1;
                        e2[1, 1] = 1;
                        for (var i = 0; i < Nf; i++)
                        {
                            meandr.Add(Matrix<Complex>.Build.Dense(
                                8, 8));
                            z.Add(Matrix<Complex>.Build.Dense(
                                8, 8));
                            zo.Add(Matrix<Complex>.Build.Dense(
                                2, 2));
                            zi.Add(Matrix<Complex>.Build.Dense(
                                2, 2));
                            ss.Add(Matrix<Complex>.Build.Dense(
                                2, 2));
                            meandr[i][1, 1] = 1e10;
                            meandr[i][1, 2] = (-1e10);
                            meandr[i][2, 1] = (-1e10);
                            meandr[i][2, 2] = 1e10;
                            meandr[i][4, 4] = 1e10;
                            meandr[i][4, 5] = (-1e10);
                            meandr[i][5, 4] = (-1e10);
                            meandr[i][5, 5] = 1e10;
                            meandr[i][6, 6] = 1e10;
                            meandr[i][6, 7] = (-1e10);
                            meandr[i][7, 6] = (-1e10);
                            meandr[i][7, 7] = 1e10;
                            z[i] = (y[i] + meandr[i]).Inverse();
                            zo[i][0, 0] = z[i][0, 0];
                            zo[i][0, 1] = z[i][0, 3];
                            zo[i][1, 0] = z[i][3, 0];
                            zo[i][1, 1] = z[i][3, 3];
                            zi[i] = dz1.Inverse() * zo[i] * dz1.Inverse();
                            ss[i] = e2 - 2 * (e2 + zi[i]).Inverse();
                        }
                    }
                    break;
                case 3:
                    {
                        var meandr = new List<Matrix<Complex>>();
                        var z = new List<Matrix<Complex>>();
                        var yM = new List<Matrix<Complex>>();
                        var zo = new List<Matrix<Complex>>();
                        var zi = new List<Matrix<Complex>>();
                        var e2 = Matrix<Complex>.Build.Dense(
                            2, 2, 0);
                        e2[0, 0] = 1;
                        e2[1, 1] = 1;
                        for (var i = 0; i < Nf; i++)
                        {
                            meandr.Add(Matrix<Complex>.Build.Dense(
                                8, 8));
                            yM.Add(Matrix<Complex>.Build.Dense(
                                8, 8));
                            z.Add(Matrix<Complex>.Build.Dense(
                                8, 8));
                            zo.Add(Matrix<Complex>.Build.Dense(
                                2, 2));
                            zi.Add(Matrix<Complex>.Build.Dense(
                                2, 2));
                            ss.Add(Matrix<Complex>.Build.Dense(
                                2, 2));
                            meandr[i][1, 1] = 1e-10;
                            meandr[i][2, 2] = 1e10;
                            meandr[i][3, 3] = 1e-10;
                            meandr[i][4, 4] = 1e-10;
                            meandr[i][5, 5] = 1e10;
                            meandr[i][6, 6] = 1e-10;
                            yM[i] = y[i] + meandr[i];
                            z[i] = yM[i].Inverse();

                            zo[i][0, 0] = z[i][0, 0];
                            zo[i][0, 1] = z[i][0, 7];
                            zo[i][1, 0] = z[i][7, 0];
                            zo[i][1, 1] = z[i][7, 7];
                            zi[i] = dz1.Inverse() * zo[i] * dz1.Inverse();
                            ss[i] = e2 - 2 * (e2 + zi[i]).Inverse();
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Неправильный режим.");
            }

            var nG = N + N;
            if (mode == 1)
            {
                nG = 4;
            }
            if (mode == 2 || mode == 3)
            {
                nG = 2;
            }
            
            for (var i = 0; i < nG; i++)
            {
                for (var j = i; j < nG; j++)
                {
                    var s = new double[Nf];
                    var fi = new double[Nf];
                    for (var k = 1; k < Nf; k++)
                    {
                        s[k] = 20 * Math.Log10(Complex.Abs(ss[k][i, j]));
                        fi[k] = ss[k][i, j].Phase * 57.3;
                    }
                    S.Add(s);
                    Fi.Add(fi);
                }
            }
        }
    }
}


