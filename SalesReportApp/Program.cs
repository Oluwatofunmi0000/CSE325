using System;
using System.IO;
using System.Text;
using System.Globalization;

namespace SalesReportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string salesDirectory = "SalesData";
            string summaryFile = "SalesSummary.txt";
            Directory.CreateDirectory(salesDirectory);

            // Example: Create some sales files (remove/comment this in real use)
            //File.WriteAllText(Path.Combine(salesDirectory, "store1.txt"), "100.50\n200.75\n300.25");
            //File.WriteAllText(Path.Combine(salesDirectory, "store2.txt"), "150.00\n250.00");

            GenerateSalesSummary(salesDirectory, summaryFile);
            Console.WriteLine($"Sales summary written to {summaryFile}");
        }

        public static void GenerateSalesSummary(string directory, string outputFile)
        {
            var sb = new StringBuilder();
            decimal totalSales = 0;
            sb.AppendLine("Sales Summary");
            sb.AppendLine("----------------------------");

            var details = new StringBuilder();
            foreach (var file in Directory.GetFiles(directory, "*.txt"))
            {
                decimal fileTotal = 0;
                foreach (var line in File.ReadAllLines(file))
                {
                    if (decimal.TryParse(line, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal sale))
                        fileTotal += sale;
                }
                totalSales += fileTotal;
                details.AppendLine($"  {Path.GetFileName(file)}: {fileTotal:C}");
            }

            sb.AppendLine($" Total Sales: {totalSales:C}\n");
            sb.AppendLine(" Details:");
            sb.Append(details);

            File.WriteAllText(outputFile, sb.ToString());
        }
    }
}
