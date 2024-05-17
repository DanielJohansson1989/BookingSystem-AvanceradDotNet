﻿using BookingsystemModels;
using System.ComponentModel.DataAnnotations;

namespace BookingsystemAPI.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
    }
}
