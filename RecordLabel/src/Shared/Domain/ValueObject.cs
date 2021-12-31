using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordLabel.src.Shared.Domain
{
    public class ValueObject <T>
    {
        public T Value { get; private set; }

        public ValueObject(T value)
        {
            Value = value;
        }
    }
}
