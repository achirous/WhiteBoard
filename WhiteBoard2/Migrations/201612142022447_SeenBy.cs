namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeenBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Post_PostId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Post_PostId");
            AddForeignKey("dbo.AspNetUsers", "Post_PostId", "dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.AspNetUsers", new[] { "Post_PostId" });
            DropColumn("dbo.AspNetUsers", "Post_PostId");
        }
    }
}
