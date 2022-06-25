
using DDDPractice.Common;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            Value = value;
        }
        public float Value { get; }

        public string DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint) + UnitName;
            }
        }
        public override bool Equals(object obj)
        {
            var vo = obj as Temperature;
            if (vo == null) return false;
            return vo.Value == this.Value;
        }

        protected override bool EqualsCore(Temperature other)
        {
            if(other.Value != this.Value) return false;
            return true;
        }


    }
}
