﻿namespace Crowd_Funding.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Project>? Projects { get; set; }
    }
}
