using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Application.Comments.Common;
public record CommentResult(Guid BlogPostId,Guid CommenterId, string CommenterName, string CommenterEmail, string Connent ,DateTime CreatedAt);
