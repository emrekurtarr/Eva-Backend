using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Constant.Messages
{
    public static class PortfolioMessage
    {
        public static string PortfolioDoesNotExist = "Portfolio does not exist !";
        public static string DoesNotHaveEnoughBalance = "Your portfolio has not enough balance to trade !";
        public static string SomethingWentWrong = "Something went wrong about portfolio";
        public static string Updated = "Portfolio updated";
    }
}
