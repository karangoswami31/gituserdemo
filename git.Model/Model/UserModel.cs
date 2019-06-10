using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace git.Model.Model
{
    public class User
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public int public_repos { get; set; }
    }

    public class GitUserViewModel
    {
        public User user { get; set; }
        public IEnumerable<GitRepositoryModel> gitrepositorymodel { get; set; }
    }
}
