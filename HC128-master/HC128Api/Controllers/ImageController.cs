using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HC128Api.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HC128Api.Controllers
{

    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        List<ImageDTO> ImageDTOs;
        string JsonPath = Path.Combine(new string[] { Environment.CurrentDirectory, "ImageJson.json" });
        // GET: api/Image
        [HttpGet]
        public ActionResult Get()
        {
            string jsonstring = "[]";
            try
            {
                jsonstring = System.IO.File.ReadAllText(JsonPath);
            }
            catch (Exception)
            {
                jsonstring = "[]";
            }
            return Ok(jsonstring);
        }

        [Route("Names")]
        [HttpGet]
        public ActionResult GetNames()
        {
            List<string> imageNames = new List<string>();
            string jsonstring = "[]";
            try
            {
                jsonstring = System.IO.File.ReadAllText(JsonPath);
                ImageDTOs = JsonConvert.DeserializeObject<List<ImageDTO>>(jsonstring);
            }
            catch (Exception)
            {
                jsonstring = "[]";
            }
            foreach (var ImageDTO in ImageDTOs)
            {
                imageNames.Add(ImageDTO.ImageName);
            }
            return Ok(imageNames);
        }


        // GET: api/Image/5
        [HttpGet("{imageName}", Name = "imageName")]
        public ActionResult Get(string imageName)
        {
            string jsonstring = "[]";
            ImageDTO imageDTO = new ImageDTO();
            try
            {
                jsonstring = System.IO.File.ReadAllText(JsonPath);
                ImageDTOs = JsonConvert.DeserializeObject<List<ImageDTO>>(jsonstring);
                imageDTO = ImageDTOs.Find(image => image.ImageName == imageName);
            }
            catch (Exception)
            {

                jsonstring = "[]";
                ImageDTOs = new List<ImageDTO>();
            }
            return Ok(imageDTO);
        }

        // POST: api/Image
        [HttpPost]
        public void Post([FromBody]ImageDTO imageDTO)
        {
            string jsonstring;
            try
            {

                jsonstring = System.IO.File.ReadAllText(JsonPath);
                ImageDTOs = JsonConvert.DeserializeObject<List<ImageDTO>>(jsonstring);
            }
            catch (Exception)
            {

                jsonstring = "[]";
                ImageDTOs = new List<ImageDTO>();
            }
            ImageDTOs.Add(imageDTO);
            jsonstring = JsonConvert.SerializeObject(ImageDTOs);
           System.IO.File.WriteAllText(JsonPath, jsonstring);
        }

        // PUT: api/Image/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
