namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whiteboard8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
        }
    }
}
