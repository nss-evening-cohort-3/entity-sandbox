namespace ExploreEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            /*
                PrimaryKey(t => t.CitationStyleId) 
                Really means....

                int GetCitationId(CitationStyle t) {
                    return t.CitationStyleId;
                }

                PrimaryKey(GetCitationId(new CitationStyle()));

             */
            CreateTable(
                "dbo.CitationStyles",
                c => new
                    {
                        CitationStyleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CitationStyleId);
            
            CreateTable(
                "dbo.PublishedWorks",
                c => new
                    {
                        PublishedWorkId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DatePublished = c.DateTime(nullable: false),
                        Citation_CitationStyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublishedWorkId)
                .ForeignKey("dbo.CitationStyles", t => t.Citation_CitationStyleId, cascadeDelete: true)
                .Index(t => t.Citation_CitationStyleId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PublishedWork_PublishedWorkId = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.PublishedWorks", t => t.PublishedWork_PublishedWorkId)
                .Index(t => t.PublishedWork_PublishedWorkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublishedWorks", "Citation_CitationStyleId", "dbo.CitationStyles");
            DropForeignKey("dbo.Authors", "PublishedWork_PublishedWorkId", "dbo.PublishedWorks");
            DropIndex("dbo.Authors", new[] { "PublishedWork_PublishedWorkId" });
            DropIndex("dbo.PublishedWorks", new[] { "Citation_CitationStyleId" });
            DropTable("dbo.Authors");
            DropTable("dbo.PublishedWorks");
            DropTable("dbo.CitationStyles");
        }
    }
}
