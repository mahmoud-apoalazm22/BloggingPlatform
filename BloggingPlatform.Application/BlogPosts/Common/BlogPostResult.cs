using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Application.BlogPosts.Common;
public record BlogPostResult(Guid Id,Guid UserId, string Title, string Content ,DateTime CreatedDate);
