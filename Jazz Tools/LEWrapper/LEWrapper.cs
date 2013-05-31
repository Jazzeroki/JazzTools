using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web;
using System.Net;
using System.IO;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using LEWrapperResponse;
using System.Timers;
using System.Net.Http;
//using System.Net;
//using System.Data;
//using System.Data.SqlClient;
/* Design Notes
 * All methods in the Lacuna Expanse will be stored in partial classes that are all part of the LE_Wrapper class with each method type having
 * it's own file.  
 * All methods will have a unique request id number with blocks reserved for each request type  
 * Empire 100-199
 * Alliance
 * Stats
 * Captcha 200-210
 * Inbox 211-299
 * Map 300-399
 * Body 400-499
 * Inbox 500-599
 * Building 600-620
 * Module 621-640
 * PoliceStation 641-660
 * StationCommand 661-699
 * Parliament 700-799
 * BHG 800-830
 * Archaelogy
 * Capital
 * Development
 * DistributionCenter
 * Embassy
 * EnergyReserve
 * Entertainment
 * GeneticsLab
 * LibaryOfJith
 * LostCityOfTyleon
 * MercenariesGuild
 * MiningMinistry
 * MissionCommand
 * Network19
 * Observatory
 * OracleOfAnid
 * OreStorage
 * Park
 * PlanetaryCommand
 * PoliticsTraining
 * Security
 * Shipyard
 * Spaceport
 * SpaceStationLab
 * Stockpile
 * SubspaceSupplyDepot
 * TempleOfTheDrajites
 * TheDillonForge
 * TheftTraining
 * Trade
 * Transporter
 * WasteExchanger
 * WasteSequestration
 * WasteRecyling
 * WaterStorage
 * 
 * 
 * 
 * This program is copyrighted by Alma Jensen almajensen@gmail.com
 * 
 * All parts written by me however may be used in accordance with the GPL
 */
namespace LE_Wrapper
{
    partial class LEWrapper
    {
        private Timer timer;
        private string empire;
        private string password;
        private string sessionID;
        private string serverURL;
        private string API_KEY;
        private string logStartTimeStamp;
        //private int requestID; //used for tracking the unique id numbers of each json request
        private int rpcCount; //used for counting rpc calls made in 1 minute time should never exceed 60
        private StreamWriter log;
        //File file;
     
        //log = File.OpenText("log.txt");
        


