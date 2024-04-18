namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaRentas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeliculasModel", "ClasificacionPeliculas_ClasificacionPeliculaId", "dbo.ClasificacionPeliculas");
            DropIndex("dbo.PeliculasModel", new[] { "ClasificacionPeliculas_ClasificacionPeliculaId" });
            CreateTable(
                "dbo.RentaModel",
                c => new
                    {
                        RentaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PeliculaId = c.Int(nullable: false),
                        FechaRenta = c.DateTime(nullable: false),
                        FechaRetorno = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RentaId);
            
            DropColumn("dbo.PeliculasModel", "ClasificacionPeliculas_ClasificacionPeliculaId");
            DropTable("dbo.ClasificacionPeliculas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClasificacionPeliculas",
                c => new
                    {
                        ClasificacionPeliculaId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClasificacionPeliculaId);
            
            AddColumn("dbo.PeliculasModel", "ClasificacionPeliculas_ClasificacionPeliculaId", c => c.Int());
            DropTable("dbo.RentaModel");
            CreateIndex("dbo.PeliculasModel", "ClasificacionPeliculas_ClasificacionPeliculaId");
            AddForeignKey("dbo.PeliculasModel", "ClasificacionPeliculas_ClasificacionPeliculaId", "dbo.ClasificacionPeliculas", "ClasificacionPeliculaId");
        }
    }
}
