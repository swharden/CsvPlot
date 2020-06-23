using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace CsvPlot
{
    public class CsvParser
    {
        public readonly string FilePath;
        public readonly int Columns;
        public readonly int Rows;
        public readonly double[,] Values;

        public CsvParser(string filePath, char delimiter = ',')
        {
            FilePath = Path.GetFullPath(filePath);

            if (!File.Exists(filePath))
                throw new ArgumentException($"File does not exist: {FilePath}");

            string[] lines = File.ReadAllLines(filePath);
            int maxHeaderLines = 50;

            int firstDataLineIndex = 0;
            for (int i = 0; i < Math.Min(maxHeaderLines, lines.Length); i++)
            {
                double[] lineValues = TryLineParse(lines[i], delimiter);
                if (lineValues != null)
                {
                    Columns = lineValues.Length;
                    Rows = lines.Length - i;
                    firstDataLineIndex = i;
                    Console.WriteLine($"First data row (line index {i}) has {Columns} columns");
                    break;
                }
            }

            if (Columns == 0)
                throw new ArgumentException("CSV file could not be parsed. No columns identified.");

            Debug.WriteLine($"Preparing values matrix with {Columns} columns and {Rows} rows");
            Values = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                double[] lineValues = TryLineParse(lines[i + firstDataLineIndex], delimiter);

                if (lineValues is null)
                {
                    Debug.WriteLine($"WARNING: line index {i} did not parse");
                }
                else if (lineValues.Length > Columns)
                {
                    Debug.WriteLine($"WARNING: line index {i} had more values than columns");
                }
                else
                {
                    for (int j = 0; j < Math.Min(Columns, lineValues.Length); j++)
                        Values[i, j] = lineValues[j];
                }
            }
        }

        private static double[] TryLineParse(string line, char delimiter)
        {
            if (line.Trim().StartsWith("#"))
                return null;

            string[] parts = line.Split(delimiter);
            List<double> values = new List<double>();

            try
            {
                // every non-whitespace field should be have a numeric value
                for (int i = 0; i < parts.Length; i++)
                    if (string.IsNullOrWhiteSpace(parts[i]) == false)
                        values.Add(double.Parse(parts[i]));
            }
            catch
            {
                return null;
            }

            if (values.Count > 0)
                return values.ToArray();
            else
                return null;
        }
    }
}
