namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        Degree = c.String(),
                        FieldOfStudy = c.String(),
                        Grade = c.String(),
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
            
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfileCover", c => c.String());
            AddColumn("dbo.AspNetUsers", "Title", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumOfConnections", c => c.Int(nullable: false));
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
            DropColumn("dbo.AspNetUsers", "NumOfConnections");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Title");
            DropColumn("dbo.AspNetUsers", "ProfileCover");
            DropColumn("dbo.AspNetUsers", "ProfileImage");
            DropTable("dbo.UserExperience");
            DropTable("dbo.Experience");
            DropTable("dbo.UserEducation");
            DropTable("dbo.Education");
        }
    }
}
