using SimpleHashTable;
using Xunit;

public class GetBucketIndexTests
{
    private sealed class MinHashKey
    {
        private readonly int _id;
        public MinHashKey(int id) => _id = id;
        public override int GetHashCode() => int.MinValue;
        public override bool Equals(object? obj) => obj is MinHashKey other && other._id == _id;
    }

    [Fact]
    public void Add_KeyWithMinHashCode_DoesNotThrow()
    {
        var table = new SimpleHashTable<MinHashKey, string>();
        var key = new MinHashKey(1);

        table.Add(key, "value");

        Assert.True(table.TryGetValue(key, out var value));
        Assert.Equal("value", value);
    }
}
