using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace ServicesNew
{
    public class PublicationProcessService : IPublicationProcessService
    {
        private readonly ISaveArticleInfoService _saveArticleInfoService;
        private readonly IAddContentToTheArticleService _addContentToTheArticleService;
        private readonly ICheckArticleByCriterionsService _checkArticleByCriterionsService;
        private readonly IArticlePublishingService _articlePublishingService;

        public PublicationProcessService(
            SaveArticleInfoService saveArticleInfoService,
            AddContentToTheArticleService addContentToTheArticleService,
            CheckArticleByCriterionsService checkArticleByCriterionsService,
            ArticlePublishingService articlePublishingService
            )
        {
            _saveArticleInfoService = saveArticleInfoService;
            _addContentToTheArticleService = addContentToTheArticleService;
            _checkArticleByCriterionsService = checkArticleByCriterionsService;
            _articlePublishingService = articlePublishingService;
        }

        public void StartPublishingProcess()
        {
            Console.WriteLine("Start publishing process...");
        }
        public void PublicationProcess(string content)
        {
            // - сервіс, який зберігає інформацію про статтю, яку потрібно опублікувати
            /* SaveArticleInfoService saveArticleInfo = new SaveArticleInfoService();
             saveArticleInfo.SaveArticleInfo();*/
            _saveArticleInfoService.SaveArticleInfo();
            // ---
            // - дод. логіка
            // --

            // - сервіс, який вносить контент в статтю (наприклад з якогось файлу на диску)
            /* AddContentToTheArticleService addContent = new AddContentToTheArticleService();
            addContent.AddContent();*/
            _addContentToTheArticleService.AddContent();
            // ---
            // - дод. логіка
            // --

            // - сервіс, який виконує перевірку статті по якимось критеріям
            /*CheckArticleByCriterionsService checkArticleByCriterionsService = new CheckArticleByCriterionsService();
            checkArticleByCriterionsService.CheckByCriterions();*/
            _checkArticleByCriterionsService.CheckByCriterions();
            // ---
            // - дод. логіка
            // --

            // - сервіс, який опубліковує статтю
            /*ArticlePublishingService articlePublishingService = new ArticlePublishingService();
            articlePublishingService.Publish();*/
            _articlePublishingService.Publish();

            // ---
            // - дод. логіка
            // --

            Console.WriteLine("PublicationProcessService: Publication process");
        }
        public void EndPublishingProcess()
        {
            Console.WriteLine("End publishing process...");
        }
    }
}
