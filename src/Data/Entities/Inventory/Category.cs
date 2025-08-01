﻿using POS.Data.Entities.Common;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Entities.Inventory
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public AppUser CreatedByUser { get; set; }
        public AppUser UpdatedByUser { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
