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
        public enum buildingURL
        {
            Algae,
            AlgaePond,
            AmalgusMeadow,
            Apple,
            Archaeology,
            AtmosphericEvaporator,
            Beach,
            Bean,
            Beeldeban,
            BeeldebanNest,
            BlackHoleGenerator,
            Bread,
            Burger,
            Capitol,
            Cheese,
            Chip,
            Cider,
            CitadelOfKnope,
            CloakingLab,
            Corn,
            CornMeal,
            CrashedShipSite,
            Crater,
            Dairy,
            Denton,
            DentonBrambles,
            DeployedBleeder,
            Development,
            DistributionCenter,
            Embassy,
            EnergyReserve,
            Entertainment,
            Espionage,
            EssentiaVein,
            Fission,
            Fissure,
            FoodReserve,
            Fusion,
            GasGiantLab,
            GasGiantPlatform,
            GeneticsLab,
            Geo,
            GeoThermalVent,
            GratchsGauntlet,
            GreatBallOfJunk,
            Grove,
            HallsOfVrbansk,
            Hydrocarbon,
            Intelligence,
            IntelTraining,
            InterDimensionalRift,
            JunkHengeSculpture,
            KalavianRuins,
            KasternsKeep,
            Lake,
            Lagoon,
            Lapis,
            LapisForest,
            LibraryOfJith,
            LostCityOfTyleon,
            LuxuryHousing,
            Malcud,
            MalcudField,
            MassadsHenge,
            MayhemTraining,
            MercenariesGuild,
            MetalJunkArches,
            Mine,
            MiningMinistry,
            MissionCommand,
            MunitionsLab,
            NaturalSpring,
            Network19,
            Observatory,
            OracleOfAnid,
            OreRefinery,
            OreStorage,
            Oversight,
            Pancake,
            PantheonOfHagness,
            Park,
            Pie,
            PilotTraining,
            PlanetaryCommand,
            PoliticsTraining,
            Potato,
            Propulsion,
            PyramidJunkSculpture,
            Ravine,
            RockyOutcrop,
            Sand,
            SAW,
            Security,
            Shake,
            Shipyard,
            Singularity,
            Soup,
            SpaceJunkPark,
            SpacePort,
            SpaceStationLab,
            Stockpile,
            SubspaceSupplyDepot,
            SupplyPod,
            Syrup,
            TempleOfTheDrajilites,
            TerraformingLab,
            TerraformingPlatform,
            TheDillonForge,
            TheftTraining,
            ThemePark,
            Trade,
            Transporter,
            University,
            Volcano,
            WasteDigester,
            WasteEnergy,
            WasteExchanger,
            WasteRecycling,
            WasteSequestration,
            WasteTreatment,
            WaterProduction,
            WaterPurification,
            WaterReclamation,
            WaterStorage,
            Wheat
        };
        public void BuildingBuild( buildingURL url, int bodyID, int x, int y)
        {
            string bURL = "/"+url.ToString();
            int id = 601;
            string method = "build";
            JsonTextWriter r = Request(id, method, bodyID.ToString(), x.ToString(), y.ToString());
            Post(bURL, r);
        }
        public void BuildingView(buildingURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 602;
            string method = "view";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void BuildingUpgrade(buildingURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 603;
            string method = "upgrade";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void BuildingDemolish(buildingURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 604;
            string method = "demolish";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void BuildingDowngrade(buildingURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 605;
            string method = "downgrade";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }
        public void BuildingGetStatsForLevel(buildingURL url, int buildingID, int level)
        {
            string bURL = "/" + url.ToString();
            int id = 606;
            string method = "get_stats_for_level";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), level.ToString());
            Post(bURL, r);
        }
        public void BuildingRepair(buildingURL url, int buildingID)
        {
            string bURL = "/" + url.ToString();
            int id = 603;
            string method = "repair";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(bURL, r);
        }

    }
}
