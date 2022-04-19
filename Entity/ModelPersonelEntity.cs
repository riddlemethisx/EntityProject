using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Entities
{
    public partial class ModelPersonelEntity : DbContext
    {


        //BU DOSYA B�Z�M MODEL'�M�ZD�R. T�M TABLOLAR VE VIEWLAR BURADAN Y�NET�L�R. BUNA MODEL DEN�R. TIPKI DATABASE DIAGRAM G�B�


        public ModelPersonelEntity() : base("ModelPersonelEntity")
        {

        }

        //TABLOLAR VE VIEWLAR YAZILIR

        public virtual DbSet<Birimler> Birimlers { get; set; }
        public virtual DbSet<Personeller> Personellers { get; set; }
        public virtual DbSet<viewPersonelBirim> viewPersonelBirims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)    //bu k�s�m otomatik olu�turuluyor. ctrl+. ile
        {
            modelBuilder.Entity<Birimler>()
                .Property(e => e.BirimAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Birimler>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Personeller>()
                .Property(e => e.AdiSoyadi)
                .IsUnicode(false);

            modelBuilder.Entity<Personeller>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Personeller>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Personeller>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<viewPersonelBirim>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<viewPersonelBirim>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<viewPersonelBirim>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<viewPersonelBirim>()
                .Property(e => e.AdiSoyadi)
                .IsUnicode(false);

            modelBuilder.Entity<viewPersonelBirim>()
                .Property(e => e.BirimAdi)
                .IsUnicode(false);
        }
    }
}
