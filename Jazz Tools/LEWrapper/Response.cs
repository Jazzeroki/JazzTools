//  
//  Response.cs
//  
//  Author:
//       Brian Estabrooks <csbestark@hotmail.com>
// 
//  Copyright (c) 2012 Brian Estabrooks
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.


using System;
using System.Collections;
using System.Collections.Generic;

namespace LEWrapperResponse
{
  public class Response : EventArgs
  {
    public int id;
    public string jsonrpc;

    public class Error
    {
      public int code;
      
      public class Data
      {
        public string guid;
        public string url;
      }
      public Data data;
      
      public string message;
    }
    public Error error;

    public class Result
    {
      public string session_id;
      public class Body
      {
        public string surface_image;
      }
      public Body body;
      public Dictionary<string,string> boosts;
      
      public class Buildable
      {
        public class Build
        {
          public class Cost
          {
            public int waste;
            public int energy;
            public int ore;
            public int food;
            public int time;
            public int water;
          }
          public string no_plot_use;
          public string reason;
          public string can;
          public string [] tags;
        }
        public class Production
        {
          public int waste_hour;
          public int waste_capacity;
          public int food_capacity;
          public int food_hour;
          public int ore_capacity;
          public int energy_hour;
          public int water_capacity;
          public int happiness_hour;
          public int energy_capacity;
          public int ore_hour;
          public int water_hour;
        }
        public Build build;
        public Production production;
        public string url;
        public string image;
      }
      public Dictionary<string,Buildable> buildable;

      public class Building
      {
        public string id; // Internal use only, not part of response
        public int index; // Not part of response, for use in Jazz Tools for mapping out buildings on a planet
        public int x;
        public int y;
        public string url;
        public string name;
        public string image;
        public string level;
        public string efficiency;
  
        public class Work
        {
          public int seconds_remaining;

          public string end;
          public string searching;  // Archaeology glyph search
          public string start;
        }
        public Work pending_build;
        public Work work;
      }
      public Dictionary<string,Building> buildings;
      public Building [] moved;

      public class EffectBHG
      {
        public Dictionary<string,string> fail;
        public Dictionary<string,string> side;
        public Dictionary<string,string> target;
      }
      public EffectBHG effect;
  
      public class Glyph
      {
        public string id;
        public string name;
        public string quantity;
        public string type;
      }
      public Glyph [] glyphs;

      public class Map
      {
        public string planetID; // Internal use only, not part of response

        public string surface_image;
        //public Buildings [] buildings;  This is throwing an error need to fix
      }
      public Map map;
  
      public class Plan
      {
        public string id;
        public string name;
        public string level;
        public string extra_build_level;
      }
      public Plan [] plans;
  
      public class Prisoner
      {
        public string id;
        public string name;
        public string level;
      }
      public Prisoner [] prisoners;

      public class Reserve
      {
        public int seconds_remaining;
        public int can;
        public int max_reserve_duration;
        public int max_reserve_size;

        public class Resource
        {
          public string quantity;
          public string type;
        }
        public Resource [] resources;
      }
      public Reserve reserve;

      public Dictionary<string,int> resources;
  
      public class Ship
      {
        public string planetID; // Internal use only, not part of response

        public string id;
        public string name;
        public string task;
        public string type;
        public string combat;
        public string stealth;
        public string speed;
        public string berth_level;
        public string hold_size;
        public string type_human;
        public string fleet_speed;
        public string date_started;
        public string date_available;
        public string estimated_travel_time;
        public int can_recall;
        public int can_scuttle;
        public int max_occupants;

        public string [] payload;
      }
      public Ship [] ships;

      public class Star
      {
        public string buildingID; // Internal use only, not part of response

        public string id;
        public string name;
        public string color;
        public string x,y;
        public string zone;

        public Status.Body [] bodies;
      }
      public Star [] stars;
      public Star star;
  
      public class Status
      {
        public class Body
        {
            public class Station
            {
                public string id;
                public string name;
                public string x, y;
            }
          public class Empire
          {
            public string id;
            public string name;
            public string alignment;
            public string is_isolationist;
          }
          public Station station;
          public Empire empire;
          public string energy_capacity;
          public string energy_hour;
          public string energy_stored;
          public string food_capacity;
          public string food_hour;
          public string food_stored;
          public string happiness;
          public string happiness_hour;
          public class Alliance
          {
              public string name;
              public string id;
          }
          public Alliance alliance;
          public string building_count;
          public class Incoming
          {
            public string id;
            public string date_arrives;
            public string is_own;
            public string is_ally;
          }
          public Incoming [] incoming_foreign_ships;
          public Incoming [] incoming_ally_ships;
          public Incoming [] incoming_own_ships;

          public Dictionary<string,int> ore;
          public string ore_capacity;
          public string ore_hour;
          public string ore_stored;
          public string plots_available;
          public string population;

          public string id;
          public string image;
          public class Influence
          {
              public string spent;
              public string total;
          }
          public Influence influence;
          public string name;
          public string orbit;
          public string size;
          public string star_id;
          public string star_name;
          public string type;
          public string waste_capacity;
          public string waste_hour;
          public string waste_stored;
          public string water;
          public string water_capacity;
          public string water_hour;
          public string water_stored;
          public string x,y;
          public string zone;
          
          public int needs_surface_refresh; // 1 if client needs to call get_buildings
            public string num_incoming_ally;
            public string num_incoming_enemy;
            public string num_incoming_own;
            //public string orbit;

        }
        public Body body;
  
        public class Empire
        {
            public string essentia;
            public string has_new_messages;
            public string home_planet_id;
            public string id;
            public string is_isolationist;
            public string latest_messaged_id;
            public string name;
          public Dictionary<string, string> planets;
          //public string home_planet_id;
          public int rpc_count;
          public string self_destruct_active;
          public string self_destruct_date;
          public string status_message;
          public string tech_level;
        }
        public Empire empire;
  
        public class Server
        {
          public class MapSize
          {
            public int [] x,y;
          }
          public MapSize star_map_size;
          
          public int rpc_limit;
          public string time;
          public string version;
        }
        public Server server;
      }
      public Status status;

      public class TasksBHG
      {
        public int base_fail;
        public int body_id;
        public string dist;
        public string min_level;
        public string name;
        public string occupied;
        public string range;
        public string reason;
        public string recovery;
        public string side_chance;
        public string success;
        public string @throw;
        public string [] types;
        public string waste_cost;
      }
      public TasksBHG [] tasks;
      
      public class Trade
      {
        public Status.Body body;
        public Status.Body.Empire empire;
        
        public class Delivery
        {
          public int duration;
        }
        public Delivery delivery;
        
        public string [] offer;
        public string date_offered;
        public string id;
        public string ask;
      }
      public Trade [] trades;
  
      public string cargo_space_used_each;
      public string guid;
      public string number_of_ships;
      //public string session_id;
      public string star_count;
      public string url;
    }
    public Result result;
  }
}

