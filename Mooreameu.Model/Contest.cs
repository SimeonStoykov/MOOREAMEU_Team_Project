using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class Contest
    {
        public Contest()
        {
            this.Pictures = new HashSet<Picture>();
            this.Participants = new HashSet<User>();
            this.Comittee = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public ContestStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? RewardId { get; set; }

        public virtual Reward Reward { get; set; }

        public DeadlineStrategy DeadLine { get; set; }

        public VotingStrategy Voting { get; set; }

        public ParticipationStrategy Participation { get; set; }

        ICollection<Picture> Pictures { get; set; }

        ICollection<User> Participants { get; set; }

        ICollection<User> Comittee { get; set; } 
    }
}
