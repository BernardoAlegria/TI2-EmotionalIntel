using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EmotionalDB context)
        {
            context.Database.EnsureCreated();
            return ;
        }

    }
}