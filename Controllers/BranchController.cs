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
            this.publishifyContext.Branch.Add(new Branch()
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
            var branch = this.publishifyContext.Branch.SingleOrDefault(b => b.Id == branchModel.Id);
            this.MapBranchModel(branch, branchModel);
            this.publishifyContext.SaveChanges();
        }

        [HttpDelete("deleteBranch")]
        public bool DeleteBranch(Branch branch)
        {
            if (CanBranchBeRemoved(branch))
            {
                this.publishifyContext.Branch.Remove(branch);
                this.publishifyContext.SaveChanges();
                return true;
            }

            return false;
        }


        [HttpGet("getCurrentBranchesInfo")]
        public IEnumerable<CurrentBranchInfoModel> GetCurrentBranchesInfo()
        {
            return (from b in this.publishifyContext.Branch
                join p in this.publishifyContext.Publish on b.Id equals p.BranchId
                join u in this.publishifyContext.User on p.UserId equals u.Id        
                select new CurrentBranchInfoModel()
                {
                    CurrentBuild = p.BuildName,
                    BranchLink = b.BranchLink,
                    BranchVersion = b.BranchVersion,
                    BranchName = b.BranchName,
                    PublishedBy = u.Name,
                    LastPublishDate = this.publishifyContext.Publish.OrderByDescending(d => d.PublishDate)
                        .FirstOrDefault(x => x.BranchId == b.Id).PublishDate                       
                }).ToList();
        }

        [HttpGet("getPublishHistory")]
        public IEnumerable<PublishModel> GetPublishHistory(int branchId)
        {
            return (from b in this.publishifyContext.Branch
                join p in this.publishifyContext.Publish on b.Id equals p.BranchId
                join u in this.publishifyContext.User on p.UserId equals u.Id
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
