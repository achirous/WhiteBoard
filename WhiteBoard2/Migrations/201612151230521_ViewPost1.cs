namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPost1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewedPosts",
                c => new
                    {
                        ViewedPostId = c.Int(nullable: false, identity: true),
                        ViewedByUser_Id = c.String(maxLength: 128),
                        ViewPost_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.ViewedPostId)
                .ForeignKey("dbo.AspNetUsers", t => t.ViewedByUser_Id)
                .ForeignKey("dbo.Posts", t => t.ViewPost_PostId)
                .Index(t => t.ViewedByUser_Id)
                .Index(t => t.ViewPost_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViewedPosts", "ViewPost_PostId", "dbo.Posts");
            DropForeignKey("dbo.ViewedPosts", "ViewedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ViewedPosts", new[] { "ViewPost_PostId" });
            DropIndex("dbo.ViewedPosts", new[] { "ViewedByUser_Id" });
            DropTable("dbo.ViewedPosts");
        }
    }
}
