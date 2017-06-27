namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPostName3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ViewedPosts", name: "ViewedByUsers_Id", newName: "ViewedByUser_Id");
            RenameIndex(table: "dbo.ViewedPosts", name: "IX_ViewedByUsers_Id", newName: "IX_ViewedByUser_Id");
            AddColumn("dbo.ViewedPosts", "ViewedByName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ViewedPosts", "ViewedByName");
            RenameIndex(table: "dbo.ViewedPosts", name: "IX_ViewedByUser_Id", newName: "IX_ViewedByUsers_Id");
            RenameColumn(table: "dbo.ViewedPosts", name: "ViewedByUser_Id", newName: "ViewedByUsers_Id");
        }
    }
}
