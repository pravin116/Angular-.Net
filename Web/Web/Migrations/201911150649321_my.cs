namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAddresses",
                c => new
                    {
                        AId = c.Int(nullable: false, identity: true),
                        Clientid = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.AId)
                .ForeignKey("dbo.Clients", t => t.Clientid, cascadeDelete: true)
                .Index(t => t.Clientid);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.Int(nullable: false),
                        LastName = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientAddresses", "Clientid", "dbo.Clients");
            DropIndex("dbo.ClientAddresses", new[] { "Clientid" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAddresses");
        }
    }
}
