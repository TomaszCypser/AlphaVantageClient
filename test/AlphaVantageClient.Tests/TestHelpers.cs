using System;
using System.Linq;

namespace AlphaVantageClient;

public static class TestHelpers
{
    public static bool ContainsAll(this string source, params string[] values)
    {
        return values.All(x => source.Contains(x, StringComparison.InvariantCultureIgnoreCase));
    }
}