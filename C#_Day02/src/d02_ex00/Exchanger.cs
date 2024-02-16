using s21_d02_Models;

namespace s21_d02_ex00
{
    public class Exchanger
    {
        private List<ExchangeRate> _exchangeRates;
        
        public Exchanger(string ratesPath)
        {
            var rateFiles = Directory.GetFiles(ratesPath);
            _exchangeRates = new List<ExchangeRate>();
            foreach (var file in rateFiles)
            {
                string[] rateLines = File.ReadAllLines(file);
                foreach (var rateLine in rateLines)
                {
                    var rateText = $"{Path.GetFileNameWithoutExtension(file)}-{rateLine}";
                    if (ExchangeRate.TryParse(rateText, out var exchangeRate))
                        _exchangeRates.Add(exchangeRate);
                }
            }
        }

        public IEnumerable<ExchangeSum> Convert(ExchangeSum originalSum)
        {
            foreach (var exchangeRate in _exchangeRates)
            {
                if (exchangeRate.FromCurrency != originalSum.CurrencyCode)
                    continue;
                var convertedAmount = (decimal)originalSum.Amount * (decimal)exchangeRate.Rate;
                yield return new ExchangeSum(exchangeRate.ToCurrency, convertedAmount);
            }
        }
    }
}