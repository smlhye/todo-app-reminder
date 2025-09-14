using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TodoApp.Domain.Common;

namespace TodoApp.Domain.ValueObjects
{
    public class Fullname : ValueObject
    {
        public string Value { get; private set; } = default!;
        private static readonly Regex _fullnamePattern = new Regex(@"^[\p{L} \.\-']{2,100}$", RegexOptions.Compiled);
        public Fullname(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Fullname is required");
            if (!_fullnamePattern.IsMatch(value))
                throw new ArgumentException("Fullname is not valid");
            Value = value.Trim();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override string ToString() => Value;
        public static implicit operator Fullname(string value) => new(value);
        public static implicit operator string(Fullname fullname) => fullname.Value;
    }
}
