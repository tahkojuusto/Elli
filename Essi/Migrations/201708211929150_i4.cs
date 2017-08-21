namespace Essi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Requests", new[] { "StudentUser_Id" });
            DropColumn("dbo.Requests", "StudentUserID");
            RenameColumn(table: "dbo.Requests", name: "StudentUser_Id", newName: "StudentUserID");
            AlterColumn("dbo.Requests", "StudentUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Requests", "StudentUserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Requests", new[] { "StudentUserID" });
            AlterColumn("dbo.Requests", "StudentUserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Requests", name: "StudentUserID", newName: "StudentUser_Id");
            AddColumn("dbo.Requests", "StudentUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "StudentUser_Id");
        }
    }
}
