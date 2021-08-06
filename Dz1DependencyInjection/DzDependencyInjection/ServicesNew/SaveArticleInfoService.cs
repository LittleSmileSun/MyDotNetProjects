using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace ServicesNew
{
    public class SaveArticleInfoService : ISaveArticleInfoService
    {
        public void SaveArticleInfo()
        {
            Console.WriteLine("SaveArticleInfoService: Save article info");
        }
    }
}
