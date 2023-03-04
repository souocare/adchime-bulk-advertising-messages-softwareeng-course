namespace AdChimeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedvariablecenas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "optinSMS", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "optinSMS", c => c.Int());
        }
    }
}
