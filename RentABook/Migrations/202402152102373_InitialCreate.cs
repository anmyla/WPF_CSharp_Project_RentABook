namespace RentABook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: true, identity: true),
                        BookTitle = c.String(),
                        BookAuthor = c.String(),
                        BookYear = c.String(),
                        BookComment = c.String(),
                        BookRating = c.Int(nullable: true),
                        IsAvailable = c.Boolean(nullable: true),
                        BookCover = c.String(),
                        BookRentPrice = c.Double(nullable: true),
                        BookGenre_GenreId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Genres", t => t.BookGenre_GenreId)
                .Index(t => t.BookGenre_GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        GenreIconPath = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookGenre_GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "BookGenre_GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
