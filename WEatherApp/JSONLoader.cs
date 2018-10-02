﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WEatherApp
{
    public class JSONLoader
    {
        public async static Task<JSONLoader.RootObject> LoadJSON()
        {
            string filepath = "ms-appx:///Assets/CitiesJSON/weather_14.json";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(filepath));

            StreamReader reader = new StreamReader(stream);

            var json = await reader.ReadLineAsync();
            
            var serializer = new DataContractJsonSerializer(typeof(JSONLoader.RootObject));

            var jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            var data = (JSONLoader.RootObject)serializer.ReadObject(jsonStream);

            return data;

        }


        #region POCOs
        [DataContract]
        public class Main
        {
            [DataMember]
            public double temp { get; set; }
            [DataMember]
            public double temp_min { get; set; }
            [DataMember]
            public double temp_max { get; set; }
            [DataMember]
            public double pressure { get; set; }
            [DataMember]
            public double sea_level { get; set; }
            [DataMember]
            public double grnd_level { get; set; }
            [DataMember]
            public int humidity { get; set; }
            [DataMember]
            public double temp_kf { get; set; }
        }

        [DataContract]
        public class Weather
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }

        [DataContract]
        public class Clouds
        {
            [DataMember]
            public int all { get; set; }
        }

        [DataContract]
        public class Wind
        {
            [DataMember]
            public double speed { get; set; }
            [DataMember]
            public double deg { get; set; }
        }

        [DataContract]
        public class Snow
        {
            [DataMember]
            public double? __invalid_name__3h { get; set; }
        }

        [DataContract]
        public class Sys
        {
            [DataMember]
            public string pod { get; set; }
        }

        [DataContract]
        public class List
        {
            [DataMember]
            public int dt { get; set; }
            [DataMember]
            public Main main { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
            [DataMember]
            public Clouds clouds { get; set; }
            [DataMember]
            public Wind wind { get; set; }
            [DataMember]
            public Snow snow { get; set; }
            [DataMember]
            public Sys sys { get; set; }
            [DataMember]
            public string dt_txt { get; set; }
        }

        [DataContract]
        public class Coord
        {
            [DataMember]
            public double lat { get; set; }
            [DataMember]
            public double lon { get; set; }
        }

        [DataContract]
        public class City
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public string country { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public string cod { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public int cnt { get; set; }
            [DataMember]
            public List<List> list { get; set; }
            [DataMember]
            public City city { get; set; }
        }
        #endregion
    }
}
