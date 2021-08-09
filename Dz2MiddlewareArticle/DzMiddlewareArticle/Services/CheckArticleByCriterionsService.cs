using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class CheckArticleByCriterionsService : ICheckArticleByCriterionsService
    {
        private readonly ISaveArticleInfoService _saveArticleInfoService;
        public string criterion { get; set; }

        public CheckArticleByCriterionsService(ISaveArticleInfoService saveArticleInfoService)
        {
            _saveArticleInfoService = saveArticleInfoService;
        }
        public bool Check()
        {
            // There are will be checking by criterion
            if (criterion == "minlength")
            {
                return _saveArticleInfoService.GetArticleInfo().Name.Length > 3;
            }
            else if (criterion == "isparagraphs")
            {
                return _saveArticleInfoService.GetArticleInfo().Paragraphs.Count > 0;
            }
            else
            {
                // Standart checking does not include passed criterion, article is good, return true
                return true;
            }
        }
        public void CheckByCriterions()
        {
            Console.WriteLine("\nCheckByCriterions()");
            bool isGoodArticle = Check();
             _saveArticleInfoService.SaveArticleChecking(isGoodArticle);
        }
    }
}
