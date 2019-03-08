using System.Collections.Generic;
using PublishifyContext.Entity;

namespace Publishify.Controllers
{
    public class BranchModel
    {
        public int Id { get; set; }

        public string BranchName { get; set; }

        public string BranchLink { get; set; }

        public string BranchVersion { get; set; }

        public ICollection<Publish> Publishes { get; set; }
    }
}