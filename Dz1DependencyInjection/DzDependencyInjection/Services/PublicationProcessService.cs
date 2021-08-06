using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Services;

namespace Services
{
    public class PublicationProcessService : IPublicationProcessService
    {
        private readonly ISaveArticleInfoService _saveArticleInfoService;
        private readonly IAddContentToTheArticleService _addContentToTheArticleService;
        private readonly ICheckArticleByCriterionsService _checkArticleByCriterionsService;
        private readonly IArticlePublishingService _articlePublishingService;

        private readonly ICounter _counter;

        public PublicationProcessService(
            ISaveArticleInfoService saveArticleInfoService,
            IAddContentToTheArticleService addContentToTheArticleService,
            ICheckArticleByCriterionsService checkArticleByCriterionsService,
            IArticlePublishingService articlePublishingService,
            ICounter counter
        )
        {
            _saveArticleInfoService = saveArticleInfoService;
            _addContentToTheArticleService = addContentToTheArticleService;
            _checkArticleByCriterionsService = checkArticleByCriterionsService;
            _articlePublishingService = articlePublishingService;
            _counter = counter;
    }

        public void StartPublishingProcess()
        {
            Console.WriteLine("------------------------------------");
            _counter.IncrementValue();
            Console.WriteLine("Start publishing process...");
        }
        public void PublicationProcess(string content)
        {
            // - сервіс, який зберігає інформацію про статтю, яку потрібно опублікувати
            _saveArticleInfoService.SaveArticleInfo();

            // - сервіс, який вносить контент в статтю (наприклад з якогось файлу на диску)
            _addContentToTheArticleService.AddContent();

            // - сервіс, який виконує перевірку статті по якимось критеріям
            _checkArticleByCriterionsService.CheckByCriterions();
        
            // - сервіс, який опубліковує статтю
            _articlePublishingService.Publish();
        }
        public void EndPublishingProcess()
        {
            Console.WriteLine("End publishing process...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }
    }
}
