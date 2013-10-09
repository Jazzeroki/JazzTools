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
        private string bodyURL = "/body";
        public void BodyGetStatus(string bodyID)
        {
            int id = 401;
            string method = "get_status";
            JsonTextWriter r = Request(id, method, sessionID.ToString(), bodyID);
            Post(bodyURL, r);
        }
        public void BodyGetBuildings(string bodyID)
        {
            int id = 402;
            string method = "get_buildings";
            JsonTextWriter r = Request(id, method, sessionID.ToString(), bodyID);
            var d = PostAsync(bodyURL, r);
        }
        public void BodyRearrangeBuildings(string bodyID, string[] arrangement) //need to test to ensure that it works.  
        {
            int id = 403;
            string method = "rearrange_buildings";
            JsonTextWriter r = Request(id, method, sessionID.ToString(), bodyID);
            r.WriteStartArray();
            for (int i = 0; i < arrangement.Length; i += 3)
                AddHashedParameters(r, "id", arrangement[i],"x", arrangement[i + 1],"y", arrangement[i + 2]);
            var d = PostAsync(bodyURL, r);
        }
        public void BodyGetBuildable(string bodyID, string x, string y, string tag)
        {
            int id = 404;
            string method = "get_buildable";
            JsonTextWriter r = Request(id, method, sessionID.ToString(), bodyID, x, y, tag);
            Post(bodyURL, r);
            /* Acceptable Tags
             * Now  //Cannot be required tag
             * Soon //Cannot be required tag
             * Later //Cannot be required tag
             * Infrastructure
             * Intelligence
             * Happiness
             * Ships
             * Colonization
             * Construction
             * Trade
             * Resources
             * Food
             * Ore
             * Water
             * Energy
             * Waste
             * Storage
             */
        }
        public void BodyRename(string bodyID, string NewName)
        {
            int id = 405;
            string method = "rename";
            JsonTextWriter r = Request(id, method, sessionID.ToString(), bodyID, NewName);
            Post(bodyURL, r);
        }
        public void BodyAbandon(string bodyID)
        {
            int id = 406;
            string method = "abandon";
            JsonTextWriter r = Request(id, method, sessionID.ToString(), bodyID);
            Post(bodyURL, r);
        }


    }
}
