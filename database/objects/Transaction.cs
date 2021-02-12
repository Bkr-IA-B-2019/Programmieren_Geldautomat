using System;

namespace Geldautomat.database.objects
{
    class Transaction
    {
        public int Id { get; private set; }

        /// <summary>
        /// How many money got transfered
        /// </summary>
        public decimal TranslatedMoney { get; private set; }

        /// <summary>
        /// If the money got added (false) or subtracted (true) from the account
        /// </summary>
        public bool Subtracted { get; private set; }

        /// <summary>
        /// THe id for the account that processed the transaction
        /// </summary>
        public int AccountId { get; private set; }

        /// <summary>
        /// The date and time of the transaction
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets used when the database instanciates the transaction
        /// </summary>
        public Transaction(int id,decimal translatedMoney, bool subtracted, int accountId, DateTime dateTime)
        {
            this.Id = id;
            this.TranslatedMoney = translatedMoney;
            this.Subtracted = subtracted;
            this.AccountId = accountId;
            this.DateTime = dateTime;
        }

        /// <summary>
        /// Gets used when a new transaction should be created.
        /// This class does not modifie the account instance and as such does not subtract or add the money to the account
        /// </summary>
        public Transaction(decimal translatedMoney,bool subtracted,Account account)
        {
            this.TranslatedMoney = translatedMoney;
            this.Subtracted = subtracted;
            this.Id = account.Id;
            this.DateTime = DateTime.Now;
        }

        /// <summary>
        /// Used to convert an pseudotransaction into a real one
        /// </summary>
        public Transaction(int id,Transaction pseudoTransaction)
        {
            this.Id = id;
            this.Subtracted = pseudoTransaction.Subtracted;
            this.TranslatedMoney = pseudoTransaction.TranslatedMoney;
            this.DateTime = pseudoTransaction.DateTime;
            this.AccountId = pseudoTransaction.AccountId;
        }
    }
}
