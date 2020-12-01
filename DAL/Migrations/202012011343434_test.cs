namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "IndexNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IndexNumber", c => c.Int(nullable: false));
        }
    }
}
