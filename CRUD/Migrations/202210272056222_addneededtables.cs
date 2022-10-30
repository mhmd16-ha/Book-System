namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addneededtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 120),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Author = c.String(nullable: false, maxLength: 256),
                        Discription = c.String(nullable: false, maxLength: 2000),
                        CategoryId = c.Byte(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Categories");
        }
    }
}
