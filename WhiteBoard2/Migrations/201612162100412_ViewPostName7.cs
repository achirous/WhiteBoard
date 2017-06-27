namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPostName7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ViewedPosts", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewedPosts", "Count", c => c.Int(nullable: false));
        }
    }
}
