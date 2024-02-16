namespace s21_d01
{
    public class CustomerExtensions 
    {
        public static CashRegister? FewCustomers(List<CashRegister> CashRegisters)
        {
            if (CashRegisters == null || CashRegisters.Count == 0)
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

        public static CashRegister? FewItems(List<CashRegister> CashRegisters)
        {
            if (CashRegisters == null || CashRegisters.Count == 0)
            {
                return null;
            }
            CashRegister FewItems = CashRegisters[0];
            for(int i = 0; i < CashRegisters.Count; i++)
            {
                if (FewItems.ItemsCount > CashRegisters[i].ItemsCount)
                {
                    FewItems = CashRegisters[i];
                }
            }
            return FewItems;
        }
    }
}
