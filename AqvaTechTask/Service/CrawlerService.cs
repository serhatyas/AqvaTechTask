using AqvaTechTask.Models;
using HtmlAgilityPack;
using System.Net;

namespace AqvaTechTask.Service
{
    public class CrawlerService
    {

        public async Task<List<News>> CrawlNewsAsync()
        {
            var url = "https://www.sozcu.com.tr";
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var newsList = new List<News>();
            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'swiper-slide')]");

            foreach (var node in nodes)
            {
                var linkNode = node?.SelectSingleNode(".//a[contains(@class, 'img-holder')]");
                var imgNode = linkNode?.SelectSingleNode(".//img");
                var titleNode = imgNode?.GetAttributeValue("alt", string.Empty);

                if (linkNode == null || imgNode == null || string.IsNullOrWhiteSpace(titleNode))
                {
                    continue;
                }

                var news = new News
                {
                    Title = WebUtility.HtmlDecode(titleNode.Trim()),
                    Link = "https://www.sozcu.com.tr" + linkNode.GetAttributeValue("href", string.Empty).Trim(),
                    ImageUrl = imgNode.GetAttributeValue("src", string.Empty).Trim()
                };

                newsList.Add(news);
            }

            return newsList;
        }

    }
}
