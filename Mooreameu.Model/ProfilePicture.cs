using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class ProfilePicture
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Path { get; set; }

        public User Owner { get; set; }
    }
}
