using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class AddContentToTheArticleService : IAddContentToTheArticleService
    {
        private readonly DateTime _dateTime = DateTime.Now;
        public void AddContent()
        {
            Console.WriteLine();
            Console.WriteLine("Add content to the article");
            Console.WriteLine(_dateTime);
            Console.WriteLine();
        }
    }
}
