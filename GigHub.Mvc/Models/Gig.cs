﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Mvc.Models
{
    public class Gig
    {
        public int Id { get; set; }
        
        public virtual ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
      
        public virtual Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}
