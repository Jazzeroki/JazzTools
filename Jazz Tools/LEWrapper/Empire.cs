using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jayrock.Json;
using Jayrock.Json.Conversion;
//using LEWrapperResponse;
//using LE_Wrapper;

namespace LE_Wrapper
{
    partial class LEWrapper
    {
        private string Empire_url = "/empire";
        public void EmpireLogin()
        {
            int id = 101;
            string method = "login";
            JsonTextWriter r = Request(id, method, empire, password, API_KEY);
            var d = PostAsync(Empire_url, r);
        }
        public void EmpireLogout() 
        {
            int id = 102;
            string method = "logout";
            JsonTextWriter r = Request(id, method, sessionID);
            Post(Empire_url, r);
        }
        public void EmpireFetchCaptcha()
        { } //not implemented yet see captcha

    }
}
