using CrudDatabase.tblCommit;
using CrudServices.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitController : ControllerBase
    {
        readonly ICommitServices _services;
        public CommitController(ICommitServices services)
        {
            _services = services;
        }
        [HttpGet] 
        public IActionResult GetList()
        {
            try
            {
                var data = _services.GetAll();
                return Ok(data);
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("Get-Specific")] 
        public IActionResult GetList(int id)
        {
            try
            {
                var data = _services.Get(id);
                return Ok(data);
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult ModifyCommite(tblGitCommitInfo data)
        {
            try
            {
                var result =_services.ModifyCommitData(data);   
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("Remove-CommitController")]
        public IActionResult RemoveCommit(int id)
        {
            try
            {
                var data =_services.RemoveCommit(id);
                return Ok(data);
            }catch(Exception)
            {
                return NotFound();
            }
        }
    }
}
