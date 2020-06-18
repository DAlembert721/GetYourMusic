using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.Media_System
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CommenterId { get;set; }
        public Account Commenter { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}
