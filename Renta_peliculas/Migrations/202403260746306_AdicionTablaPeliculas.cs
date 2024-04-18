namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaPeliculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeliculasModel",
                c => new
                    {
                        PeliculaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Genero = c.String(maxLength: 30),
                        Autores = c.String(maxLength: 75),
                        Existencia = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        ClasificacionPeliculas_ClasificacionPeliculaId = c.Int(),
                    })
                .PrimaryKey(t => t.PeliculaId)
                .ForeignKey("dbo.ClasificacionPeliculas", t => t.ClasificacionPeliculas_ClasificacionPeliculaId)
                .Index(t => t.ClasificacionPeliculas_ClasificacionPeliculaId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeliculasModel", "ClasificacionPeliculas_ClasificacionPeliculaId", "dbo.ClasificacionPeliculas");
            DropIndex("dbo.PeliculasModel", new[] { "ClasificacionPeliculas_ClasificacionPeliculaId" });
            DropTable("dbo.ClasificacionPeliculas");
            DropTable("dbo.PeliculasModel");
        }
    }
}
