using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;

using Jayrock;
using Jayrock.Json;
using LE_Wrapper;
using LEWrapperResponse;
using System.Threading.Tasks;
using System.Threading;
using JazzToolUtilities;


namespace Jazz_Tools
{
    public partial class MainForm : Form
    {
        Response currentPlanetResponse;
        //string apiKey = "6266769d-1f73-4325-a40f-6660c4c6440d";
        string url;
        //string sessionId;
        //string requestType;
        //string body_id;
        string labelImageName = string.Empty; //used in place of an imagenamelabel
        ButtonPlanetMap[] buttonArray = new ButtonPlanetMap[121];
        //BuildingInfo
        Response.Result.Building [] arrayPlanetMap = new Response.Result.Building[121];
        //BuildingInfo[] arrayPlanetMap = new BuildingInfo[121];
        private LEWrapper le;
        private Dictionary<string, string> planets;
        private string homePlanetID;
        private async Task<Dictionary<string, string>> GetDamagedBuildings()
        {
            //Task<Dictionary<string, string>> damagedBuildings = new Task<Dictionary<string,string>>();
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (ButtonPlanetMap i in buttonArray)
            {
                //Dictionary<string, string> d = new Dictionary<string,string>();
                if (Convert.ToInt32(i.efficiency) < 100)
                {
                    d.Add(i.buildingID.ToString(), i.buildingName);
                    //(Dictionary<string, string>)damagedBuildings.
                }
            }
            //damagedBuildings = Cast d;
            //return damagedBuildings;
            return d;
        }
        public void SetXYValuesToarrayPlanetMap()
        {
            int x = -5;
            int y = 5;
            for (int i = 0; i < arrayPlanetMap.Length; i++)
            {
                //arrayPlanetMap[i].x = Convert.ToString(x++);
                //arrayPlanetMap[i].y = Convert.ToString(y);
                arrayPlanetMap[i].x = x++;
                arrayPlanetMap[i].y = y;
                arrayPlanetMap[i].index = i;
                if (x == 6)//resets the x and y values when they reach the end of the row
                {
                    --y;
                    x = -5;
                }
            }
        }//writes x and y values to the planetmaparray
        public void MapBuildingInfoToArrayPlanetMap(Dictionary<string, Response.Result.Building> Buildings)  //Change in development
        {
            //labelStatusText.Text = "DrawingPlanetMap()";
            foreach (KeyValuePair<string, Response.Result.Building> buildingCopy in Buildings)
            {
                var result = from v in arrayPlanetMap
                             where v.x == buildingCopy.Value.x && v.y == buildingCopy.Value.y
                             select v.index;
                foreach (int i in result)
                {
                    arrayPlanetMap[i].id = buildingCopy.Key;
                    arrayPlanetMap[i].name = buildingCopy.Value.name;
                    //arrayPlanetMap[i].Text = buildingCopy.Value.name;
                }
            }
        }
        private void ClearPlanetMap() //clears planet map and clears BHGID and ForgeID
        {
            //BHGID = string.Empty;
            //ForgeID = string.Empty;
            labelStatusText.Text = "ClearPlanetMap()";
            labelBuildingID.Text = "Building ID";
            labelBuildingLevel.Text = "Building Level";
            labelBuildingName.Text = "Building Name";
            labelBuildingID.Text = "Building ID";
            labelBuildingEfficiency.Text = "Building Efficiency";
            labelImageName = string.Empty;
            try
            {
                for (int i = 0; i < 121; i++)
                {
                    buttonArray[i].buildingID = string.Empty;
                    buttonArray[i].buildingName = string.Empty;
                    buttonArray[i].buildingLevel = string.Empty;
                    buttonArray[i].efficiency = string.Empty;
                    buttonArray[i].Text = string.Empty;
                    buttonArray[i].imageName = string.Empty;
                    buttonArray[i].Image = imageListBuildingImages.Images["blank.png"];
                    buttonArray[i].Image = imageListBuildingImages.Images[""];
                }
                //MessageBox.Show("Map Cleared");
            }
            catch
            { //MessageBox.Show("Map Clearing Failed"); 
            }
        }
        public void RearrangeControlsHide()
        {
            labelBuildingID.Hide();
            labelBuildingID.Hide();
            labelBuildingName.Hide();
            labelBuildingX.Hide();
            labelBuildingY.Hide();
            labelBuildingLevel.Hide();
            labelBuildingEfficiency.Hide();
            buttonRearrangeBuildings.Hide();
            buttonRearrangeInfo.Hide();

        }
        public void RearrangeControlsShow()
        {
            labelBuildingID.Show();
            labelBuildingName.Show();
            labelBuildingX.Show();
            labelBuildingY.Show();
            labelBuildingLevel.Show();
            labelBuildingEfficiency.Show();
            buttonRearrangeBuildings.Show();
            buttonRearrangeInfo.Show();
        }

