namespace RentABook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookRenter", c => c.String());
            AddColumn("dbo.Books", "BookReturnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "BookBorrowDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "BookComment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookComment", c => c.String());
            DropColumn("dbo.Books", "BookBorrowDate");
            DropColumn("dbo.Books", "BookReturnDate");
            DropColumn("dbo.Books", "BookRenter");
        }
    }
}
