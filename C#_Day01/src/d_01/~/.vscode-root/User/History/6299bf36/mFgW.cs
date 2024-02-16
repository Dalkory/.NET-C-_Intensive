namespace s21_d01
{
    public class CustomerExtensions 
    {
        public static CashRegister FewCustomers(List<CashRegister> CashRegisters)
        {
            if (CashRegisters = null || CashRegisters.Count == 0)
            {
                return null;
            }
            CashRegister FewCustomers = CashRegisters[0];
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
            if (CashRegisters = null || CashRegisters.Count == 0)
            {
                return null;
            }
            CashRegister ManyItems = CashRegisters[0];
            for(int i = 0; i < CashRegisters.Count; i++)
            {
                if (ManyItems.ItemsAmount > CashRegisters[i].ItemsAmount)
                {
                    ManyItems = CashRegisters[i];
                }
            }
            return ManyItems;
        }
    }
}