        public void ShowPlanetSelectMenu()
        {
            cbPlanetsList.Show();
        }
        public void HidePlanetSelectMenu()
        {
            cbPlanetsList.Hide();
        }
        public void HideServerSelectMenu()
        {
            us1.Hide();
            pt.Hide();
            selectSeverLabel.Hide();
        }
        public void LoginMenuShow()
        {
            //apiKeyBox.Show();
            userNameBox.Show();
            passwordBox.Show();
            //apiKeyLabel.Show();
            usernameLabel.Show();
            passwordLabel.Show();
            loginButton.Show();
        }
        public void HideBetaWarningLabel()
        {
            labelBetaWarning.Hide();
            //laapiKeyBox.Hide();
        }
        public void LoginMenuHide()
        {
            //apiKeyBox.Hide();
            userNameBox.Hide();
            passwordBox.Hide();
            //apiKeyLabel.Hide();
            usernameLabel.Hide();
            passwordLabel.Hide();
            loginButton.Hide();

        }

        public delegate void s();
        public void DrawPlanetMap()
        {
            
            // labelStatusText.Text = "DrawingPlanetMap()";
            imageListBuildingImages.TransparentColor = Color.White;
            //HidePlanetSelectMenu();
           /*if (this.InvokeRequired)
            {
               Invoke((RearrangeControlsShow) =>)
                s S = new s(RearrangeControlsShow);
                Invoke(S);
                //public delegate string simple;

            };
            //Invoke(()=>RearrangeControlsShow);
            * */
            int horizontal = 1;
            int horizontalend = 550;
            int vertical = 1;
            int x = -5;
            int y = 5;

            for (int i = 0; i < buttonArray.Length; i++)
            {
                buttonArray[i] = new ButtonPlanetMap();
                buttonArray[i].Size = new Size(50, 50);
                buttonArray[i].Location = new Point(horizontal, vertical);
                buttonArray[i].BackColor = Color.SpringGreen;
                buttonArray[i].buttonArrayIndex = i;
                buttonArray[i].buildingName = "";
                buttonArray[i].buildingID = "";
                buttonArray[i].efficiency = "";
                buttonArray[i].x = x++;
                buttonArray[i].y = y;
                buttonArray[i].Image = imageListBuildingImages.Images["blank.png"];
                buttonArray[i].Image = imageListBuildingImages.Images[""];
                if (x == 6)
                {
                    --y;
                    x = -5;
                }
                horizontal += 50;
                if (horizontal >= horizontalend)
                {
                    horizontal = 1;
                    vertical += 50;
                }
                buttonArray[i].Click += new EventHandler(ClickBuildingSwap);
                
                //this.Controls.Add(buttonArray[i]); //without this the buttons won't add
            }
            //Task d = new Task();
            //return 42;
        }//creates the button array and maps out the buildings
        private void ShowButtonsOnForm()
        {
            for (int i = 0; i < 121; i++)
                this.Controls.Add(buttonArray[i]); //without this the buttons won't add
            
        }
        public void PopulatePlanetMap(Dictionary<string, Response.Result.Building> Buildings) //converts the building info dictionary into an array
        {
            //Dictionary<string, BuildingInfo> buildings = Buildings;
            labelStatusText.Text = "Populating Planet Map";
            foreach (KeyValuePair<string, Response.Result.Building> buildingCopy in Buildings)
            {
                var result = from v in buttonArray
                             where v.x == Convert.ToInt32(buildingCopy.Value.x) && v.y == Convert.ToInt32(buildingCopy.Value.y)
                             select v.buttonArrayIndex;
                foreach (int i in result)
                {
                    buttonArray[i].buildingID = buildingCopy.Key;
                    buttonArray[i].buildingName = buildingCopy.Value.name;
                    buttonArray[i].Text = buildingCopy.Value.level;
                    buttonArray[i].buildingLevel = buildingCopy.Value.level;
                    buttonArray[i].efficiency = buildingCopy.Value.efficiency;
                    buttonArray[i].imageName = buildingCopy.Value.image + ".png";
                    buttonArray[i].Image = imageListBuildingImages.Images[buttonArray[i].imageName];
                }
            }
            labelStatusText.Text = "Planet Map Populated";
        }//creates the button array and maps out the buildings
        public MainForm()
        {
            InitializeComponent();
            LoginMenuHide();
            HidePlanetSelectMenu();
            RearrangeControlsHide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            labelStatusText.Text = "logging in";
            LoginMenuHide();
            HideBetaWarningLabel();
            le = new LEWrapper(userNameBox.Text, passwordBox.Text, url);
            le.EmpireLogin();
            le.ServerResponseEvent += (rresponseSender, responseE) =>
                {
                    
                    Response r;
                    r = responseE as Response;
                    if (r.id == 101)
                    {

                        homePlanetID = r.result.status.empire.home_planet_id;
                        planets = r.result.status.empire.planets;
                        planets = planets.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value); //alphabetizes planets according to value
                        labelStatusText.Text = "Please wait a few moments. Drawing Planet Map";

                        //Task d = new Task();
                        //await DrawPlanetMap();
                        
                        //var thread = new Thread(()=>DrawPlanetMap());
                       
                        //thread.Start();
                        //thread.Join();
                        DrawPlanetMap();
                        ShowButtonsOnForm();
                        RearrangeControlsShow();
                        //DrawPlanetMap();
                        ShowPlanetSelectMenu();
                        cbPlanetsList.ValueMember = "Key";
                        cbPlanetsList.DisplayMember = "Value";
                        cbPlanetsList.DataSource = new BindingSource(planets, null);
                        cbPlanetsList.SelectedValue = homePlanetID;
                    }


                };

        }

