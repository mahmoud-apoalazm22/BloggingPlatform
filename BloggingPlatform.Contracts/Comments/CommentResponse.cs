using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloggingPlatform.Contracts.Comments;
public record CommentResponse(Guid BlogPostId, Guid CommenterId,  string CommenterName, string CommenterEmail, string Content,  DateTime CreatedDate);
