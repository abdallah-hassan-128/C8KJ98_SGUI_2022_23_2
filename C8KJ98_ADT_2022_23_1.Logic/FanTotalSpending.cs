﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public class FanTotalSpending
    {
        public int FanID { get; set; }
        public string FanName { get; set; }
        public int TotalSpending { get; set; }
        public override string ToString()
        {
            return "Fan's name : " + FanName + ", ID : " + FanID + ", TotalSpending : " + TotalSpending;
        }
    }
}
