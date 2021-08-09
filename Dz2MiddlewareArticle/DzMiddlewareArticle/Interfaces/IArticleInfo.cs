using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IArticleInfo
    {
        string Name { get; set; }
        string Author { get; set; }
        List<string> Paragraphs { get; set; }
        bool IsGoodArticle { get; set; }
    }
}
