namespace Bank_Accounts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankBalanceClasses",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankBalanceClasses");
        }
    }
}
