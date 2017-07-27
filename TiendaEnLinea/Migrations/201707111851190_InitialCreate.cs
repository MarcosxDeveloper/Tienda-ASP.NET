namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articuloes",
                c => new
                    {
                        ArticuloId = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        ProductorId = c.Int(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 160),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArticuloArtUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.ArticuloId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Productors", t => t.ProductorId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.ProductorId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Productors",
                c => new
                    {
                        ProductorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ProductorId);
            
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CarritoId = c.String(),
                        ArticuloId = c.Int(nullable: false),
                        Contador = c.Int(nullable: false),
                        DataCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Articuloes", t => t.ArticuloId, cascadeDelete: true)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.OrdenDetalles",
                c => new
                    {
                        OrdenDetalleId = c.Int(nullable: false, identity: true),
                        OrdenId = c.Int(nullable: false),
                        ArticuloId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrdenDetalleId)
                .ForeignKey("dbo.Articuloes", t => t.ArticuloId, cascadeDelete: true)
                .ForeignKey("dbo.Ordens", t => t.OrdenId, cascadeDelete: true)
                .Index(t => t.OrdenId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        OrdenId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Ciudad = c.String(),
                        CodigoPostal = c.String(),
                        Pais = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrdenFecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenDetalles", "OrdenId", "dbo.Ordens");
            DropForeignKey("dbo.OrdenDetalles", "ArticuloId", "dbo.Articuloes");
            DropForeignKey("dbo.Carritoes", "ArticuloId", "dbo.Articuloes");
            DropForeignKey("dbo.Articuloes", "ProductorId", "dbo.Productors");
            DropForeignKey("dbo.Articuloes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.OrdenDetalles", new[] { "ArticuloId" });
            DropIndex("dbo.OrdenDetalles", new[] { "OrdenId" });
            DropIndex("dbo.Carritoes", new[] { "ArticuloId" });
            DropIndex("dbo.Articuloes", new[] { "ProductorId" });
            DropIndex("dbo.Articuloes", new[] { "CategoriaId" });
            DropTable("dbo.Ordens");
            DropTable("dbo.OrdenDetalles");
            DropTable("dbo.Carritoes");
            DropTable("dbo.Productors");
            DropTable("dbo.Categorias");
            DropTable("dbo.Articuloes");
        }
    }
}
