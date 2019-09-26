using System;
using GildedRoseAssignment;
namespace GildedRoseApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Gilded Rose Daily Stock Update, (Version 1.0)");

                if (args.Length > 0)
                {
                    if (args.Length == 2)
                    {
                        DataAccessFactory.InputFileName = args[0];
                        DataAccessFactory.OutputFileName = args[1];
                    }
                    else if (args.Length == 1)
                    {
                        DataAccessFactory.InputFileName = args[0];
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command Line Usage: GuildedRoseApplication <inputpath> <outpath> ");
                    }
                }

                Console.WriteLine("\nPreparing to Process:");
                Console.WriteLine("\nInput Data:");

                using (var reader = new System.IO.StreamReader(DataAccessFactory.InputFileName))
                {
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
                Console.WriteLine("\nProcessing:");

                var updater = new DailyStockUpdater();
                updater.Execute();

                Console.WriteLine("\nRead " + updater.ReadCount);
                Console.WriteLine("Processed " + updater.WriteCount);

                Console.WriteLine("\nOutput: ");
                using (var reader = new System.IO.StreamReader(DataAccessFactory.OutputFileName))
                {
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }

                Console.WriteLine("\n\nDone!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
