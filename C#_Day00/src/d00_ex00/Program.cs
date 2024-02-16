using System;
using static System.DateTime;
using static System.Math;
using System.Globalization;

double sum, rate;
int term;

if ( args.Length < 3 || !double.TryParse(args[0], out sum) || !double.TryParse(args[1], out rate) || !int.TryParse(args[2], out term) || sum <= 0 || term <= 0)
{
    Console.Error.WriteLine("Something went wrong. Check your input and retry.");
    return;
}

var DateTime = new DateTime(2021, 5, 1);
double InterestRate = rate / 12 / 100;
double Payment = sum * InterestRate * Math.Pow(1 + InterestRate, term) / (Math.Pow(1 + InterestRate, term) - 1);
double RemainingDebt = sum;
double PrincipalDebt;

for (int PaymentNo = 1; PaymentNo <= term; PaymentNo++) 
{
    var PymentDate = DateTime.AddMonths(1);
    double Interest = RemainingDebt * rate * (PymentDate - DateTime).Days / (100 * (DateTime.AddYears(1) - DateTime).Days);
    if(PaymentNo != term){
        PrincipalDebt = Payment - Interest;
        RemainingDebt -= PrincipalDebt;
    } else {
        Payment = RemainingDebt + Interest;
        PrincipalDebt = RemainingDebt;
        RemainingDebt = 0;
    }
    Console.WriteLine($"{PaymentNo}\t{PymentDate.ToString("MM/dd/yyyy")}\t\t{Math.Round(Payment, 2), -10:N2}\t\t{Math.Round(PrincipalDebt, 2), -10:N2}\t\t{Math.Round(Interest, 2), -10:N2}\t\t{Math.Round(RemainingDebt, 2), -10:N2}");
    DateTime = DateTime.AddMonths(1);
}