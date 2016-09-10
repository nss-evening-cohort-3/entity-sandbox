namespace ExploreEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPenNameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "PenName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "PenName");
        }
    }
}
