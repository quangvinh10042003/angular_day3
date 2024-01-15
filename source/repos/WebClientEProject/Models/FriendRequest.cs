using System;
using System.Collections.Generic;

namespace WebClient.Models
{
    public partial class FriendRequest
    {
        public int Id { get; set; }
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public bool? Status { get; set; }

        public virtual User? ReceiverNavigation { get; set; }
        public virtual User? SenderNavigation { get; set; }
    }
}
