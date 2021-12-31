using RecordLabel.src.Shared.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordLabel.src.Directory.Artist.Domain
{
    public class Name : ValueObject<String>
    {
        const int MAX_LENGTH = 16;
        public Name(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw InvalidAttributeException.FromEmpty("Name");
            }

            if (value.Length > MAX_LENGTH)
            {
                throw InvalidAttributeException.FromMaxLength("Name", MAX_LENGTH);
            }
        }
    }
}