        public LEWrapper(string empire, string password, string server) //setups upthe initial LE object in the situation that an empire already exists.  A new constructor is to be added later incase it's a new empire. 
        {
            //string cstring = Properties.Settings.Default.EmpireInfoConnectionString;
            DateTime date = new DateTime(1);
            logStartTimeStamp = date.ToShortDateString().Replace("/", "");
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (1000) * (60);             // Timer will tick evert 10 seconds
            timer.Enabled = true;                       // Enable the timer
            timer.Start();
            
            this.empire = empire;
            this.password = password;
            if (server == "us1")
            { 
                serverURL = "https://us1.lacunaexpanse.com";
                API_KEY = "6266769d-1f73-4325-a40f-6660c4c6440d";
            }
            if (server == "pt")
            { 
                serverURL = "https://pt.lacunaexpanse.com";
                API_KEY = "anonymous";
            }
            else
            {
                serverURL = "https://us1.lacunaexpanse.com";
                API_KEY = "6266769d-1f73-4325-a40f-6660c4c6440d";
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            rpcCount = 0;                    // Alert the user
        }
        private void WriteStringToLog(string toWrite)
        {
            string filename = logStartTimeStamp + empire+".txt";
            if (!File.Exists(filename))
                 log = new StreamWriter(filename);
            else
                log = File.AppendText(filename);
                log.WriteLine(toWrite);
 //           log.WriteLine(text);
            log.Close();
        }

        private JsonTextWriter Request(int id, string method, params string[] list)
        {
            JsonTextWriter writer = new JsonTextWriter();
            string ID = id.ToString();
            
            writer.WriteStartObject();
            writer.WriteMember("jsonrpc");
            writer.WriteString("2.0");
            writer.WriteMember("id");
            writer.WriteString(ID);
            writer.WriteMember("method");
            writer.WriteString(method);
            writer.WriteMember("params");
            writer.WriteStartArray();

            foreach (string param in list)
                writer.WriteString(param);

            return writer;
        }
        private void AddHashedParameters(JsonTextWriter writer, params string[] list)
        {
            if (list.Length % 2 > 0) return;
            writer.WriteStartObject();

            for (int i = 0; i < list.Length; i += 2)
            {
                writer.WriteMember(list[i]);
                writer.WriteString(list[i + 1]);
            }

            writer.WriteEndObject();
            //return writer;
        }
        public event ServerResponseHandler ServerResponseEvent;  //for publishing response events
        public delegate void ServerResponseHandler(LEWrapper le, Response e);
        private string Post(string url, JsonTextWriter json)
        {
            while (rpcCount > 50)
            { }//This creates the wait time until rpc count is reset.
            if (url == null) throw new Exception("URL is not assigned a value!");

            WebRequest request = WebRequest.Create(serverURL + url);
            request.Method = "POST";
            json.AutoComplete();
            string text = json.ToString();
            WriteStringToLog("request");
            WriteStringToLog(text);
//            log.WriteLine("Request");
//
            //Log.Write("Request: ");
            //Log.WriteLine(text.ToString() + "\n");

            json.Close();
            try
            {
            // Create a request using a URL that can receive a post. 
           // WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            // Set the Method property of the request to POST.
            //request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = text;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
                // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            //Console.ReadKey();
            // Clean up the streams.
            WriteStringToLog("response");
            WriteStringToLog(responseFromServer);
           
            reader.Close();
            dataStream.Close();
            response.Close();
            rpcCount++;

            if (ServerResponseEvent != null)  //deserializes the server response and passes it out as an event.
            {
                JavaScriptSerializer js = new JavaScriptSerializer();  
                Response r = js.Deserialize<Response>(responseFromServer);
                if (r.id == 101)
                {
                    sessionID = r.result.session_id;
                    Console.WriteLine(sessionID);
                }

                ServerResponseEvent(this, r);
            }
            //log.WriteLine("Response");
            WriteStringToLog("Response");
            //log.WriteLine(responseFromServer);
            WriteStringToLog(responseFromServer);
            return responseFromServer;
            }
            catch
            {
                WriteStringToLog("Post function failure");
                //log.WriteLine("Post function failure");
                //log.Close();
                string failure = "failure";
                return failure;
            }

        }
        private async void PostAsync(string url, JsonTextWriter json)
        {
            while (rpcCount > 50)
            { }//This creates the wait time until rpc count is reset.
            string server = serverURL + url;
            json.AutoComplete();
            string jsonToSend = json.ToString();
            //if (jsonToSend == null)
               // MessageBox.Show("json error " + jsonToSend);
            WriteStringToLog("request");
            WriteStringToLog(jsonToSend);
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(server, new StringContent(jsonToSend));
            //response.EnsureSuccessStatusCode();
            string responseFromServer = await response.Content.ReadAsStringAsync();
            WriteStringToLog("response");
            WriteStringToLog(responseFromServer);
            
            if (ServerResponseEvent != null)  //deserializes the server response and passes it out as an event.
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Response r = js.Deserialize<Response>(responseFromServer);
                if (r.id == 101)
                {
                    sessionID = r.result.session_id;
                    //Console.WriteLine(sessionID);
                }

                ServerResponseEvent(this, r);
            }
        }
        public void CloseLog() //obsolete
        {
            log.Close();           
        }
        static void Application_ApplicationExit(object sender, EventArgs e) //not working as inteded marked for deletion
        {
            //log.Close();

        }
    }
    public class EmpireCache //for storing all the information regarding an empire
    {
        public string empireID;
        public string empirePassword;
        public string essentia;
        public class station
        {
            public string id, name, size, starID, starName, orbit, stationX, stationY, zone; 
            public string influenceRemaining, influenceUsed; //station specific
            public string energyCapcity, energyHour, energyStored;
            public string oreCapcity, oreHour, oreStored;
            public string waterCapcity, waterHour, waterStored;
            public string foodCapcity, foodHour, foodStored;
            public string incomingAlly, incomingOwn, incomingEnemy;
            public Building[] building;
        }
        public class Planet
        {
            public string id, name, size, starID, starName, orbit, stationX, stationY, zone;
            public string influenceRemaining, influenceUsed; //station specific
            public string energyCapcity, energyHour, energyStored;
            public string oreCapcity, oreHour, oreStored;
            public string waterCapcity, waterHour, waterStored;
            public string foodCapcity, foodHour, foodStored;
            public string happiness, happinessPerHour;
            public string incomingAlly, incomingOwn, incomingEnemy;
            public Building[] building;

        }
        public class Building
        {
            public string id;
            public int x;
            public int y;
            public string url;
            public string name;
            public string image;
            public string level;
            public string efficiency;
        }

    }
}
