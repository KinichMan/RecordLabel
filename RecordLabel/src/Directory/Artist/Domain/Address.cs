using RecordLabel.src.Shared.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using System;

namespace RecordLabel.src.Directory.Artist.Domain
{
    public class Address : ValueObject<String>
    {
        const int MAX_LENGTH = 16;
        public Address(string value) : base(value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw InvalidAttributeException.FromEmpty("Address");
            }
            if(value.Length > MAX_LENGTH)
            {
                throw InvalidAttributeException.FromMaxLength("Address", MAX_LENGTH);
            }
        }
    }
}
