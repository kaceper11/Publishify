﻿using System;

namespace Publishify.Controllers
{
    public class CurrentBranchInfoModel
    {
        public int Id { get; set; }

        public string BranchName { get; set; }

        public string BranchLink { get; set; }

        public string PublishedBy { get; set; }

        public DateTime LastPublishDate { get; set; }

        public string CurrentBuild { get; set; }

        public string BranchVersion { get; set; }

        public DateTime BuildStartDateTime { get; set; }
    }
}