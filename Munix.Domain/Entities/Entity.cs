﻿using FluentValidator;
using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Entities
{
    public class Entity : Notifiable, IEntity
    {
        public Guid Id { get; protected set; }
    }
}
