namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Specialization = c.String(),
                        LastName = c.String(nullable: false, maxLength: 15),
                        FirstName = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Educators");
        }
    }
}
