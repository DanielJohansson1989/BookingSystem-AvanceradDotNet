using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingsystemModels
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        [Required]
        public ChangeType ChangeType { get; set; }
        [Required]
        public DateTime ChangeTime { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        public DateTime? OldValueAppointmentStart { get; set; }
        public DateTime? OldValueAppointmentEnd { get; set; }
        public int? OldValueCustomerId { get; set; }
        public int? OldValueCompanyId { get; set; }
        public DateTime? NewValueAppointmentStart { get; set; }
        public DateTime? NewValueAppointmentEnd { get; set; }
        public int? NewValueCustomerId { get; set; }
        public int? NewValueCompanyId { get; set; }
    }
}
