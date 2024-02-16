namespace s21_d01
{
    public class CustomerExtensions 
    {
        public static CashRegister FewCustomers(List<CashRegister> CashRegisters)
        {
            if (CashRegisters = null || CashRegisters.Count)
            {
                return null;
            }
            CashRegister FewCustomers = CashRegister[0];
            for(int i = 0; i < CashRegisters.Count; i++)
            {
                if (FewCustomers.CustomersCount > CashRegisters[i].CustomersCount)
                {
                    FewCustomers = CashRegisters[i];
                }
            }
            return FewCustomers;
        }
        public static CashRegister ManyItems(List<CashRegister> CashRegisters)
        {
            if (CashRegisters = null || CashRegisters.Count)
            {
                return null;
            }
            return ManyItems;
        }
    }
}