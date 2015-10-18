using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public NotificationStatus Status { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
