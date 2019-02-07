using System.Threading.Tasks;
using Fuzion.API.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fuzion.API.Controllers
{
    [Route("api/assignmenthistory")]
    [ApiController]
    public class AssignmentHistoryController : Controller
    {
        private IUnitOfWork _uow;

        public AssignmentHistoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAssignmentHistoryForHardware(int id)
        {
            var assignmentHistory = await _uow.AssignmentHistory.GetAssignmentHistoryForHardware(id);
            return Ok(assignmentHistory);
        }
    }
}