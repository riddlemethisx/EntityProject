namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Birimler")]
    public partial class Birimler
    {
        [Key]       //birimid nin key oldu�u belirtiliyor
        public int BirimID { get; set; }    //i�ersinde get set metodlar� bar�nd�r�yor. bu �ekilde s�tuna eri�ilebilir

        [StringLength(50)]
        public string BirimAdi { get; set; }

        [Column(TypeName = "text")]
        public string Aciklama { get; set; }
    }
}
