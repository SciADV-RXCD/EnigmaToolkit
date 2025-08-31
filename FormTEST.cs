using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnigmaToolkit
{
    public partial class FormTEST : Form
    {
        public FormTEST()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var lines = File.ReadAllLines("01015.gstr.txt");
            foreach (var line in lines)
            {
                if (line.StartsWith("--------------------------------------------------------------------------------"))
                    continue;
                if (line.StartsWith("[GSTR]"))
                    continue;
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Add the original text and an empty edited text cell
                dataGridView1.Rows.Add(line, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("01015.gstr.txt");
            int gridRow = 0;

            // We'll build a new list of lines to write back
            var outputLines = new List<string>();

            foreach (var line in lines)
            {
                // Skip lines that are shown in the grid (non-separator, non-header, non-empty)
                if (
                    !line.StartsWith("--------------------------------------------------------------------------------") &&
                    !line.StartsWith("[GSTR]") &&
                    !string.IsNullOrWhiteSpace(line)
                )
                {
                    // If there is an edited value, use it; otherwise, keep the original
                    var edited = dataGridView1.Rows[gridRow].Cells[1].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(edited))
                        outputLines.Add(edited);
                    else
                        outputLines.Add(line);

                    gridRow++;
                }
                else
                {
                    // Keep separator/header/empty lines as-is
                    outputLines.Add(line);
                }
            }

            File.WriteAllLines("01015.gstr.edited.txt", outputLines);
            MessageBox.Show("File saved as 01015.gstr.edited.txt");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only act if the clicked cell is in the first column and a valid row
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var originalText = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = originalText;
            }
        }
    }
}
