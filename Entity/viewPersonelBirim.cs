namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewPersonelBirim")]        //bunun view olmasý gerektiðini galiba baþýndaki view ifadesinden anlýyor
    public partial class viewPersonelBirim
    {
        [StringLength(20)]
        public string Telefon { get; set; }

        [Column(TypeName = "text")]
        public string Adres { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string AdiSoyadi { get; set; }

        public int? Expr1 { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonelID { get; set; }

        [StringLength(50)]
        public string BirimAdi { get; set; }
    }
}
