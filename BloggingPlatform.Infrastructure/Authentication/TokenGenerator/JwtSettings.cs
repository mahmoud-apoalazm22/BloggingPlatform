﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Infrastructure.Authentication.TokenGenerator;
public class JwtSettings
{
    public const string Section = "JwtSettings";

    public string Audience { get; set; } 
    public string Issuer { get; set; } 
    public string Secret { get; set; } 
    public int TokenExpirationInMinutes { get; set; }
}
