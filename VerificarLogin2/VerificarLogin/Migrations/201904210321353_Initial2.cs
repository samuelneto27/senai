namespace VerificarLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medico", "Telefone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medico", "Telefone");
        }
    }
}
