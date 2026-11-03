using static Models.Model;
using Repositorys;
namespace Servieces
{
    public class servieces
    {
        repository repo=new repository();
       
        
            // GET: api/<passwordsController>

            public IEnumerable<string> Get()
            {
                return repo.Get();
            }

            // GET api/<passwordsController>/5

            public User Get(int id) 
            {
                return repo.GetById(id);
            }

            // POST api/<passwordsController>

            public User Post(User user)
            {
                return repo.Post(user);
            }

            // PUT api/<passwordsController>/5

          

            // DELETE api/<passwordsController>/5

            public void Delete(int id)
            {
            }
        public User PostLogin( LoginUser loginUser)
        {
            return repo.PostLogin(loginUser);
        }
        public void Put(int id, User user)
        {
            repo.Put(id, user);
        }

    }
}
