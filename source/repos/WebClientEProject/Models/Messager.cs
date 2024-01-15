using System;
using System.Collections.Generic;

namespace WebClient.Models
{
    public partial class Messager
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Enclose { get; set; }
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? Timestemp { get; set; }

        public virtual User? ReceiverNavigation { get; set; }
        public virtual User? SenderNavigation { get; set; }
    }
}
