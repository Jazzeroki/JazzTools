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
        private string PoliceStationURL = "/policestation";
        public void PoliceStationViewPrisoners(int buildingID, int pageNumber)
        {
            int id = 641;
            string method = "view_prisoners";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), pageNumber.ToString());
            Post(PoliceStationURL, r);
        }
        public void PoliceStationExecutePrisoner(int buildingID, int prisonerID)
        {
            int id = 642;
            string method = "execute_prisoner";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), prisonerID.ToString());
            Post(PoliceStationURL, r);
        }
        public void PoliceStationReleasePrisoner(int buildingID, int prisonerID)
        {
            int id = 643;
            string method = "release_prisoner";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), prisonerID.ToString());
            Post(PoliceStationURL, r);
        }
        public void PoliceStationViewForeignSpies(int buildingID, int pageNumber)
        {
            int id = 644;
            string method = "view_foreign_spies";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), pageNumber.ToString());
            Post(PoliceStationURL, r);
        }
        public void PoliceStationViewForeignShips(int buildingID, int pageNumber)
        {
            int id = 645;
            string method = "view_foreign_ships";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), pageNumber.ToString());
            Post(PoliceStationURL, r);
        }
        public void PoliceStationViewShipsTravelling(int buildingID, int pageNumber)
        {
            int id = 646;
            string method = "view_ships_travelling";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), pageNumber.ToString());
            Post(PoliceStationURL, r);
        }
        public void PoliceStationViewShipsOrbiting(int buildingID, int pageNumber)
        {
            int id = 647;
            string method = "view_ships_orbiting";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), pageNumber.ToString());
            Post(PoliceStationURL, r);
        }
    }
}
