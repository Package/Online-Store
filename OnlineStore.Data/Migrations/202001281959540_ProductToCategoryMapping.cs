namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductToCategoryMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Product_Id", "dbo.Products");
            DropIndex("dbo.Categories", new[] { "Product_Id" });
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
            DropColumn("dbo.Categories", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Product_Id", c => c.Int());
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            DropTable("dbo.ProductCategories");
            CreateIndex("dbo.Categories", "Product_Id");
            AddForeignKey("dbo.Categories", "Product_Id", "dbo.Products", "Id");
        }
    }
}
