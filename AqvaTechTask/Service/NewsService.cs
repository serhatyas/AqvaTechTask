using AqvaTechTask.Models;
using Nest;

namespace AqvaTechTask.Service
{
    public class NewsService
    {
        private readonly ElasticClient _client;

        public NewsService()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("news");
            _client = new ElasticClient(settings);
        }

        //public async Task<List<News>> GetNewsAsync(string query = "")
        //{
        //    var searchResponse = await _client.SearchAsync<News>(s => s
        //        .Query(q => q
        //            .QueryString(qs => qs
        //                .Query(query)
        //            )
        //        )
        //    );

        //    return searchResponse.Documents.ToList();
        //}

        public async Task StoreNewsAsync(List<News> newsList)
        {
            foreach (var news in newsList)
            {
                await _client.IndexDocumentAsync(news);
            }
        }
    }

}
