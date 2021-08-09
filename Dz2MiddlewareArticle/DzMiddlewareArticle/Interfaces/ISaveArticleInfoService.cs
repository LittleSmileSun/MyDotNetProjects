using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ISaveArticleInfoService
    {
        IArticleInfo GetArticleInfo();
        void SaveMainArticleInfo(string name, string author);
        void PrintMainArticleInfo();
        void SaveArticleContent(List<string> paragraphs);
        void PrintArticleContent();
        void SaveArticleChecking(bool isGoodArticle);
        void PrintArticleChecking();
        void PrintSavedArticleInfo();
    }
}
