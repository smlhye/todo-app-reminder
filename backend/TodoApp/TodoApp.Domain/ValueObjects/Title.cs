using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Common;

namespace TodoApp.Domain.ValueObjects
{
    public class Title : ValueObject
    {
        public string Value { get; private set; } = default!;
        private Title() { }
        public Title(string value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value), "Title is required");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Title cannot be empty or whitespace", nameof(value));
            if (value.Length > 100) throw new ArgumentException("Title is too long, maximum 100 characters", nameof(value));
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override string ToString() => Value;
        public static implicit operator Title(string value) => new(value);
        public static implicit operator string(Title title) => title.Value;
    }
}
