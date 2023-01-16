namespace JobsOffers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addappl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplyForJobs", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "Job_Id" });
            DropColumn("dbo.ApplyForJobs", "JopId");
            RenameColumn(table: "dbo.ApplyForJobs", name: "Job_Id", newName: "JopId");
            AlterColumn("dbo.ApplyForJobs", "JopId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplyForJobs", "JopId");
            AddForeignKey("dbo.ApplyForJobs", "JopId", "dbo.Jobs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "JopId", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "JopId" });
            AlterColumn("dbo.ApplyForJobs", "JopId", c => c.Int());
            RenameColumn(table: "dbo.ApplyForJobs", name: "JopId", newName: "Job_Id");
            AddColumn("dbo.ApplyForJobs", "JopId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplyForJobs", "Job_Id");
            AddForeignKey("dbo.ApplyForJobs", "Job_Id", "dbo.Jobs", "Id");
        }
    }
}
