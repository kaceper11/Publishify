using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Publishify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : Controller
    {
        private readonly PublishifyContext.PublishifyContext publishifyContext;

        public PublishController(PublishifyContext.PublishifyContext publishifyContext)
        {
            this.publishifyContext = publishifyContext;
        }

        [HttpGet("getBranches")]
        public IEnumerable<BranchModel> GetBranches()
        {
            return this.publishifyContext.Branch.Select(b => new BranchModel()
            {
                Id = b.Id,
                BranchName = b.BranchName
            }).OrderBy(n => n.BranchName).ToList();
        }
    }
}
