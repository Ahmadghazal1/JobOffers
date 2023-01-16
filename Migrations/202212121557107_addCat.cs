namespace JobsOffers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Catrgory_Id", "dbo.Catrgories");
            DropIndex("dbo.Jobs", new[] { "Catrgory_Id" });
            DropColumn("dbo.Jobs", "CategoryId");
            RenameColumn(table: "dbo.Jobs", name: "Catrgory_Id", newName: "CategoryId");
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Catrgories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Catrgories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "CategoryId", newName: "Catrgory_Id");
            AddColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "Catrgory_Id");
            AddForeignKey("dbo.Jobs", "Catrgory_Id", "dbo.Catrgories", "Id");
        }
    }
}
