using System;

namespace Domain.SharedKernel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}