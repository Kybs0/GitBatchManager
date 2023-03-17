using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitBatchManager.Business;
using GitBatchManager.Utils;

namespace GitBatchManager
{
    public class RepositoryItem : BindingPropertyBase
    {
        public RepositoryItem(Repository repository)
        {
            _repositoryName = repository.RepositoryName;
            _repositoryUri = repository.RepositoryUri;
        }

        public RepositoryItem()
        {

        }
        public Repository GetRepository()
        {
            return new Repository(RepositoryUri);
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string RepositoryName
        {
            get => _repositoryName;
            set
            {
                _repositoryName = value;
                OnPropertyChanged();
            }
        }

        private string _repositoryName = "仓库名";
        /// <summary>
        /// Nuget对应的源代码引用
        /// </summary>
        public string RepositoryUri
        {
            get => _repositoryUri;
            set
            {
                _repositoryUri = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RepositoryName = new Repository(value).RepositoryName;

                }
                OnPropertyChanged();
            }
        }
        private string _repositoryUri;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        private bool _isSelected = true;
    }
}
