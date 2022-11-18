﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;


namespace C8KJ98_ADT_2022_23_1.Repository
{
    public interface IArtistsRepository:IRepository<Artists>
    {
        void UpdatePrice(int id, int newprice);
        void UpdateDuration(int id, int newduration);
    }
}
