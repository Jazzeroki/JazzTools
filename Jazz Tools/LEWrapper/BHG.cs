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
        private string BHGURL = "/blackholegenerator";
        public enum BHGTask
        {
            Make_Asteroid,
            Make_Planet,
            Increase_Size,
            Change_Type,
            Swap_Places,
            Jump_Zone,
            Move_System
        }
        public void BHGView(string buildingID)
        {
            int id = 800;
            string method = "view";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            Post(stationCommandURL, r);
        }
        public void BHGGenerateSingularity(string buildingID, string target, BHGTask task, params string[] param)
        {
            int id = 800;
            string method = "generate_singularity";
            JsonTextWriter r = Request(id, method, buildingID.ToString());
            AddHashedParameters(r,"body_name",target);
            r.WriteString(task.ToString().Replace("_"," "));
            if (param.Length == 1)
                AddHashedParameters(r, "new_type", param[0]);
            Post(BHGURL, r);
        }
    }
}
