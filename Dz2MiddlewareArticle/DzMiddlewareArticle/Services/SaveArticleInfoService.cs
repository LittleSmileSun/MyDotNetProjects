using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class SaveArticleInfoService : ISaveArticleInfoService
    {
        private IArticleInfo _articleInfo;
        public SaveArticleInfoService(IArticleInfo articleInfo)
        {
            _articleInfo = articleInfo;
        }
        public IArticleInfo GetArticleInfo()
        {
            return _articleInfo;
        }
        public void SaveMainArticleInfo(string name, string author)
        {
            Console.WriteLine("\nSaveMainArticleInfo()");
            _articleInfo.Name = name;
            _articleInfo.Author = author;
        }
        public void PrintMainArticleInfo()
        {
            Console.WriteLine($"Article name: {_articleInfo.Name}\n");
            Console.WriteLine($"Article author: {_articleInfo.Author}\n");
        }
        public void SaveArticleContent(List<string> paragraphs)
        {
            _articleInfo.Paragraphs = paragraphs;
        }
        public void PrintArticleContent()
        {
            if (_articleInfo.Paragraphs.Count > 0)
            {
                foreach (string paragraph in _articleInfo.Paragraphs)
                {
                    Console.WriteLine($"{paragraph}\n");
                }
            }
            else
            {
                Console.WriteLine("No paragraphs in article\n");
            }
        }
        public void SaveArticleChecking(bool isGoodArticle)
        {
            _articleInfo.IsGoodArticle = isGoodArticle;
        }
        public void PrintArticleChecking()
        {
            if (_articleInfo.IsGoodArticle)
            {
                Console.WriteLine($"The article was checked and it was good\n");
            } else
            {
                Console.WriteLine($"The article was checked and it was bad\n");
            }
        }

        public void PrintSavedArticleInfo()
        {
            PrintMainArticleInfo();
            PrintArticleContent();
            PrintArticleChecking();
        }

    }
}
