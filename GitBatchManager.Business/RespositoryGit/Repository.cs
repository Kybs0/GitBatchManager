using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitBatchManager.Business
{
    /// <summary>
    /// 代码仓库项
    /// </summary>
    [DataContract]
    public class Repository
    {
        [DataMember]
        public string RepositoryUri { get; set; }
        public Repository()
        {
           
        }
        public Repository(string repositoryUri)
        {
            RepositoryUri = repositoryUri;
            RepositoryName = RepositoryNameRegex.Match(repositoryUri).Value;
        }

        private static readonly Regex RepositoryNameRegex = new Regex(@"(?<=/)[0-9a-zA-Z.]+(?=.git)");
        [DataMember]
        public string RepositoryName { get; set; }
    }
}
