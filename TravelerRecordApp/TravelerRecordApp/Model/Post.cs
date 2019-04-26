﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelerRecordApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }

        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Distance { get; set; }

        public string UserID { get; set; }
    }
}
