using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublishifyContext.Entity;
using Publishify.Models;

namespace Publishify.Controllers
{
    [Route("api/[controller]")]
    public class BranchController : Controller
    {
        private readonly PublishifyContext.PublishifyContext publishifyContext;

        public BranchController(PublishifyContext.PublishifyContext publishifyContext)
        {
            this.publishifyContext = publishifyContext;
        }


        [HttpPost("createBranch")]
        public void CreateBranch(BranchModel branch)
        {
            this.publishifyContext.Branches.Add(new Branch()
            {
                Id = branch.Id,
                BranchName = branch.BranchName,
                BranchVersion = branch.BranchVersion,
                BranchLink = branch.BranchLink,
                Publishes = branch.Publishes
            });
            this.publishifyContext.SaveChanges();
        }

        [HttpPut("editBranch")]
        public void EditBranch(BranchModel branchModel)
        {
            var branch = this.publishifyContext.Branches.SingleOrDefault(b => b.Id == branchModel.Id);
            this.MapBranchModel(branch, branchModel);
            this.publishifyContext.SaveChanges();
        }

        [HttpDelete("deleteBranch")]
        public bool DeleteBranch(Branch branch)
        {
            if (CanBranchBeRemoved(branch))
            {
                this.publishifyContext.Branches.Remove(branch);
                this.publishifyContext.SaveChanges();
                return true;
            }

            return false;
        }

        [HttpGet("getBranches")]
        public IEnumerable<BranchModel> GetBranches()
        {
            return this.publishifyContext.Branches.Select(b => new BranchModel()
            {
                Id = b.Id,
                BranchName = b.BranchName
            }).OrderBy(n => n.BranchName).ToList();
        }

        [HttpGet("getPublishHistory")]
        public IEnumerable<PublishModel> GetPublishHistory(int branchId)
        {
            return (from b in this.publishifyContext.Branches
                join p in this.publishifyContext.Publishes on b.Id equals p.BranchId
                join u in this.publishifyContext.Users on p.UserId equals u.Id
                    where b.Id == branchId
                    select new PublishModel()
                {
                    BuildName = p.BuildName,
                    Username = u.Name,
                    BuildStartDate = p.BuildStartDate,
                    PublishDate = p.PublishDate
                }).ToList();
        }

        private void MapBranchModel(Branch branch, BranchModel model)
        {
            branch.BranchVersion = model.BranchVersion;
            branch.BranchName = model.BranchName;
            branch.BranchLink = model.BranchLink; 
        }

        private bool CanBranchBeRemoved(Branch branch)
        {
            return !branch.Publishes.Any();
        }
    }
}
