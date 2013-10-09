using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzToolUtilities
{
    //utilies for use with Jazz Tools
     public class JazzToolUtilities
    {
         public Dictionary<string, string> buildingTypes;
         JazzToolUtilities()
         {
             Dictionary<string, string> buildingTypes
             {
                "Algae", "resource";
                "AlgaePond", "glyph";
                "AmalgusMeadow", "glyph";
                "Apple", "resource";
                "Archaeology", "secondary";
                "AtmosphericEvaporator", "resource";
                "Beach", "glyph";
                "Bean", "resource";
                "Beeldeban", "resource";
                "BeeldebanNest", "glyph";
                "BlackHoleGenerator", "glyph";
                "Bread", "resource";
                "Burger", "resource";
                "Capitol", "secondary";
                "Cheese", "resource";
                "Chip", "resource";
                "Cider", "resource";
                "CitadelOfKnope", "glyph";
                "CloakingLab", "combat";
                "Corn", "resource";
                "CornMeal", "resource";
                "CrashedShipSite", "glyph";
                "Crater", "glyph";
                "Dairy", "resource";
                "Denton", "resource";
                "DentonBrambles", "glyph";
                "DeployedBleeder", "critical";
                "Development", "secondary";
                "DistributionCenter", "resource";
                "Embassy", "secondary";
                "EnergyReserve", "resource";
                "Entertainment", "resource";
                "Espionage", "combat";
                "EssentiaVein", "glyph";
                "Fission", "resource";
                "Fissure", "critical";
                "FoodReserve", "resource";
                "Fusion", "resource";
                "GasGiantLab", "secondary";
                "GasGiantPlatform", "resource";
                "GeneticsLab", "secondary";
                "Geo", "resource";
                "GeoThermalVent", "glyph";
                "GratchsGauntlet", "glyph";
                "GreatBallOfJunk", "glyph";
                "Grove", "glyph";
                "HallsOfVrbansk", "glyph";
                "Hydrocarbon", "resource";
                "Intelligence", "combat";
                "IntelTraining", "secondary";
                "InterDimensionalRift", "glyph";
                "JunkHengeSculpture", "glyph";
                "KalavianRuins", "glyph";
                "KasternsKeep", "glyph";
                "Lake", "glyph";
                "Lagoon", "glyph";
                "Lapis", "resource";
                "LapisForest", "glyph";
                "LibraryOfJith", "glyph";
                "LostCityOfTyleon", "resource";
                "LuxuryHousing", "resource";
                "Malcud", "resource";
                "MalcudField", "glyph";
                "MassadsHenge", "glyph";
                "MayhemTraining","secondary";
                "MercenariesGuild", "secondary";
                "MetalJunkArches", "glyph";
                "Mine", "resource";
                "MiningMinistry", "resource";
                "MissionCommand", "secondary";
                "MunitionsLab", "combat";
                "NaturalSpring", "glyph";
                "Network19", "resource";
                "Observatory", "secondary";
                "OracleOfAnid", "glyph";
                "OreRefinery", "resource";
                "OreStorage", "resource";
                "Oversight", "secondary";
                "Pancake", "resource";
                "PantheonOfHagness", "glyph";
                "Park", "resource";
                "Pie", "resource";
                "PilotTraining", "combat";
                "PlanetaryCommand", "secondary";
                "PoliticsTraining", "secondary";
                "Potato", "resource";
                "Propulsion", "combat";
                "PyramidJunkSculpture", "glyph";
                "Ravine", "glyph";
                "RockyOutcrop", "glyph";
                "Sand", "glyph";
                "SAW", "combat";
                "Security", "combat";
                "Shake", "resource";
                "Shipyard", "combat";
                "Singularity", "resource";
                "Soup", "resource";
                "SpaceJunkPark", "glyph";
                "SpacePort", "combat";
                "SpaceStationLab", "secondary";
                "Stockpile", "secondary";
                "SubspaceSupplyDepot", "secondary";
                "SupplyPod", "secondary";
                "Syrup", "resource";
                "TempleOfTheDrajilites", "glyph";
                "TerraformingLab", "secondary";
                "TerraformingPlatform", "resource";
                "TheDillonForge", "glyph";
                "TheftTraining", "secondary";
                "ThemePark", "resource";
                "Trade", "combat";
                "Transporter", "secondary";
                "University", "secondary";
                "Volcano", "glyph";
                "WasteDigester", "resource";
                "WasteEnergy", "resource";
                "WasteExchanger", "resource";
                "WasteRecycling", "resource";
                "WasteSequestration", "resource";
                "WasteTreatment", "resource";
                "WaterProduction", "resource";
                "WaterPurification", "resource";
                "WaterReclamation", "resource";
                "WaterStorage", "resource";
                "Wheat", "resource";
             };
         }
         public string GetBuildingCategory(string m)
         {
             if (buildingTypes.ContainsKey[m])
                 return buildingTypes[m];
             else
                 return "building not found";
         }

    }
}
