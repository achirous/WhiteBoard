namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.ViewedPosts", "ViewPost_PostId", "dbo.Posts");
            DropForeignKey("dbo.ViewedPosts", "ViewedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.ViewedPosts", new[] { "ViewedByUser_Id" });
            DropIndex("dbo.ViewedPosts", new[] { "ViewPost_PostId" });
            AlterColumn("dbo.Comments", "CommentName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Post_PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "PostName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Posts", "PostText", c => c.String(nullable: false));
            AlterColumn("dbo.ViewedPosts", "ViewedByName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ViewedPosts", "ViewedByUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ViewedPosts", "ViewPost_PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Post_PostId");
            CreateIndex("dbo.ViewedPosts", "ViewedByUser_Id");
            CreateIndex("dbo.ViewedPosts", "ViewPost_PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.ViewedPosts", "ViewPost_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.ViewedPosts", "ViewedByUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViewedPosts", "ViewedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ViewedPosts", "ViewPost_PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.ViewedPosts", new[] { "ViewPost_PostId" });
            DropIndex("dbo.ViewedPosts", new[] { "ViewedByUser_Id" });
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            AlterColumn("dbo.ViewedPosts", "ViewPost_PostId", c => c.Int());
            AlterColumn("dbo.ViewedPosts", "ViewedByUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ViewedPosts", "ViewedByName", c => c.String());
            AlterColumn("dbo.Posts", "PostText", c => c.String());
            AlterColumn("dbo.Posts", "PostName", c => c.String());
            AlterColumn("dbo.Comments", "Post_PostId", c => c.Int());
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
            AlterColumn("dbo.Comments", "CommentName", c => c.String());
            CreateIndex("dbo.ViewedPosts", "ViewPost_PostId");
            CreateIndex("dbo.ViewedPosts", "ViewedByUser_Id");
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.ViewedPosts", "ViewedByUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ViewedPosts", "ViewPost_PostId", "dbo.Posts", "PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
        }
    }
}
