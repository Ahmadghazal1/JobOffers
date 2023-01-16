namespace JobsOffers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoundMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catrgories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatrgoryName = c.String(nullable: false),
                        CategoryDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Catrgories");
        }
    }
}
