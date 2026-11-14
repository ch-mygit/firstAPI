using Microsoft.AspNetCore.Mvc;
using static Models.Model;
using Servieces;
using System.Text.Json;

namespace MyWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        //Why isn't GET by id implemented? It should read the file and return the user with this id (or NoContent() if there is none)
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            //The assignment asks to read and write the data file only in the repositories project: the service calls the repository
            //Full paths like E:\... only work on this computer: use a path relative to the project
            int numberOfUsers = System.IO.File.ReadLines("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt").Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt", userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId },
            user);
        }
        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password ==
                    loginUser.password)
                        return user;
                }
                //The assignment asks a wrong password to return 204: what does NotFound() return here, and should it be NoContent()?
                return NotFound();
            }
        }


            // PUT api/<UserController>/5
            [HttpPut("{id}")]
            //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User user)
            {
                string textToReplace = string.Empty;
                using (StreamReader reader =
                System.IO.File.OpenText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt"))
                {
                    string currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user1 =
                        JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user1.userId == id)
                            textToReplace = currentUserInFile;
                    }
                }
                if (textToReplace != string.Empty)
                {
                    string text = System.IO.File.ReadAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt");
                    text = text.Replace(textToReplace,
                    JsonSerializer.Serialize(user));
                    System.IO.File.WriteAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt", text);
                }
            }

            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        
    }
}

