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
        public enum moduleURL
        {
            ArtMuseum,
            CulinaryInstitute,
            IBS,
            OperaHouse,
            Parliament,
            PoliceStation,
            StationCommand,
            Warehouse
        };
        //build, repair, upgrade, downgrade, demolish
        public void moduleBuild(moduleURL url, int bodyID, int x, int y)
        {
            string bURL = "/" + url.ToString();
            int id = 621;
            string method = "build";
            JsonTextWriter r = Request(id, method, bodyID.ToString(), x.ToString(), y.ToString());
            Post(bURL, r);
        }
        public void moduleRepair(moduleURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 622;
            string method = "repair";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void moduleDowngrade(moduleURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 623;
            string method = "downgrade";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void moduleDemolish(moduleURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 624;
            string method = "demolish";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void moduleUpgrade(moduleURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 625;
            string method = "upgrade";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
	}
}
