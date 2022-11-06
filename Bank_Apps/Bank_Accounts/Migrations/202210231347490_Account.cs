namespace Bank_Accounts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IFSC = c.String(),
                        AccountSummary = c.String(),
                        AadharNumber = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.AccountNumber);
        }
        
        public override void Down()
        {   
            DropTable("dbo.Accounts");
        }
    }
}
