using System;
using System.IO;
using System.Net;
using System.Drawing;

namespace UserData
{
    struct VkUser
    {
        public string Name;
        public string MiddleName;
        public string Surname;
        public string DateOfBirth;
        public string City;
        public Image Photo;
    }

    class VkManager
    {
        private static int numPhotos = 0;

        public VkUser GetUserById(long id)
        {
            string uri = @"https://api.vk.com/method/users.get.xml?user_ids=" +
                id.ToString() + "&fields=bdate,city,photo_max_orig&v=5.7";
            return ParseUserData(LoadData(uri));
        }

        private VkUser ParseUserData(string userData)
        {
            VkUser user;

            user.Name = GetValue(userData, "first_name");
            user.MiddleName = "";
            user.Surname = GetValue(userData, "last_name");
            user.City = GetCityById(GetValue(userData, "city"));
            user.DateOfBirth = GetValue(userData, "bdate");

            string photoUri = GetValue(userData, "photo_max_orig");
            user.Photo = photoUri == String.Empty ? null : GetPhotoByUri(photoUri);

            return user;
        }

        private string GetCityById(string id)
        {
            string uri = @"https://api.vk.com/method/" +
                "database.getCitiesById.xml?city_ids=" +
                id.ToString() + "&v=5.7";
            return GetValue(LoadData(uri), "title");
        }

        private string LoadData(string uri)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.Timeout = 10000;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string data = null;
            using (StreamReader reader =
                new StreamReader(response.GetResponseStream()))
            {
                data = reader.ReadToEnd();
                reader.Close();
            }

            return data;
        }

        private string GetValue(string text, string field)
        {
            int index1 = text.IndexOf("<" + field + ">");
            if (index1 > 0)
            {
                int index2 = text.IndexOf("</" + field + ">");
                return text.Substring(index1 + field.Length + 2,
                    index2 - index1 - field.Length - 2);
            }
            return String.Empty;
        }

        private Image GetPhotoByUri(string uri)
        {
            string fileName = "img" +
                (++numPhotos).ToString() + ".jpg";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(uri, fileName);
                return Image.FromFile(fileName);
            }
        }
    }
}
