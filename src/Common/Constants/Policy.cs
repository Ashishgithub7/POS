using POS.Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.Constants
{
    public static class Policy
    {
        public const string UserCreate = "UserCreate";
        public const string InventoryCreateOrList = "InventoryCreateOrList";
        public const string InventoryEditOrDelete = "InventoryEditOrDelete";
        public const string PurchaseEntry = "PurchaseEntry";
        public const string SalesEntry = "SalesEntry";
    }
}
