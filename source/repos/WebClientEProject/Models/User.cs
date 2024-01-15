using System;
using System.Collections.Generic;

namespace WebClient.Models
{
    public partial class User
    {
        public User()
        {
            FriendRequestReceiverNavigations = new HashSet<FriendRequest>();
            FriendRequestSenderNavigations = new HashSet<FriendRequest>();
            MessagerReceiverNavigations = new HashSet<Messager>();
            MessagerSenderNavigations = new HashSet<Messager>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Avata { get; set; }
        public string? Education { get; set; }
        public int? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<FriendRequest> FriendRequestReceiverNavigations { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestSenderNavigations { get; set; }
        public virtual ICollection<Messager> MessagerReceiverNavigations { get; set; }
        public virtual ICollection<Messager> MessagerSenderNavigations { get; set; }
    }
}
