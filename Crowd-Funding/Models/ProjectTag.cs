﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class ProjectTag
    {
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [ForeignKey("Tag")]
        public int TagID { get; set; }

        public Project? Project { get; set; }
        public Tag? Tag { get; set; }
    }
}
