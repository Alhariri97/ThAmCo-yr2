﻿namespace ThAmCo.Events.DTO
{
    public class VenueDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime Date { get; set; }

        public float CostPerHour { get; set; }
    }
}
