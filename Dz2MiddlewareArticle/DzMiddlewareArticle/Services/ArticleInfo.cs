using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class ArticleInfo : IArticleInfo
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public List<string> Paragraphs { get; set; }
        public bool IsGoodArticle { get; set; }
    }
}
