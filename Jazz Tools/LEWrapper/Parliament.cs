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
        //where is rename station?
        private string ParliamentURL = "/parliament";
        public void ParliamentViewLaws(string bodyID) //can this be used to view laws for non-allied SS?
        {
            int id = 701;
            string method = "view_laws";
            JsonTextWriter r = Request(id, method, bodyID);
            Post(ParliamentURL, r);
        }
        public void ParliamentViewPropositions(string buildingID)
        {
            int id = 702;
            string method = "view_propositions";
            JsonTextWriter r = Request(id, method, buildingID);
            Post(ParliamentURL, r);
        }
        public void ParliamentViewTaxesCollected(string buildingID)
        {
            int id = 703;
            string method = "view_taxes_collected";
            JsonTextWriter r = Request(id, method, buildingID);
            Post(ParliamentURL, r);
        }
        public void ParliamentGetStarsInJurisdiction(string buildingID)
        {
            int id = 704;
            string method = "get_stars_in_jurisdiction";
            JsonTextWriter r = Request(id, method, buildingID);
            Post(ParliamentURL, r);
        }
        public void ParliamentGetBodiesForStarInJurisdiction(string buildingID, string starID)
        {
            int id = 705;
            string method = "get_bodies_for_star_in_jurisdiction";
            JsonTextWriter r = Request(id, method, buildingID, starID);
            Post(ParliamentURL, r);
        }
        public void ParliamentGetMiningPlatformsForAsteroidInJurisdiction(string buildingID, string asteroidID)
        {
            int id = 706;
            string method = "get_mining_platforms_for_asteroid_in_jurisdiction";
            JsonTextWriter r = Request(id, method, buildingID, asteroidID);
            Post(ParliamentURL, r);
        }
        public void ParliamentCastVote(string buildingID, string propositionID, string vote) //vote 0 for no 1 for yes, cannot be used with sitter pass
        {
            int id = 707;
            string method = "cast_vote";
            JsonTextWriter r = Request(id, method, buildingID, propositionID, vote);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeWrit(string buildingID, string title, string description)
        {
            int id = 708;
            string method = "propose_writ";
            JsonTextWriter r = Request(id, method, buildingID, title, description);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeRepealLaw(string buildingID, string lawID)
        {
            int id = 709;
            string method = "propose_repeal_law";
            JsonTextWriter r = Request(id, method, buildingID, lawID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeTransferStationOwnership(string buildingID, string toEmpireID)
        {
            int id = 710;
            string method = "propose_transfer_station_ownership";
            JsonTextWriter r = Request(id, method, buildingID, toEmpireID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeSeizeStar(string buildingID, string starID)
        {
            int id = 711;
            string method = "propose_seize_star";
            JsonTextWriter r = Request(id, method, buildingID, starID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeRenameStar(string buildingID, string starID)
        {
            int id = 712;
            string method = "propose_rename_star";
            JsonTextWriter r = Request(id, method, buildingID, starID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeBroadcaseOnNetwork19(string buildingID, string message)
        {
            int id = 713;
            string method = "propose_broadcast_on_network19";
            JsonTextWriter r = Request(id, method, buildingID, message);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeInductMember(string buildingID, string empireID)
        {
            int id = 714;
            string method = "propose_induct_member";
            JsonTextWriter r = Request(id, method, buildingID, empireID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeInductMember(string buildingID, string empireID, string message)//test message since in api docs it's enclosed in []
        {
            int id = 714;
            string method = "propose_induct_member";
            JsonTextWriter r = Request(id, method, buildingID, empireID, message);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeExpelMember(string buildingID, string empireID) //message is in [] in api docs need to verify this implementation will work
        {
            int id = 715;
            string method = "propose_expel_member";
            JsonTextWriter r = Request(id, method, empireID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeExpelMember(string buildingID,string empireID, string message) //message is in [] in api docs need to verify this implementation will work
        {
            int id = 715;
            string method = "propose_expel_member";
            JsonTextWriter r = Request(id, method, empireID, message);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeElectNewLeader(string buildingID, string toEmpireID)
        {
            int id = 716;
            string method = "propose_elect_new_leader";
            JsonTextWriter r = Request(id, method, buildingID, toEmpireID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeRenameAsteroid(string buildingID, string asteroidID, string newName)
        {
            int id = 717;
            string method = "propose_rename_asteroid";
            JsonTextWriter r = Request(id, method, asteroidID, newName);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeRenameUninhabited(string buildingID, string planetID, string newName)
        {
            int id = 718;
            string method = "propose_rename_uninhabited";
            JsonTextWriter r = Request(id, method, buildingID, planetID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeMemberOnlyMiningRights(string buildingID)
        {
            int id = 719;
            string method = "propose_member_only_mining_rights";
            JsonTextWriter r = Request(id, method, buildingID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeEvictMiningPlatform(string buildingID, string platformID)
        {
            int id = 720;
            string method = "propose_evict_mining_platform";
            JsonTextWriter r = Request(id, method, buildingID, platformID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeTaxation(string buildingID, string taxes)//verify taxes format
        {
            int id = 721;
            string method = "propose_taxation";
            JsonTextWriter r = Request(id, method, buildingID, taxes);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeForeignAid(string buildingID, string planetID, string resources) //need to check on resources format
        {
            int id = 722;
            string method = "propose_foreign_aid";
            JsonTextWriter r = Request(id, method, planetID, resources);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeMembersOnlyColonization(string buildingID)
        {
            int id = 723;
            string method = "propose_members_only_colonization";
            JsonTextWriter r = Request(id, method, buildingID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeNeutralizeBHG(string buildingID)
        {
            int id = 724;
            string method = "propose_neutralize_bhg";
            JsonTextWriter r = Request(id, method, buildingID);
            Post(ParliamentURL, r);
        }
        public void ParliamentProposeFireBFG(string buildingID, string bodyID, string reason)
        {
            int id = 725;
            string method = "propose_fire_bfg";
            JsonTextWriter r = Request(id, method, bodyID, reason);
            Post(ParliamentURL, r);
        }
    }
}
