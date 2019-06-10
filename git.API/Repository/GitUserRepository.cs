using git.Common;
using git.Common.Helpers;
using git.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace git.API.Repository
{
    public class GitUserRepository : IDisposable
    {
                           
        public async Task<GitUserViewModel> Getuserdata(string login)
        {
            GitUserViewModel gb = null;
            IEnumerable<GitRepositoryModel> rootObjectList = Enumerable.Empty<GitRepositoryModel>();
            //string login = "asad-sangla";
            User userModel = await GetUser(login);
            if (userModel != null && userModel.public_repos > 0)
            {
                GitRepositoryModel[] rootObjects = await GetUserRepos(login);
                if (rootObjects != null)
                {
                    rootObjectList = GetPagingSoringResult(rootObjects);
                }
                else
                {
                    rootObjectList = null;
                }
                gb = new GitUserViewModel()
                {
                    gitrepositorymodel = rootObjectList,
                    user = userModel

                };
            }
            return gb;
        }
        private List<GitRepositoryModel> GetPagingSoringResult(GitRepositoryModel[] rootObjects)
        {
            List<GitRepositoryModel> rootObjectList = default(List<GitRepositoryModel>);
            rootObjectList = (from s in rootObjects
                              orderby s.stargazers_count descending
                              select s).ToList().Skip(0).Take(5).ToList();

            return rootObjectList;

        }
        private async Task<User> GetUser(string login)
        {
            try
            {


                User userModel = default(User);
                string userUrl = "https://api.github.com/users/" + login;
                IHttpClientHelper<User> helperUser = new HttpClientHelper<User>();
                userModel = await helperUser.GetSingleItemRequest(userUrl);
                return userModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<GitRepositoryModel[]> GetUserRepos(string login)
        {
            GitRepositoryModel[] rootObjects = default(GitRepositoryModel[]);
            string userReposUrl = "https://api.github.com/users/" + login + "/repos";
            IHttpClientHelper<GitRepositoryModel> helperRootObject = new HttpClientHelper<GitRepositoryModel>();
            rootObjects = await helperRootObject.GetMultipleItemsRequest(userReposUrl);
            return rootObjects;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GitUserRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}