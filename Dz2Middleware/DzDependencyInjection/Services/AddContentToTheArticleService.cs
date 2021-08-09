using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class AddContentToTheArticleService : IAddContentToTheArticleService
    {
        private readonly ISaveArticleInfoService _saveArticleInfoService;
        public List<string> Paragraphs { get; set; }
        public AddContentToTheArticleService(ISaveArticleInfoService saveArticleInfoService)
        {
            _saveArticleInfoService = saveArticleInfoService;
        }
        public void DownloadInfo()
        {
            Paragraphs = new List<string>();
            // this method will be for download paragraphs of article
            Paragraphs.Add("paragraph 1");
            Paragraphs.Add("paragraph 2");
            Paragraphs.Add("paragraph 3");
        }
        public void SetDownloadedInfo()
        {
            _saveArticleInfoService.SaveArticleContent(Paragraphs);
        }
        
        public void AddContent()
        {
            Console.WriteLine("\nAddContent()");
            DownloadInfo();
            SetDownloadedInfo();
        }
    }
}
