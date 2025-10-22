using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Booking
{
    public class Booking
    {
        public int Id { get; init; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreationDate { get; set; }

        public Booking(DateTime startTime, DateTime endTime, string approvalStatus, DateTime creationDate)
        {
            StartTime = startTime;
            EndTime = endTime;
            ApprovalStatus = approvalStatus;
            CreationDate = creationDate;
        }
    }
}
