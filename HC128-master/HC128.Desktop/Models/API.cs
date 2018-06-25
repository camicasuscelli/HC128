using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HC128.Desktop.Models
{
    public static class API
    {
        public static async Task<List<string>> GetImageName(string url)
        {
            var path = url + @"/api/Image/Names";
            string responseString = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    responseString = await client.GetStringAsync("http://" + path);
                }

                return JsonConvert.DeserializeObject<List<string>>(responseString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<ImgAPI> GetImageDetail(string url, string name)
        {
            var path = url + @"/api/Image/" + name;
            string responseString = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    responseString = await client.GetStringAsync("http://" + path);
                }

                return JsonConvert.DeserializeObject<ImgAPI>(responseString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<bool> PostImage(string url, ImgAPI imgApi)
        {
            var path = url + @"/api/Image";
            HttpResponseMessage Response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Response = await client.PostAsJsonAsync("http://" + path, imgApi);
                }
                if (Response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
