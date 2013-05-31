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
        private string stationCommandURL = "/stationcommand";
        public void StationCommandView(int buildingID)
        {
            int id = 661;
            string method = "view";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(stationCommandURL, r);
        }
        public void StationCommandViewPlans(int buildingID)
        {
            int id = 662;
            string method = "view_plans";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(stationCommandURL, r);
        }
        public void StationCommandViewIncomingSupplyChains(int buildingID)
        {
            int id = 663;
            string method = "view_incoming_supply_chains";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(stationCommandURL, r);
        }
    }
}
