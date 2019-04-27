﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace TravelerRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {

        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChange("Id");
            }
        }


        private string experience;
        public string Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                OnPropertyChange("Experience");
            }
        }


        private string venueName;
        public string VenueName
        {
            get
            {
                return venueName;
            }
            set
            {
                venueName = value;
                OnPropertyChange("VenueName");
            }
        }


        private string categoryID;
        public string CategoryID
        {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
                OnPropertyChange("CategoryID");
            }
        }


        private string categoryName;
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                OnPropertyChange("CategoryName");
            }
        }


        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChange("Address");
            }
        }


        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                OnPropertyChange("Latitude");
            }
        }


        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                OnPropertyChange("Longitude");
            }
        }


        private int distance;
        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
                OnPropertyChange("Distance");
            }
        }


        private string userID;
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                OnPropertyChange("UserID");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
           var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserID == App.user.Id).ToListAsync();
            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryID
                              select p.CategoryName).Distinct().ToList();

            //Same as above LINQ
            //var categories2 = postTable.OrderBy(p => p.CategoryID).Select(p => CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = (from p in posts
                             where p.CategoryName == category
                             select p).ToList().Count;

                //The same thing as above as well 
                //var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
