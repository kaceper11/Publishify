using System;
using System.Collections.Generic;
using System.Text;
using PublishifyContext;
using PublishifyContext.Entity;

namespace Publishify.Models
{
    public class PublishModel
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public string Username { get; set; }

        public DateTime PublishDate { get; set; }

        public string BuildName { get; set; }

        public DateTime BuildStartDate { get; set; }
    }
}
