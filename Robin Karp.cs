using System;
using System.Collections.Generic;
using System.Text;

namespace Algotest
{
    public class RobinKarp
    {
        public int PatternSearch(string input, string sample)
        {
            double sampleHash = FindHash(sample, 0, sample.Length - 1);
            double rollingHash = FindHash(input, 0, sample.Length - 1);
            int len = sample.Length;

            if (sampleHash == rollingHash)
                return 0;


            for (int i = 1; i < input.Length; ++i)
            {
                rollingHash = FindRollingHash(input, i, i + len - 1, rollingHash);
                if (rollingHash == sampleHash)
                {
                    return i;
                }
            }
            return -1;
        }

        public double FindRollingHash(string input, int start, int end, double hash)
        {
            int length = end - start + 1;
            int prime = 101;

            hash = ((hash - input[start - 1]) / prime) + input[end] * Math.Pow(prime, length));

            return hash;

        }

        public double FindHash(string input, int start, int end)
        {
            int length = end - start + 1;
            int prime = 101;
            int pos = length - 1;
            double hash = 0;
            while (pos >= 0)
            {
                hash += input[pos] * Math.Pow(prime, pos);
                pos--;
            }

            return hash;
        }

    }
}
