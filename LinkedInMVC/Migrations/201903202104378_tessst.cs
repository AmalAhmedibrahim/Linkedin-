namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tessst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        Logo = c.String(),
                        Cover = c.String(),
                        Type = c.String(),
                        Industry = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Company", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.User_Company", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.User_Company", new[] { "Company_Id" });
            DropIndex("dbo.User_Company", new[] { "ApplicationUser_Id" });
            DropTable("dbo.User_Company");
            DropTable("dbo.Company");
        }
    }
}
