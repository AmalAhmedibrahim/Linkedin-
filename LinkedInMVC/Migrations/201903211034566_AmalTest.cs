namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmalTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Company = c.String(),
                        Location = c.String(),
                        FromYear = c.Int(nullable: false),
                        ToYear = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEducation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Education_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Education", t => t.Education_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Education_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.UserExperience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Experience_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experience", t => t.Experience_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Experience_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExperience", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserExperience", "Experience_Id", "dbo.Experience");
            DropForeignKey("dbo.UserEducation", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEducation", "Education_Id", "dbo.Education");
            DropIndex("dbo.UserExperience", new[] { "UserId_Id" });
            DropIndex("dbo.UserExperience", new[] { "Experience_Id" });
            DropIndex("dbo.UserEducation", new[] { "UserId_Id" });
            DropIndex("dbo.UserEducation", new[] { "Education_Id" });
            DropTable("dbo.UserExperience");
            DropTable("dbo.UserEducation");
            DropTable("dbo.Experience");
        }
    }
}
