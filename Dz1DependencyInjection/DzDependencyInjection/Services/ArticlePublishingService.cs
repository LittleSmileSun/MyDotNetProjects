using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class ArticlePublishingService : IArticlePublishingService
    {
        private readonly DateTime _dateTime = DateTime.Now;
        public void Publish()
        {
            Console.WriteLine();
            Console.WriteLine("Article publishing");
            Console.WriteLine(_dateTime);
            Console.WriteLine();
        }
    }
}
