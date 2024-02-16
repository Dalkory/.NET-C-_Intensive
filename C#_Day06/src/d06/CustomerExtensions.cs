namespace s21_d06
{
    public class CustomerExtensions
    {
        public static bool FewCustomers(CashRegister CashRegister1, CashRegister CashRegister2)
        {
            if (CashRegister1.CustomersCount < CashRegister2.CustomersCount)
            {
                return true;
            }
            return false;
        }

        public static bool FewItems(CashRegister CashRegister1, CashRegister CashRegister2)
        {
            if (CashRegister1.ItemsCount < CashRegister2.ItemsCount)
            {
                return true;
            }
            return false;
        }
    }
}
