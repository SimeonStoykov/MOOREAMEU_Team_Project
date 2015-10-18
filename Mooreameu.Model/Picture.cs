using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int? ContestId { get; set; }

        public virtual Contest Contest { get; set; }

        public DateTime SubmittedOn { get; set; }

        public PictureStatus Status { get; set; }

        public int Votes { get; set; }

        public int Likes { get; set; }
    }
}
