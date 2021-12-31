using RecordLabel.src.Shared.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using System;

namespace RecordLabel.src.Directory.Artist.Domain
{
    public class ContactNumber : ValueObject<Int64>
    {
        const int MAX_LENGTH = 10;
        const int MIN_LENGTH = 6;
        const int CERO = 0;
        public ContactNumber(Int64 value) : base(value)
        {
            if (value < CERO)
            {
                throw InvalidAttributeException.FromValue("Contact Number", "Negative");
            }

            if(value.ToString().Length < MIN_LENGTH)
            {
                throw InvalidAttributeException.FromMinLength("Contact Number", MIN_LENGTH);
            }

            if(value.ToString().Length > MAX_LENGTH)
            {
                throw InvalidAttributeException.FromMaxLength("Contact Number", MAX_LENGTH);
            }

        }
    }
}
