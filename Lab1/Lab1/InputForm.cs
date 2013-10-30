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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private double[] solveUsingSelectedAlgorithm()
        {
            var algorithmName = algorithmComboBox.SelectedItem.ToString();
            var algorithmClassType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == algorithmName);
            IMatrixSolutionAlgorithm algorithmClass = Activator.CreateInstance(algorithmClassType) as IMatrixSolutionAlgorithm;
            return algorithmClass.Solve(null, null); //TODO: read gridviews
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            var result = solveUsingSelectedAlgorithm();
            var sb = new StringBuilder();
            foreach (var resultItem in result)
            {
                sb.AppendLine(resultItem.ToString());
            }

            MessageBox.Show(sb.ToString());
        }
    }
}
