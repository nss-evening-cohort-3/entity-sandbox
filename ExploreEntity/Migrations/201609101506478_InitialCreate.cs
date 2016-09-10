namespace ExploreEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitationStyles",
                c => new
                    {
                        CitationStyleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
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
