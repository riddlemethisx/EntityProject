using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonelDAL:RepositoryBase<Personeller,ModelPersonelEntity>
    {
        public object PersonellerGetir(ModelPersonelEntity db, Expression<Func<Personeller, bool>> obj) //bir db ve obj türünde parametre istiyor
        {


            //burada personeller ve birimler tablosundaki birimID'leri aynı olan obje alınıyor ve bir view oluşturuluyor olarak düşünebiliriz.
            //bu viewın personeller tablosundan gelen sütununa p. diyerek erişebiliyoruz.
            //aynı şekilde birimlerden geliyorsa da b. diyerek erişiriz



            #region 1.YÖNTEM
            var model = db.Personellers.Where(obj).Join(db.Birimlers, x => x.BirimID, x => x.BirimID, (p, b) => new
            {
                p.PersonelID,
                p.AdiSoyadi,
                p.Telefon,
                p.Adres,
                p.Email,
                p.Tarih,
                p.IsActive,
                p.BirimID,
                b.BirimAdi
            }).ToList();    //alınan bu modeller listeye aktarılıyor


            #endregion




            //hata alınırsa bu çalıştırılabilir
            #region 2.YÖNTEM
            //object model;

            //if (obj == null)
            //{


            //    model = db.Personellers.Join(db.Birimlers, x => x.BirimID, x => x.BirimID, (p, b) => new
            //    {
            //        p.PersonelID,
            //        p.AdiSoyadi,
            //        p.Telefon,
            //        p.Adres,
            //        p.Email,
            //        p.Tarih,
            //        p.IsActive,
            //        p.BirimID,
            //        b.BirimAdi
            //    }).ToList();




            //}
            //else
            //{
            //    model = db.Personellers.Where(obj).Join(db.Birimlers, x => x.BirimID, x => x.BirimID, (p, b) => new
            //    {
            //        p.PersonelID,
            //        p.AdiSoyadi,
            //        p.Telefon,
            //        p.Adres,
            //        p.Email,
            //        p.Tarih,
            //        p.IsActive,
            //        p.BirimID,
            //        b.BirimAdi
            //    }).ToList();

            //}

            #endregion





            return model;   //liste halindeki modeller datasource'a iletiliyor
        }
    }
}
