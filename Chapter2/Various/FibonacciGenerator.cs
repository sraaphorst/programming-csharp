using System.Collections;
using System.Numerics;

namespace Various
{
    /// <summary>
    /// Generates an infinite sequence of Fibonacci numbers.
    /// </summary>
    public class FibonacciGenerator : IEnumerable<BigInteger>
    {
        public IEnumerator<BigInteger> GetEnumerator()
        {
            yield return BigInteger.Zero;
            yield return BigInteger.One;

            var previous = BigInteger.Zero;
            var current = BigInteger.One;

            while (true)
            {
                var next = previous + current;
                yield return next;
                previous = current;
                current = next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}