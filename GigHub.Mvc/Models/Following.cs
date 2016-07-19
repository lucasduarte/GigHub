using System.ComponentModel.DataAnnotations;

namespace GigHub.Mvc.Models
{
    public class Following
    {
        public virtual ApplicationUser Follower { get; set; }
        [StringLength(450)]
        public string FollowerId { get; set; }

        public virtual ApplicationUser Followee { get; set; }
        [StringLength(450)]
        public string FolloweeId { get; set; }     
    }
}
