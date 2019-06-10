using git.API.Repository;
using git.Model.Model;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace git.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GitUserController : ApiController
    {
        public async Task<GitUserViewModel> getuserdata(string login)
        {
            GitUserViewModel data = null;
            try
            {
                using (GitUserRepository _repo = new GitUserRepository())
                {
                    data = await _repo.Getuserdata(login);
                }
                return data;

            }
            catch (Exception)
            {
                return null;

            }
            finally
            {
                data = null;
            }
        }
    }
}
