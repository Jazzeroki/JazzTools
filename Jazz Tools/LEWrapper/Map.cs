using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using LE_Wrapper;

namespace LE_Wrapper
{
    partial class LEWrapper
    {
        string MapURL = "/map";
        public void MapGetStarMap(string x1, string y1, string x2, string y2)
        {
            int id = 301;
            string method = "get_star_map";
            JsonTextWriter r = Request(id, method, x1, y1, x2, y2);
            Post(MapURL, r);
        }
        public void MapCheckStarForIncommingProbe(string starID)
        {
            int id = 302;
            string method = "check_star_for_incomming_probe";
            JsonTextWriter r = Request(id, method, starID);
            Post(MapURL, r);
        }
        public void MapGetStarByName(string starName)
        {
            int id = 303;
            string method = "get_star_by_name";
            JsonTextWriter r = Request(id, method, starName);
            Post(MapURL, r);
        }
        public void MapyGetStarByXY(string x, string y)
        {
            int id = 304;
            string method = "get_star_by_name";
            JsonTextWriter r = Request(id, method, x, y);
            Post(MapURL, r);
        }
        public void MapSearchStars(string starName)
        {
            int id = 305;
            string method = "search_stars";
            JsonTextWriter r = Request(id, method, starName);
            Post(MapURL, r);        
        }
        public void MapProbeSummaryFissures()//This method returns a list of all fissures within your probe network within the specified zone
        {
            int id = 306;
            string method = "probe_summary_fissures";
            JsonTextWriter r = Request(id, method);
            Post(MapURL, r); 
        }
        public void MapProbeSummaryFissures(string zone)//zone must be a format like"-1|0" or "0|0"
        {
            int id = 306;
            string method = "probe_summary_fissures";
            JsonTextWriter r = Request(id, method, zone);
            Post(MapURL, r);
        }

    }
}
