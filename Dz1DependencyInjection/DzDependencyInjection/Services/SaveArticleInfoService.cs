using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class SaveArticleInfoService : ISaveArticleInfoService
    {
        private readonly DateTime _dateTime = DateTime.Now;
        private readonly ICounter _counter;
        public SaveArticleInfoService(ICounter counter)
        {
            _counter = counter;
        }
        public void SaveArticleInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Save article info");
            Console.WriteLine(_dateTime);
            Console.WriteLine();
        }
    }
}
