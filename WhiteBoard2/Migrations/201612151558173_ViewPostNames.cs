namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPostNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ViewedPosts", name: "ViewedByUser_Id", newName: "ViewedByUsers_Id");
            RenameIndex(table: "dbo.ViewedPosts", name: "IX_ViewedByUser_Id", newName: "IX_ViewedByUsers_Id");
            DropColumn("dbo.ViewedPosts", "ViewedPostName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewedPosts", "ViewedPostName", c => c.String());
            RenameIndex(table: "dbo.ViewedPosts", name: "IX_ViewedByUsers_Id", newName: "IX_ViewedByUser_Id");
            RenameColumn(table: "dbo.ViewedPosts", name: "ViewedByUsers_Id", newName: "ViewedByUser_Id");
        }
    }
}
