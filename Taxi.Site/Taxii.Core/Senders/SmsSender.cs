using Kavenegar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.Senders
{
    public static class SmsSender
    {
        public static void VerifySend(string to,string template, string token)
        {
            var api = new KavenegarApi("356D7A6652545148543161584E624B47486E794F542B41786B4C4C764577374D5349365374494B727A68553D");
            var strTo = to;
            var strTemplate = template;
            var strToken = token;

            api.VerifyLookup(strTo, strToken, strTemplate);
        }
    }
}
