namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientesModel",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 75),
                        Apellidos = c.String(nullable: false, maxLength: 75),
                        FechaIngreso = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientesModel");
        }
    }
}
