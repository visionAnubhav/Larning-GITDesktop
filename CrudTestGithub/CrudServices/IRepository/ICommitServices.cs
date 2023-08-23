using CrudDatabase.tblCommit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudServices.IRepository
{
    public interface ICommitServices
    {
        List<tblGitCommitInfo> GetAll();
        tblGitCommitInfo Get(int id);
        string ModifyCommitData(tblGitCommitInfo data);
        bool RemoveCommit(int id);
    }
}
