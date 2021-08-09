using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Services
{
    public class Counter : ICounter
    {
        private int value = 0;
        public int GetValue()
        {
            return value;
        }

        public void IncrementValue()
        {
            value++;
        }
    }
}
