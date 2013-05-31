using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace LE_Wrapper
{
    partial class LEWrapper
    {
        private string CaptchaURL = "/captcha";
        public void CaptchaFetch()
        {
            int id = 201;
            string method = "fetch";
            JsonTextWriter r = Request(id, method, sessionID);
            Post(CaptchaURL, r);
        }
        public void CaptchaSolve(string captcha_guid, string captcha_solution)
        {
            int id = 202;
            string method = "solve";
            JsonTextWriter r = Request(id, method, sessionID, captcha_guid, captcha_solution);
            Post(CaptchaURL, r);
        } //captcha_guid is sent with the reply from the captcha fetch method

    }
}
