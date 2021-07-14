using System;
using Xunit;

namespace Bougle.French.Glaff.Client.Tests
{
    public class EntryClientTests
    {
        private EntryClient _client = new EntryClient("https://localhost:50817");

        [Fact]
        public async void TestFind()
        {
            var entry = await _client.Find(1234556);
        }
    }
}
