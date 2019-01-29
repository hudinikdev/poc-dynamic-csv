using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace PocDynamicCsv
{
    class Program
    {
        static void Main(string[] args)
        {            
            var headers = new List<string> { "Id", "Description", "Attribute1", "Attribute2", "Attribute3" };

            var rows = new List<Dictionary<string, string>>();

            var row1 = new Dictionary<string, string>
            {
                { "Id", "1" },
                { "Description", "Product 1" },
                { "Attribute1", "Value Attr 1" },
                { "Attribute3", "Value Attr 3" }
            };

            var row2 = new Dictionary<string, string>
            {
                { "Id", "2" },
                { "Description", "Product 2" },
                { "Attribute2", "Value Attr 2" },
                { "Attribute3", "Value Attr 3" }
            };

            var row3 = new Dictionary<string, string>
            {
                { "Id", "3" },
                { "Description", "Product 3" },
                { "Attribute1", "Value Attr 1" },               
            };

            rows.Add(row1);
            rows.Add(row2);
            rows.Add(row3);

            using (var textWriter = File.CreateText(@"C:\test.csv"))
            using (var csv = new CsvWriter(textWriter))
            {
                // Write columns
                foreach (string header in headers)
                {
                    csv.WriteField(header);
                }

                csv.NextRecord();

                // Write row values
                foreach (Dictionary<string, string> row in rows)
                {                    
                    foreach (var header in headers)
                    {                        
                        if (row.ContainsKey(header))
                            csv.WriteField(row[header]);
                        else
                            csv.WriteField(string.Empty);
                    }

                    csv.NextRecord();
                }
            }
        }
    }
}
