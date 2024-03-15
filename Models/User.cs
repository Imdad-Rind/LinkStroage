﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LinkStorage.Models
{
    [Table("Users_Table")]
    public class User : IdentityUser
    {
        public Int64 PublicPostCount { get; set; } = 0;
        public Int64 FollowersCount { get; set; } = 0;
        public Int64 FollowingsCount { get; set; } = 0;
        
        public ICollection<Links>? LinksCollection { get; } = new List<Links>();
        
        public virtual ICollection<Follows> Followers { get; set; }
        public virtual ICollection<Follows> Following { get; set; }
    }
}
