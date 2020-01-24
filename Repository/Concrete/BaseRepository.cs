﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    class BaseRepository
    {
        protected AppDbContext context;

        public BaseRepository()
        {
            context = AppDbContext.Create();
        }
    }
}
