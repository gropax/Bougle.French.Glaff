using Bougle.French.Glaff.Contracts;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bougle.French.Glaff.Client
{
    public abstract class ClientBase
    {
        protected string _host;
        protected HttpClient _client = new HttpClient();
        protected JsonSerializerOptions _jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }

    public class EntryClient : ClientBase
    {
        public EntryClient(string host)
        {
            _host = host;
        }

        public async Task<GlaffEntryDto> Find(int entryId)
        {
            string url = $"{_host}/api/v1/entries/{entryId}";
            var response = await _client.GetAsync(url);

            string json = response.Content.ReadAsStringAsync().Result;
            var entry = JsonSerializer.Deserialize<GlaffEntryDto>(json, _jsonOptions);

            return entry;
        }
    }
}
