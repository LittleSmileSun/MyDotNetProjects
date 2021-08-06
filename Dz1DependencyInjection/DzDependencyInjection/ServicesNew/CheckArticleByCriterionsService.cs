using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace ServicesNew
{
    public class CheckArticleByCriterionsService : ICheckArticleByCriterionsService
    {
        public void CheckByCriterions()
        {
            Console.WriteLine("CheckArticleByCriterionsService: Check by criterions");
        }
    }
}
