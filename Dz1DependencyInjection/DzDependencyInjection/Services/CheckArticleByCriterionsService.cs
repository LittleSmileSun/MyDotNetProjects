using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class CheckArticleByCriterionsService : ICheckArticleByCriterionsService
    {
        private readonly DateTime _dateTime = DateTime.Now;
        public void CheckByCriterions()
        {
            Console.WriteLine();
            Console.WriteLine("Check article by criterions");
            Console.WriteLine(_dateTime);
            Console.WriteLine();
        }
    }
}
