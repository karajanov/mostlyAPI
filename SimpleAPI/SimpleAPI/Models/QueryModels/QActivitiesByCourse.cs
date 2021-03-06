﻿using SimpleAPI.Models.Enums;
using System;

namespace SimpleAPI.Models.QueryModels
{
    public class QActivitiesByCourse
    {
        public string CourseName { get; set; }
        public DateTime? DatePresented { get; set; }
        public EActivityType? ActivityType { get; set; }
    }
}
