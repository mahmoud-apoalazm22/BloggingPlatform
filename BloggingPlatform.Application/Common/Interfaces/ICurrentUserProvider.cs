using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Common.Models;

namespace BloggingPlatform.Application.Common.Interfaces;
public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}
