﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LinkStorage.Models
{
    [Table("Users_Table")]
    public class User : IdentityUser
    {
        public long PublicPostCount { get; set; }
        public long FollowersCount { get; set; } 
        public long FollowingsCount { get; set; } 
        
        public ICollection<Links>? LinksCollection { get; } = new List<Links>();
        
        public virtual ICollection<Follows> Followers { get; set; }
        public virtual ICollection<Follows> Following { get; set; }
        
    }
}
