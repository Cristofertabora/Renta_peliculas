namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualizacion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClientesModel", newName: "Clientes");
            RenameTable(name: "dbo.PeliculasModel", newName: "Peliculas");
            RenameTable(name: "dbo.RentaModel", newName: "Rentas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Rentas", newName: "RentaModel");
            RenameTable(name: "dbo.Peliculas", newName: "PeliculasModel");
            RenameTable(name: "dbo.Clientes", newName: "ClientesModel");
        }
    }
}
