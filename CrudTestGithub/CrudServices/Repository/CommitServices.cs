using CrudDatabase;
using CrudDatabase.tblCommit;
using CrudServices.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudServices.Repository
{
    public class CommitServices : ICommitServices
    {
        readonly DatabaseContext _context;
        public CommitServices(DatabaseContext context)
        {
            _context = context;
        }
        public List<tblGitCommitInfo> GetAll()
        {
            List < tblGitCommitInfo > data = new List<tblGitCommitInfo>();
            try
            {
                data = _context.Set<tblGitCommitInfo>().ToList();
                return data;

            }catch (Exception ex)
            {
                throw;
            }
        }
        public tblGitCommitInfo Get(int id)
        {
            tblGitCommitInfo data = new tblGitCommitInfo();
            try
            {
                data = _context.GitCommitTable.Where<tblGitCommitInfo>(x => x.Id == id).FirstOrDefault();
                return data;
            }catch (Exception ex)
            {
                throw;
            }
        }
        public string ModifyCommitData(tblGitCommitInfo data)
        {
            string response = "Error Data";
            tblGitCommitInfo resultData = new tblGitCommitInfo();
            try
            {
                resultData = _context.GitCommitTable.Where<tblGitCommitInfo>(x => x.Id == data.Id).FirstOrDefault();
                if(data != null)
                {
                    data.Id = data.Id;
                    data.CommitName = data.CommitName;
                    _context.Update<tblGitCommitInfo>(data);
                    response = "Updated Successfully";
                }
                else
                {
                    _context.Add<tblGitCommitInfo>(data);
                    response = "Inserted Successfully";
                }
                _context.SaveChanges();
                return response;
            }
            catch (Exception ex) 
            {
                throw;
            }

        }
        public bool RemoveCommit(int id)
        {
            tblGitCommitInfo data = new tblGitCommitInfo();
            try
            {
                data = _context.GitCommitTable.Where<tblGitCommitInfo>(x => x.Id == id).FirstOrDefault();
                if(data != null )
                {
                    _context.Remove(data);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
