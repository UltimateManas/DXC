using System.Collections.Generic;

namespace DXC_Fibonacci.Services
{
    public interface IFibonacciService
    {
        /// <summary>
        /// Get Nth fibonacci series
        /// </summary>
        /// <param name="len"></param>
        /// <returns>Collection of numbers</returns>
        IEnumerable<long> GetNthFibonacciSeries(int len);
    }

    public class FibonacciService : IFibonacciService
    {
        public IEnumerable<long> GetNthFibonacciSeries(int len)
        {
            if (len <= 0)
            {
                yield break;
            }

            long a = 0, b = 1, c = 0;

            yield return a;
            yield return b;

            for (int i = 2; i < len; i++)
            {
                c = a + b;
                a = b;
                b = c;
                yield return c;
            }
        }
    }
}
