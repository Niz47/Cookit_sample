namespace Cookit_Testing_zmh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeall : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.calories",
                c => new
                    {
                        calorie_id = c.Int(nullable: false, identity: true),
                        calorie_amount = c.Int(),
                    })
                .PrimaryKey(t => t.calorie_id);
            
            CreateTable(
                "dbo.fav_recipe",
                c => new
                    {
                        fav_recipe_id = c.Int(nullable: false, identity: true),
                        userid = c.Int(),
                        recipe_id = c.Int(),
                    })
                .PrimaryKey(t => t.fav_recipe_id)
                .ForeignKey("dbo.recipes", t => t.recipe_id)
                .ForeignKey("dbo.user_list", t => t.userid)
                .Index(t => t.userid)
                .Index(t => t.recipe_id);
            
            CreateTable(
                "dbo.recipes",
                c => new
                    {
                        recipe_id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        recipe_name = c.String(),
                    })
                .PrimaryKey(t => t.recipe_id);
            
            CreateTable(
                "dbo.ingredients",
                c => new
                    {
                        ingredient_id = c.Int(nullable: false, identity: true),
                        recipe_id = c.Int(),
                        ingredient_name = c.String(),
                        ingredient_amount = c.String(),
                    })
                .PrimaryKey(t => t.ingredient_id)
                .ForeignKey("dbo.recipes", t => t.recipe_id)
                .Index(t => t.recipe_id);
            
            CreateTable(
                "dbo.instructions",
                c => new
                    {
                        instruction_id = c.Int(nullable: false, identity: true),
                        recipe_id = c.Int(),
                        instruction_detail = c.String(),
                    })
                .PrimaryKey(t => t.instruction_id)
                .ForeignKey("dbo.recipes", t => t.recipe_id)
                .Index(t => t.recipe_id);
            
            CreateTable(
                "dbo.user_list",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        user_email = c.String(),
                    })
                .PrimaryKey(t => t.userid);
            
            CreateTable(
                "dbo.grocery_list",
                c => new
                    {
                        grocery_id = c.Int(nullable: false, identity: true),
                        userid = c.Int(),
                        grocery_item = c.String(),
                        grocery_amount = c.String(),
                    })
                .PrimaryKey(t => t.grocery_id)
                .ForeignKey("dbo.user_list", t => t.userid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.post_recipe",
                c => new
                    {
                        post_recipe_id = c.Int(nullable: false, identity: true),
                        userid = c.Int(),
                        post_ImageName = c.String(),
                        post_ImagePath = c.String(),
                        post_recipe_name = c.String(),
                    })
                .PrimaryKey(t => t.post_recipe_id)
                .ForeignKey("dbo.user_list", t => t.userid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.post_ingredient",
                c => new
                    {
                        post_ingredient_id = c.Int(nullable: false, identity: true),
                        post_recipe_id = c.Int(),
                        post_ingredient_name = c.String(),
                        post_ingredient_amount = c.String(),
                    })
                .PrimaryKey(t => t.post_ingredient_id)
                .ForeignKey("dbo.post_recipe", t => t.post_recipe_id)
                .Index(t => t.post_recipe_id);
            
            CreateTable(
                "dbo.post_instruction",
                c => new
                    {
                        post_instruction_id = c.Int(nullable: false, identity: true),
                        post_recipe_id = c.Int(),
                        post_instruction_detail = c.String(),
                    })
                .PrimaryKey(t => t.post_instruction_id)
                .ForeignKey("dbo.post_recipe", t => t.post_recipe_id)
                .Index(t => t.post_recipe_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.post_recipe", "userid", "dbo.user_list");
            DropForeignKey("dbo.post_instruction", "post_recipe_id", "dbo.post_recipe");
            DropForeignKey("dbo.post_ingredient", "post_recipe_id", "dbo.post_recipe");
            DropForeignKey("dbo.grocery_list", "userid", "dbo.user_list");
            DropForeignKey("dbo.fav_recipe", "userid", "dbo.user_list");
            DropForeignKey("dbo.instructions", "recipe_id", "dbo.recipes");
            DropForeignKey("dbo.ingredients", "recipe_id", "dbo.recipes");
            DropForeignKey("dbo.fav_recipe", "recipe_id", "dbo.recipes");
            DropIndex("dbo.post_instruction", new[] { "post_recipe_id" });
            DropIndex("dbo.post_ingredient", new[] { "post_recipe_id" });
            DropIndex("dbo.post_recipe", new[] { "userid" });
            DropIndex("dbo.grocery_list", new[] { "userid" });
            DropIndex("dbo.instructions", new[] { "recipe_id" });
            DropIndex("dbo.ingredients", new[] { "recipe_id" });
            DropIndex("dbo.fav_recipe", new[] { "recipe_id" });
            DropIndex("dbo.fav_recipe", new[] { "userid" });
            DropTable("dbo.post_instruction");
            DropTable("dbo.post_ingredient");
            DropTable("dbo.post_recipe");
            DropTable("dbo.grocery_list");
            DropTable("dbo.user_list");
            DropTable("dbo.instructions");
            DropTable("dbo.ingredients");
            DropTable("dbo.recipes");
            DropTable("dbo.fav_recipe");
            DropTable("dbo.calories");
        }
    }
}
