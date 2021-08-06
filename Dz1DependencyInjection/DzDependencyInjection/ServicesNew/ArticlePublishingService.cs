using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace ServicesNew
{
    public class ArticlePublishingService : IArticlePublishingService
    {
        public void Publish()
        {
            Console.WriteLine("ArticlePublishingService: Publish");
        }
    }
}
