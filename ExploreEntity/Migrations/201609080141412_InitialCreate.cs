namespace ExploreEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Habitat = c.String(),
                        Species = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}
