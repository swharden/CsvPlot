using ScottPlot.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvPlot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string startupFile = "../../../../data/17o05028_ic_steps.csv";
            LoadFile(Path.GetFullPath(startupFile));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbFirstColX_CheckedChanged(object sender, EventArgs e) => MakePlot();
        private void nudColumn_ValueChanged(object sender, EventArgs e) => MakePlot();
        private void cbAllColumns_CheckedChanged(object sender, EventArgs e) => MakePlot();

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "CSV files (*.csv)|*.csv";
            //diag.Filter += "|TSV Files (*.tsv)|*.csv";
            diag.Filter += "|All files (*.*)|*.*";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                LoadFile(diag.FileName);
            }
        }

        double[,] values;
        private void LoadFile(string filePath)
        {
            filePath = Path.GetFullPath(filePath);
            tbFile.Text = Path.GetFileName(filePath);
            values = new CsvParser(filePath).Values;

            cbSignal.Checked = true;
            cbSignal.Enabled = (values.GetLength(0) < 1000);

            nudColumn.Maximum = values.GetLength(1);
            cbAllColumns.Checked = true;

            MakePlot();
        }


        private void MakePlot()
        {
            Colormap cmap = Colormap.Turbo;
            formsPlot1.plt.Clear();

            if (cbFirstColX.Checked)
            {
                if (cbSignal.Checked)
                {
                    // signal plots with spacing from first column
                    double dX = values[1, 0] - values[0, 0];

                    for (int y = 1; y < values.GetLength(1); y++)
                    {
                        double[] ys = new double[values.GetLength(0)];
                        for (int i = 0; i < values.GetLength(0); i++)
                            ys[i] = values[i, y];

                        Color? c = null;
                        if (cbAllColumns.Checked)
                            c = cmap.GetColor((double)y / values.GetLength(1));

                        if (cbAllColumns.Checked || nudColumn.Value == y)
                            formsPlot1.plt.PlotSignal(ys, sampleRate: 1 / dX, color: c);
                    }
                }
                else
                {
                    // individual scatter plots
                    double[] xs = new double[values.GetLength(0)];
                    for (int i = 0; i < values.GetLength(0); i++)
                        xs[i] = values[i, 0];

                    for (int y = 1; y < values.GetLength(1); y++)
                    {
                        double[] ys = new double[values.GetLength(0)];
                        for (int i = 0; i < values.GetLength(0); i++)
                            ys[i] = values[i, y];

                        Color? c = null;
                        if (cbAllColumns.Checked)
                            c = cmap.GetColor((double)y / values.GetLength(1));

                        if (cbAllColumns.Checked || nudColumn.Value == y)
                            formsPlot1.plt.PlotScatter(xs, ys, color: c);
                    }
                }
            }
            else
            {
                // signal plots with default spacing
                for (int y = 0; y < values.GetLength(1); y++)
                {
                    double[] ys = new double[values.GetLength(0)];
                    for (int i = 0; i < values.GetLength(0); i++)
                        ys[i] = values[i, y];

                    Color? c = null;
                    if (cbAllColumns.Checked)
                        c = cmap.GetColor((double)y / values.GetLength(1));

                    if (cbAllColumns.Checked || nudColumn.Value == y)
                        formsPlot1.plt.PlotSignal(ys, color: c);
                }
            }

            formsPlot1.Render();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            LoadFile(s.First());
        }
    }
}
