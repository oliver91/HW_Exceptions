using System;

namespace Exceptions_Task2
{
  class Program
    {
        static void Main()
        {
            Price[] prices = new Price[2];

            FillingTheData(prices);

            Console.WriteLine("Prices:");
            foreach (Price w in prices)
                Console.WriteLine(w.ToString());

            try
            {
                PrintStoreProducts(prices);
            }
            catch (StoreNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static Price[] FillingTheData(Price[] prices)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Add product");
                Console.Write("product name: ");
                prices[i].productName = Console.ReadLine();
                Console.Write("\nstore name: ");
                prices[i].storeName = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nprice (UAH):");
                        prices[i].priceUAH = UInt32.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("\n");
            }
            Array.Sort<Price>(prices, (p1, p2) => p1.storeName.CompareTo(p2.storeName));
            return prices;
        }

        public static void PrintStoreProducts(Price[] prices)
        {
            Console.Write("\nChoose store:");
            string store = Console.ReadLine();
            int count = 0;
            foreach (Price p in prices)
            {
                if (p.storeName.Equals(store))
                {
                    Console.WriteLine(p.ToString());
                    count++;
                }
            }
            if (count == 0) throw new StoreNotFoundException();
        }
    }

    public struct Price
    {
        public string productName;
        public string storeName;
        public uint priceUAH;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", productName, storeName, priceUAH);
        }
    }
}
