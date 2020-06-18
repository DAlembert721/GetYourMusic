using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class CommentResponse : BaseResponse<Comment>
    {
        public CommentResponse(string message) : base(message) { }
               
        public CommentResponse(Comment comment) : base(comment) { }
    }
}
