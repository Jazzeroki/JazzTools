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
        public enum oreTypes
        {rutile, chromite, chalcopyrite, galena, gold, uraninite, bauxite, goethite, halite, gypsum, trona, kerogen, methane, anthracite, sulfur, zircon, monazite, fluorite, beryl, magnetite };
        private string archaeologyURL = "/archaeology";
        public void archaeologyView(int buildingID)
        {
            int id = 0;
            string method = "view";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(archaeologyURL, r);
        }
        public void archaeologySearchForGlyph(int buildingID, oreTypes ore)
        {
            int id = 0;
            string method = "search_for_glyph";
            JsonTextWriter r = Request(id, method, buildingID.ToString(), ore.ToString());
            Post(archaeologyURL, r);
        }
        public void archaeologySubsidizeSearch(int buildingID)
        {
            int id = 0;
            string method = "subsidize_search";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(archaeologyURL, r);
        }
        public void archaeologyGetGlyphs(int buildingID)
        {
            int id = 0;
            string method = "get_glyphs";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(archaeologyURL, r);
        }
    }
}
