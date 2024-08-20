using System.Globalization;

namespace BestTimeToBuyAndSellStock_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Solution solution = new Solution();
            int result = solution.MaxProfit(prices);

            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int total = 0;
            int min = prices[0];
            int max = min;
            int index = 0;
            int length = prices.Length;

            while (true)
            {
                if (index >= length) break;

                if (prices[index] >= min && prices[index] <= max)
                {
                    index++;
                    continue;
                }
                else if (prices[index] < min)
                {
                    min = prices[index];
                    if (index + 1 < length && prices[index + 1] < min)
                    {
                        index++;
                        continue;
                    }
                    max = min;
                    index++;
                    continue;
                }
                else if (prices[index] > max)
                {
                    max = prices[index];
                    if (index + 1 < length && prices[index + 1] > max)
                    {
                        index++;
                        continue;
                    }
                    total += max - min;
                    min = max;
                    index++;
                    continue;
                }
            }
            return total;
        }
    }
}
