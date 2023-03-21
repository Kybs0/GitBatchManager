using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitBatchManager.Utils;

namespace GitBatchManager.Business
{
    public class RespositoryGitSynchronizer
    {
        private readonly Repository _repository;
        public RespositoryGitSynchronizer(Repository repository)
        {
            _repository = repository;
        }

        public bool CanSync()
        {
            var respositoryFolder = Path.Combine(CustomText.Path.AppRunningFolder, _repository.RepositoryName);
            if (Directory.Exists(respositoryFolder))
            {
                return true;
            }
            return false;
        }

        public async Task SyncAsync(Action<string> showCmdResult)
        {
            var syncCmds = new List<string>();
            var respositoryFolder = Path.Combine(CustomText.Path.AppRunningFolder, _repository.RepositoryName);
            var directoryExist = Directory.Exists(respositoryFolder);
            if (!directoryExist)
            {
                var cloneCmd = $"git clone {_repository.RepositoryUri} {_repository.RepositoryName}";
                syncCmds.Add(cloneCmd);
            }else
            {
                syncCmds.Add($"cd {_repository.RepositoryName}");
                syncCmds.Add("git checkout .");
                syncCmds.Add("git clean - xdf");
                syncCmds.Add("git pull");
            }
            await CmdExecutor.RunAsync(syncCmds, showCmdResult);
        }
    }
}