        private void us1_Click(object sender, EventArgs e)
        {
            url = "us1";
            HideServerSelectMenu();
            LoginMenuShow();
        }

        private void pt_Click(object sender, EventArgs e)
        {
            url = "pt";
            HideServerSelectMenu();
            LoginMenuShow();
        }

/*        private void buttonGetBodyData_Click(object sender, EventArgs e) //rewrite to use new framework
        {
            ClearPlanetMap();
            le.BodyGetBuildings(cbPlanetsList.SelectedValue.ToString());
            le.ServerResponseEvent += (senderR, eR) =>
            {
                Response r = eR as Response;
                if (r.id == 402)
                {
                    //Dictionary<string, r.result.buildings> Buildings = r.result.buildings;
                    //MapBuildingInfoToArrayPlanetMap(r.result.buildings);
                    PopulatePlanetMap(r.result.buildings);
                }
            };
        } */  //commenting out to test before total deletion
        private class PlanetMap
        {
            public string buildingID = string.Empty;
            public string buildingName = string.Empty;
            public string buildingLevel = string.Empty;
            public string imageName = string.Empty;
            public string efficiency = string.Empty;
        
        }
        private void ClickBuildingSwap(object sender, EventArgs e)
        {
            if (labelBuildingID.Text == "Building ID")
            {
                labelBuildingID.Text = string.Empty;
                labelBuildingName.Text = string.Empty;
                labelBuildingLevel.Text = string.Empty;
                labelBuildingEfficiency.Text = string.Empty;
                labelImageName = string.Empty;
            }
            //string labelImageName = string.Empty; //used in place of an imagenamelabel
            ButtonPlanetMap btnButton = sender as ButtonPlanetMap;
            PlanetMap tempPlanetMap = new PlanetMap();//initializes the temporary planetmap object
            tempPlanetMap.buildingID = "";
            tempPlanetMap.buildingName = "";
            tempPlanetMap.buildingLevel = "";
            tempPlanetMap.efficiency = "";
            tempPlanetMap.imageName = "";

            if (btnButton.x == 0 && btnButton.y == 0)
            {
                MessageBox.Show("This building cannot be moved");
            }
            else
            {
                tempPlanetMap.buildingID = btnButton.buildingID;//moving building into temp storage
                tempPlanetMap.buildingName = btnButton.buildingName;
                tempPlanetMap.buildingLevel = btnButton.buildingLevel;
                tempPlanetMap.efficiency = btnButton.efficiency;
                tempPlanetMap.imageName = btnButton.imageName;

                btnButton.buildingID = ""; //clearing button storage before new info is written in
                btnButton.buildingName = "";
                btnButton.imageName = "";
                btnButton.buildingLevel = "";
                btnButton.efficiency = "";
                btnButton.Image = imageListBuildingImages.Images["blank.png"];
                
                //btnButton.BackgroundImage = imageListBuildingImages.Images["blank.png"];//sets the default image

                btnButton.buildingID = labelBuildingID.Text;//moves the label info into the empty button
                btnButton.buildingName = labelBuildingName.Text;
                btnButton.Text = labelBuildingLevel.Text;
                btnButton.buildingLevel = labelBuildingLevel.Text;
                btnButton.efficiency = labelBuildingEfficiency.Text;
                btnButton.imageName = labelImageName;
                btnButton.Image = imageListBuildingImages.Images[labelImageName];

                labelBuildingID.Text = tempPlanetMap.buildingID;//label updating
                labelBuildingName.Text = tempPlanetMap.buildingName;
                labelBuildingLevel.Text = tempPlanetMap.buildingLevel;
                labelBuildingEfficiency.Text = tempPlanetMap.efficiency;
                //labelBuildingLevel.Text = tempPlanetMap.buildingLevel;
                labelImageName = tempPlanetMap.imageName;
                buildingPictureBox.Image = imageListBuildingImages.Images[tempPlanetMap.imageName];
                labelBuildingX.Text = Convert.ToString(btnButton.x);
                labelBuildingY.Text = Convert.ToString(btnButton.y);
                if (labelBuildingID.Text == "")
                {
                    labelBuildingID.Text = "Building ID";
                    labelBuildingName.Text = "Building Name";
                    labelBuildingLevel.Text = "Building Level";
                    labelBuildingEfficiency.Text = "Efficiency";
                    labelBuildingX.Text = "x";
                    labelBuildingY.Text = "y";
                }

            }

        }

