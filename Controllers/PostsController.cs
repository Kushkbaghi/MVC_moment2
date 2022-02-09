using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moment2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Moment2.Controllers
{
    public class PostsController : Controller
    {
        // GET: PostsController
        public IActionResult Index()
        {

            var jsonStr = System.IO.File.ReadAllText("posts.json");  // Convert data from json to str 
            var jsonObj = JsonConvert.DeserializeObject<List<Post>>(jsonStr); // Convert from str to Obj

            ViewBag.nrOfPosts = HttpContext.Session.GetString("nrOfPost"); // Set number of post to ViewBag

            // return en instanc of Post model
            return View(jsonObj);

        }

      
        [HttpGet]
        // Form to create new post
        public IActionResult Create()

        {

            return View();
        }

        // Post data from Create form
        [HttpPost]
        public IActionResult NewPost(IFormCollection col)
        {
            Post thePost = new Post();
            int num = 0;

            var jsonStr = System.IO.File.ReadAllText("posts.json");  // Convert data from json to str 
            var jsonObj = JsonConvert.DeserializeObject<List<Post>>(jsonStr); // Convert from str to Obj
            //Set Id
            thePost.Id = num;
            if (jsonObj != null)
            {
                num = jsonObj.Count;
                thePost.Id = num++;
            }
            // store data from form to obj
            thePost.Address = col["Address"];
            thePost.Room = Convert.ToInt32(col["Room"]);
            thePost.Rent = Convert.ToInt32(col["Rent"]);
            thePost.Date = Convert.ToDateTime(col["Date"]);
            thePost.Parking = col["Parking"];

            
            jsonObj.Add(thePost);

            // Write items into the file
            System.IO.File.WriteAllText("posts.json",
                JsonConvert.SerializeObject(jsonObj));


            return View(thePost);
        }
       

        // GET: PostsController/Delete/5
        public IActionResult Delete(int id)
        {
            var jsonStr = System.IO.File.ReadAllText("posts.json"); // Convert data from json to str 
            var jsonObj = JsonConvert.DeserializeObject<List<Post>>(jsonStr); // Convert from str to Obj
            jsonObj = jsonObj.Where(item => item.Id != id).ToList();


            // Write in the file
            System.IO.File.WriteAllText("posts.json",
                JsonConvert.SerializeObject(jsonObj));

            return LocalRedirect("/Posts/");

        }

        // Show the item by id
        public IActionResult Details(int id)
        {
            var jsonStr = System.IO.File.ReadAllText("posts.json"); // Convert data from json to str 
            var jsonObj = JsonConvert.DeserializeObject<List<Post>>(jsonStr); // Convert from str to Obj
            var objec = jsonObj.Find(item => item.Id == id);


            return View(objec);

        }


    }
}
