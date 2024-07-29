﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Domain.Common;
public class Entity
{
    public Guid Id { get; init; }

    protected Entity(Guid id) => Id = id;


    protected Entity()
    {
    }
}
