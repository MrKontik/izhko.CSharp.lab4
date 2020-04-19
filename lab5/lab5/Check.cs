using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    abstract class Check
    {
        public Check CheckNext;
        abstract public void CheckNow(string row);
        public void setCheckNext(Check check)
        {
            CheckNext = check;
        }
    }
}
