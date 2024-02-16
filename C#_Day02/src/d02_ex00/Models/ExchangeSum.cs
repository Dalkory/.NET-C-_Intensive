using System.Globalization;

namespace s21_d02_Models
{
    public struct ExchangeSum
    {
        public string CurrencyCode;
        public decimal Amount;
        private const string Separator = " ";

        public ExchangeSum(string currencyCode, decimal amount)
        {
            CurrencyCode = currencyCode;
            Amount = amount;
        }

        public static bool TryParse(string? input, out ExchangeSum exchangeSum)
        {
            var style = NumberStyles.AllowDecimalPoint;
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            exchangeSum = new ExchangeSum();
            string[] parts = input.Split(Separator);
            if (parts.Length != 2)
                return false;
            if (!decimal.TryParse(parts[0], style, cultureInfo, out exchangeSum.Amount))
                return false;
            exchangeSum.CurrencyCode = parts[1];
            return true;
        }

        public override string ToString()
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            return $"{Amount.ToString("N2", cultureInfo)} {CurrencyCode}";
        }
    }
}