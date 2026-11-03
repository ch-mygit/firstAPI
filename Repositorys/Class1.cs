using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using static Models.Model;


namespace Repositorys
{
    public class repository
    {

        
        
        
        
            // GET: api/<UserController>
           
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/<UserController>/5
           
            public User GetById(int id)
            {
                using (StreamReader reader = System.IO.File.OpenText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt"))
                {
                    string? currentUserInFile;
                     while ((currentUserInFile = reader.ReadLine()) != null)
                     {
                         User user =
                        JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.userId == id)
                        return user;
                }
                }
            return null;
            }

            // POST api/<UserController>
           
            public User Post( User user)
            {
                int numberOfUsers = System.IO.File.ReadLines("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt").Count();
                user.userId = numberOfUsers + 1;
                string userJson = JsonSerializer.Serialize(user);
                System.IO.File.AppendAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt", userJson +
                Environment.NewLine);
                return user;
                
            }
           
            public User PostLogin( LoginUser loginUser)
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
                    return new User();
                }
            }


            // PUT api/<UserController>/5
           
            public void Put(int id,  User user)
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
           
            public void Delete(int id)
            {
            }


        
    }
}
