﻿using System;

namespace APIClient.AQ1.Model
{
    public class MetricByZone
    {
        public string zone { get; set; }
        public DateTime? time { get; set; }
        public decimal? value { get; set; }
    }
}
