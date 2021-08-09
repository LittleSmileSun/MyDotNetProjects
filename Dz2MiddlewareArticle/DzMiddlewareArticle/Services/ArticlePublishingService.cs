using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class ArticlePublishingService : IArticlePublishingService
    {
        private readonly ISaveArticleInfoService _saveArticleInfoService;
        private readonly DateTime _dateTime = DateTime.Now;
        public ArticlePublishingService(ISaveArticleInfoService saveArticleInfoService)
        {
            _saveArticleInfoService = saveArticleInfoService;
        }
        public void Publish()
        {
            Console.WriteLine("\nPublish()\n");
            Console.WriteLine($"This article was published in {_dateTime}\n");
            _saveArticleInfoService.PrintSavedArticleInfo();
        }
    }
}
