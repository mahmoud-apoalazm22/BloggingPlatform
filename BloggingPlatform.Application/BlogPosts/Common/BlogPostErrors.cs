using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace BloggingPlatform.Application.BlogPosts.Common;
public static  class BlogPostErrors
{
    public static readonly Error BlogPostNotFound = Error.NotFound(
    code: "BlogPost.NotFound",
    description: "The blog post was not found.");

    public static readonly Error NotAllowed = Error.Forbidden(
    code: "BlogPost.Forbidden",
    description: "You are not allowed to perform this action."
);
}
