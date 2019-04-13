using System;
using System.Collections.Generic;
using System.Linq;
using FluentExtensions.Enumerables;

namespace FluentExtensions.Samples
{
    public class EnumarablesSample
    {
        void ForEachSample()
        {
            new List<String> {"  First ", " Second  "}
                .Select(s => s.Trim())
                .ForEach(Console.WriteLine);
        }

        void PeekSample()
        {
            var first = new List<String> {"  First ", " Second  "}
                .Peek(Console.WriteLine)
                .Select(s => s.Trim())
                .First();
            Console.WriteLine(first);
        }
    }
}