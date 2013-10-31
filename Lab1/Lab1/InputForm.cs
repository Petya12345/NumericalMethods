using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Lab1
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            //load available algorithms
            var assembly = Assembly.GetExecutingAssembly();
            var interfaceType = typeof(IMatrixSolutionAlgorithm);
            var algorithmTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceType));
            foreach (var algorithmType in algorithmTypes)
            {
                algorithmComboBox.Items.Add(algorithmType.Name);
            }
            algorithmComboBox.SelectedIndex = 0;
        }

        private void setMatrixSizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var size = Convert.ToInt32(maskedTextBox1.Text);
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                for (int i = 0; i < size; i++)
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = i.ToString(),
                        HeaderText = i.ToString(),
                        Width = 20
                    });


                    dataGridView1.Rows.Add();
                }

                dataGridView2.Rows.Clear();
                for (int i = 0; i < size; i++)
                {
                    dataGridView2.Rows.Add();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private double[] solveUsingSelectedAlgorithm(double[,] A, double[] B, ref double epsilon)
        {
            var algorithmName = algorithmComboBox.SelectedItem.ToString();
            var algorithmClassType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == algorithmName);
            IMatrixSolutionAlgorithm algorithmClass = Activator.CreateInstance(algorithmClassType) as IMatrixSolutionAlgorithm;
            return algorithmClass.Solve(A, B, ref epsilon);
        }

        private double[] getBVector()
        {
            var vector = new double[dataGridView2.Rows.Count];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                vector[i] = Convert.ToDouble(dataGridView2[0, i].Value);
            }
            return vector;
        }

        private double[,] getAMatrix()
        {
            var size = dataGridView1.Rows.Count;
            var matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
            }
            return matrix;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            var epsilon = double.Parse(epsilonTextBox.Text);
            var result = solveUsingSelectedAlgorithm(getAMatrix(), getBVector(), ref epsilon);
            var sb = new StringBuilder();
            foreach (var resultItem in result)
            {
                sb.AppendLine(resultItem.ToString());
            }
            if (epsilon > 1)
            {
                sb.AppendFormat("Number Of Iterations: {0}", (int)epsilon);
            }
            MessageBox.Show(sb.ToString());
        }

        private void condButton_Click(object sender, EventArgs e)
        {
            double[] B = getBVector(); //B
            double[] dB = new double[B.Length];
            double epsilon = 0.0001;
            double[] X = solveUsingSelectedAlgorithm(getAMatrix(), getBVector(), ref epsilon); //X

            for (int i = 0; i < B.Length; i++) 
            {
                dB[i] = B[i] * 1.01; //dB
            }

            double[] dX = solveUsingSelectedAlgorithm(getAMatrix(), dB, ref epsilon); //dX
            double dXNorm, XNorm, dBNorm, BNorm;

            XNorm = norm(X);
            dXNorm = norm(dX);
            BNorm = norm(B);
            dBNorm = norm(dB);

            double condA = (dXNorm / XNorm) / (dBNorm / BNorm);

            MessageBox.Show(condA.ToString());
        }

        private double norm(double[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; i++) 
            {
                sum += vector[i] * vector[i];
            }
            return Math.Sqrt(sum);
        }
    }
}
