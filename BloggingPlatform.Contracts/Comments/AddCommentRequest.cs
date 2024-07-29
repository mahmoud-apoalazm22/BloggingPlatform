using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Contracts.Comments;
public record AddCommentRequest(
    string Content
);
