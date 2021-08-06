using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace ServicesNew
{
    public class AddContentToTheArticleService : IAddContentToTheArticleService
    {
        public void AddContent()
        {
            Console.WriteLine("AddContentToTheArticleService: Add content");
        }
    }
}
