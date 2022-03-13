using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain
{
    public class LogicException : Exception
    {
        public LogicException(string message) : base(message)
        {

        }
    }
}
