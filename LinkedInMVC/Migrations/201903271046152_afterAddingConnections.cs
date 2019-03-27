namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterAddingConnections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connection_Request",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsApproved = c.Boolean(nullable: false),
                        FK_Connction_UserId_Id = c.String(maxLength: 128),
                        FK_UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FK_Connction_UserId_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FK_UserId_Id)
                .Index(t => t.FK_Connction_UserId_Id)
                .Index(t => t.FK_UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connection_Request", "FK_UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Connection_Request", "FK_Connction_UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Connection_Request", new[] { "FK_UserId_Id" });
            DropIndex("dbo.Connection_Request", new[] { "FK_Connction_UserId_Id" });
            DropTable("dbo.Connection_Request");
        }
    }
}
