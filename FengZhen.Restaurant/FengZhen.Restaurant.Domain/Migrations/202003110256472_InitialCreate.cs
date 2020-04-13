namespace FengZhen.Restaurant.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
        }
    }
}
