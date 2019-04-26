﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.Model;

namespace TravelerRecordApp.Logic
{
    public class VenueLogic
    {

        //for async, if you want to return something, make it Task<>
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
              var response = await client.GetAsync(url);
              var json = await response.Content.ReadAsStringAsync();

              var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
              venues = venueRoot.response.venues as List<Venue>;
            }

            return venues;
        }
    }
}