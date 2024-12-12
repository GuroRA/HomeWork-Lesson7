using System;

namespace HomeWork_Lesson7_Tymakov
{
    enum AccountType
    {
        currentAccount,
        savingAccount,
    }

    internal class BankAccount
    {
        private static uint accountIdCounter = 1;
        private readonly uint accountId;
        public decimal Balance { private get; set; }

        private readonly AccountType accountType;

        /// <summary>
        /// Принимает баланс и тип аккаунта
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="accountType"></param>
        public BankAccount(decimal balance, AccountType accountType)
        {
            accountId = SetCurrentId();
            Balance = balance;
            this.accountType = accountType;
        }

        /// <summary>
        /// Вычитает из баланса вводимое число
        /// </summary>
        /// <param name="amount"></param>
        public decimal WithdrawMoney(decimal amount)
        {
            if (Balance - amount >= 0 && amount > 0)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств или некорректная сумма для снятия.\n");
            }
            return Balance;
        }

        /// <summary>
        /// Позволяет переводить деньги между акаунтами
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal TransferMoney(BankAccount account, decimal amount)
        {
            if (account.Balance != account.WithdrawMoney(amount))
            {
                DepositMoney(amount);
            }
            return Balance;
        }

        /// <summary>
        /// Прибавляет к балансу вводимое число
        /// </summary>
        /// <param name="amount"></param>
        public decimal DepositMoney(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Сумма для пополнения должна быть положительной.\n");
            }
            return Balance;
        }

        private static uint SetCurrentId()
        {
            return accountIdCounter++;
        }
        public void GetAccountData()
        {
            Console.WriteLine($"ID: {string.Format("{0:D7}", accountId)}\nБаланс: {Balance}\nТип аккаунта: {accountType}\n");
        }
    }
}
