namespace dcisharp.Experiments.Mapping
{
    public class AccountNumber
    {
        public AccountNumber(string number)
        {
            Number = number;
        }

        public override bool Equals(object obj)
        {
            var that = obj as AccountNumber;

            if (that == null) return false;

            return Number == that.Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return Number;
        }

        private string Number { get; set; }
    }
}