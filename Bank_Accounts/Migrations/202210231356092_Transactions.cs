namespace Bank_Accounts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        TransactionMode = c.String(),
                        accountNumber = c.Int(nullable: false),
                        EmployeeIdIfAtBankTransaction = c.String(),
                        Amount = c.Int(nullable: false),
                        DateTime = c.String(),
                        DebitOrCredit = c.String(),
                        PreviousBalance = c.Int(nullable: false),
                        UpdatedBalance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionHistories");
        }
    }
}
