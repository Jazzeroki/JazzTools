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
        private string intelligenceURL = "/intelligence";
        public void IntelligenceView(int buildingID)
        {
            int id = 0;
            string method = "view";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(intelligenceURL, r);
        }
        public void IntelligenceTrainSpy(int buildingID, int quantity)
        {
            int id = 0;
            string method = "train_spy";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), quantity.ToString());
            Post(intelligenceURL, r);
        }
        public void IntelligenceViewAllSpies(int buildingID)
        {
            int id = 0;
            string method = "view_all_spies";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(intelligenceURL, r);
        }
        public void IntelligenceSubsidizeTraining(int buildingID)
        {
            int id = 0;
            string method = "subsidize_training";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(intelligenceURL, r);
        }
        public void IntelligenceBurnSpy(int buildingID, int spyID)
        {
            int id = 0;
            string method = "burn_spy";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), spyID.ToString());
            Post(intelligenceURL, r);
        }
        public void IntelligenceNameSpy(int buildingID, int spyID, string name)
        {
            int id = 0;
            string method = "name_spy";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), spyID.ToString(), name);
            Post(intelligenceURL, r);
        }
        public void IntelligenceAssignSpy(int buildingID, int spyID, spyAssignments assignment)
        {
            int id = 0;
            string method = "assign_spy";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), spyID.ToString(), assignment.ToString());
            Post(intelligenceURL, r);
        }
        public enum spyAssignments
        {
            Idle, //Don't do anything.
            Counter_Espionage, //Passively defend against all attackers.
            Security_Sweep, //Round up all attackers.
            Gather_Resource_Intelligence, //Find out what's up for trade, what ships are available, what ships are being built, where ships are travelling to, etc.
            Gather_Empire_Intelligence, //Find out what is built on this planet, the resources of the planet, what other colonies this Empire has, etc.
            Gather_Operative_Intelligence, //Find out what spies are on this planet, where they are from, what they are doing, etc.
            Hack_Network_19, //Attempts to besmirch the good name of the empire controlling this planet, and deprive them of a small amount of happiness.
            Sabotage_Probes, //Destroy probes controlled by this empire.
            Rescue_Comrades, //Break spies out of prison.
            Sabotage_Resources, //Destroy ships being built, docked, en route to mining platforms, etc.
            Appropriate_Resources, //Steal empty ships, ships full of resources, ships full of trade goods, etc.
            Assassinate_Operatives, //Kill spies.
            Sabotage_Infrastructure, //Destroy buildings.
            Incite_Mutiny, //Turn spies. If successful they come work for you.
            Abduct_Operatives, //Kidnap a spy and bring him back home.
            Appropriate_Technology, //Steal plans for buildings that this empire has built, or has in inventory.
            Incite_Rebellion, //Obliterate the happiness of a planet. If done long enough, it can shut down a planet.
            Incite_Insurrection //Steal a planet.
        };
    }
}
