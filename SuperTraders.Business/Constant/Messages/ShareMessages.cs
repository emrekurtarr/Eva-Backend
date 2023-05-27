using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Constant.Messages
{
    public static class ShareMessages
    {
        public static string NotFound = "Share not found";
        public static string SymbolExactlyThreeChars = "The symbol has exactly 3 characters !";
        public static string QuantityIsRequired = "The quantity of share is required !";
        public static string DoesNotExistOnCustomerPortfolio = "The share does not exist on customer portfolio !";
        public static string NoEnoughShareToSell = "There is no enough share to sell !";
    }
}
