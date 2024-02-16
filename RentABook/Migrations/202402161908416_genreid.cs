namespace RentABook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "BookGenre_GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "BookGenre_GenreId" });
            AddColumn("dbo.Books", "BookGenre_GenreId1", c => c.Int());
            AlterColumn("dbo.Books", "BookGenre_GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "BookGenre_GenreId1");
            AddForeignKey("dbo.Books", "BookGenre_GenreId1", "dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookGenre_GenreId1", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "BookGenre_GenreId1" });
            AlterColumn("dbo.Books", "BookGenre_GenreId", c => c.Int());
            DropColumn("dbo.Books", "BookGenre_GenreId1");
            CreateIndex("dbo.Books", "BookGenre_GenreId");
            AddForeignKey("dbo.Books", "BookGenre_GenreId", "dbo.Genres", "GenreId");
        }
    }
}
