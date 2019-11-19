namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ind : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            AlterColumn("dbo.Clients", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "LastName", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "FirstName", c => c.Int(nullable: false));
        }
    }
}
