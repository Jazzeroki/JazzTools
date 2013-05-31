using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using LacunaExpanse;

namespace Jazz_Tools
{
	public class ButtonPlanetMap : Button
    {
        public String buildingID;
        public String buildingName;
        public string imageName;
        public string buildingLevel; 
        public int x;
        public int y;
        public int buttonArrayIndex;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class classBuildingsBeingMoved  //for use with rearaning the buildings within the program.
    {
        public string id = "0";
        public string imageName;
        public string buildingLevel; 
        public int x = 0;
        public int y = 0;
    }
    public class classBuildingsBeingMovedHash  //for use with rearrange_buildings request to server.
    {
        public string id = "0";
        public int x = 0;
        public int y = 0;
    }
    public class GlobalVariables
    {
        string url;
        string session_id;
    }

    public class BuildingInfo
    {
        public int index; //used in the arrayPlanetMap not in the json deserialization 
        public string id; //used in the arrayPlanetMap not in the json deserialization
        public string y;
        public string efficiency;
        public string level;
        public string name;
        public string url;
        public string x;
        public string image;
    }




}
