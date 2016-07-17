using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Mvc.Models
{
    public class Attendance
    {
        public virtual Gig Gig { get; set; }
        public virtual ApplicationUser Attendee { get; set; }
        
        //[Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public int GigId { get; set; }

        //[Key]
        [Column(Order = 2)]
        [StringLength(450)]
        public string AttendeeId { get; set; }
    }
}
