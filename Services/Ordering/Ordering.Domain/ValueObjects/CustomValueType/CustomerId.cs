﻿namespace Ordering.Domain.ValueObjects.CustomValueType;
public record CustomerId
{
    public Guid Value { get; }
    private CustomerId(Guid value) => Value = value;
    public static CustomerId Of(Guid value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value.ToString());
        if (value == Guid.Empty)
        {
            throw new DomainException("Customer Id can not be empty");

        }
        return new CustomerId(value);
    }
}