using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void inputbutton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ColumnCount = int.Parse(textBox1.Text);
                dataGridView1.RowCount = 2;
                dataGridView1.Rows[0].HeaderCell.Value = "a";
                dataGridView1.Rows[1].HeaderCell.Value = "b";
                dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }
            catch (Exception)
            {
                MessageBox.Show($"Enter a valid number!");
            }

            dataGridView1.AllowUserToAddRows = false;
           
            int colNumber = 1;
            foreach(DataGridViewColumn col in dataGridView1.Columns)
            {
        
                col.HeaderText = colNumber.ToString();
                colNumber = colNumber + 1;
            }
          
        }

        /// <summary>
        /// This function validates user's input. It only allows numeric values.
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="valuesA"></param>
        /// <param name="valuesB"></param>
        /// <returns>Lists containing user's numbers</returns>

        private bool Validation(DataGridView dataGridView1,out List<double> valuesA, out List<double> valuesB)
        {
             valuesA = new List<double>();
             valuesB = new List<double>();
         

            foreach (DataGridViewCell cell in dataGridView1.Rows[0].Cells)
            {
                try
                {
                    valuesA.Add(double.Parse(cell.Value.ToString()));
                }
                catch (Exception)
                {
                    MessageBox.Show($"Invalid data. Try again!");
                    return false;
                }
            }
            foreach (DataGridViewCell cell in dataGridView1.Rows[1].Cells)
            {
                try
                {
                    valuesB.Add(Convert.ToDouble(cell.Value.ToString()));
                }
                catch (Exception)
                {
                    MessageBox.Show($"Invalid data. Try again!");
                    return false;
                }
            }
            return true;

        }


        private void resbutton_Click(object sender, EventArgs e)
        {
            List<double> valuesMultiplied = new List<double>();
            List<double> valuesA = new List<double>();
            List<double> valuesB = new List<double>();
            if (Validation(dataGridView1, out valuesA, out valuesB))
            {

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    valuesMultiplied.Add(valuesA[i] * valuesB[i]);
                }

                var most = valuesMultiplied.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                MessageBox.Show($"The most occuring element of multiplied arrays (if none show the first element) is: {most}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
