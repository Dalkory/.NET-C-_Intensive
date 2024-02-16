namespace s21_d02_Models
{
    public struct ExchangeRate
    {
        public string FromCurrency;
        public string ToCurrency;
        public decimal Rate;
        private const string CurrencySeparator = "-";
        private const string RateSeparator = ":";

        public ExchangeRate(string fromCurrency, string toCurrency, decimal exchangeRate)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Rate = exchangeRate;
        }

        public static bool TryParse(string? input, out ExchangeRate exchangeRate)
        {
            exchangeRate = new ExchangeRate();
            string[] parts = input.Split(RateSeparator);
            if (parts.Length != 2)
                return false;
            if (!decimal.TryParse(parts[1].Replace(',', '.'), out exchangeRate.Rate))
                return false;
                
            string [] currencies = parts[0].Split(CurrencySeparator);
            if (currencies.Length != 2)
                return false;
            exchangeRate.FromCurrency = currencies[0];
            exchangeRate.ToCurrency = currencies[1];
            return true;
        }
        
        public override string ToString()
        {
            return $"{FromCurrency}{CurrencySeparator}{ToCurrency}" +
                   $"{RateSeparator}" +
                   $"{Rate}";
        }
    }
}