namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_PostId = c.Int(nullable: false),
                        CommentText = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Post", t => t.Fk_PostId, cascadeDelete: true)
                .Index(t => t.Fk_PostId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        postText = c.String(),
                        numOfLikes = c.Int(nullable: false),
                        numOfComments = c.Int(nullable: false),
                        numOfShares = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Post_Shared_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Post", t => t.Post_Shared_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Post_Shared_Id);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_PostId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Post", t => t.Fk_PostId, cascadeDelete: true)
                .Index(t => t.Fk_PostId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "Fk_PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "Post_Shared_Id", "dbo.Post");
            DropForeignKey("dbo.Like", "Fk_PostId", "dbo.Post");
            DropForeignKey("dbo.Like", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Like", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Like", new[] { "Fk_PostId" });
            DropIndex("dbo.Post", new[] { "Post_Shared_Id" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comment", new[] { "Fk_PostId" });
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
