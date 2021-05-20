namespace WebClinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Especialidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "Especialidad", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicos", "Especialidad");
        }
    }
}
