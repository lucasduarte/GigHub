using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Mvc.Models
{
    public class Following
    {
        [StringLength(450)]
        public string FollowerId { get; set; }

        [StringLength(450)]
        public string FolloweeId { get; set; }

        public virtual ApplicationUser Follower { get; set; }
        public virtual ApplicationUser Followee { get; set; }
    }
}