        private void buttonRearrangeBuildings_Click(object sender, EventArgs e)
        {
            if (labelBuildingID.Text == "Building ID")
            {
            labelStatusText.Text = "Rearranging Buildings";
            var result = from v in buttonArray // finds all the buildings in the array and puts them into result
                         where v.buildingID != "" && v.buildingID != null //check if this is And or Or
                         select v.buttonArrayIndex;

            // classBuildingsBeingMovedHash[] arrangement = new classBuildingsBeingMovedHash[result.Count()];
            string[] arrangement = new string[result.Count()*3];
            int j = 0;
            //this loop copies all the buildings out of the planet map array into an array of all the buildings to be moved.
            foreach (int i in result)//i has an array of the buttonarry indexes that need to be sent.
            {
                arrangement[j] = buttonArray[i].buildingID;
                j++;
                arrangement[j] = buttonArray[i].x.ToString();
                j++;
                arrangement[j] = buttonArray[i].y.ToString();
                j++;

            }
            le.BodyRearrangeBuildings(cbPlanetsList.SelectedValue.ToString(), arrangement);
            labelStatusText.Text = "rearrangement sent";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not attempt to move Tyleon or the SpaceStation Lab, this will cause the program to crash");
        }



        private void labelBetaWarning_Click(object sender, EventArgs e)
        {

        }


        private void buttonLoadPlanetInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicking this button will cause any rearrangements of buildings on this planet to be lost");
        }

        private void buttonRearrangeInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buildings will only be rearranged on the server after clicking this.\nPlease be aware when moving set buildings such as the Space Station Lab, or the Lost City of Tyleon\n that they must be placed again in the proper order or a server error will be returned");
        }
        private void cbPlanetsList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show("selected index changed"); 
            labelStatusText.Text = "Selected Planet Changed";
            ClearPlanetMap();
            le.BodyGetBuildings(cbPlanetsList.SelectedValue.ToString());
            le.ServerResponseEvent += (senderR, eR) =>
                {
                    Response r = eR as Response;
                    if (r.id == 402)
                    {
                        currentPlanetResponse = r;
                        //labelStatusText = "Food: " + currentPlanetResponse.result.buildings.
                        //Dictionary<string, r.result.buildings> Buildings = r.result.buildings;
                        //MapBuildingInfoToArrayPlanetMap(r.result.buildings);
                        PopulatePlanetMap(r.result.buildings);

                    }
                };
             
        }
        private void RepairBuildings()
        {

        
        }



    }
}
