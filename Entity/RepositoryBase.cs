using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;


//BU SCRIPTTE EKLEME,GÜNCELLEME,SİLME İŞLEMLERİNİ YAPACAĞIZ---bunlara migrations işlemleri denir


namespace Entities
{
    public class RepositoryBase<Entity, Context>
        where Entity : class, new()
        where Context : DbContext, new()     //DbContext class'ını miras alıyor
    {






        Context db = new Context();





        //bu şekilde ekleme ve güncelleme işlemini tek metodda yapabiliriz
        public void AddorUpdate(Entity entity)
        {
            db.Set<Entity>().AddOrUpdate(entity);
            db.SaveChanges();
        }



        public void Save()
        {
            db.SaveChanges();
        }

        public void Delete(Expression<Func<Entity,bool>> obj)
        {
            // db.table.First(s => s.id == s.PersonelID)    //linq ile yapılış bu. bu yapıyı entity framework ile yapacağız

            var model = db.Set<Entity>().FirstOrDefault(obj);   //model'e  'obj' veriliyor---TEK VERİ ÇEKME
            db.Set<Entity>().Remove(model);     //'model' siliniyor

        }



        //listeleme
        public List<Entity> GetList( Expression<Func<Entity, bool>> obj=null) //obj=null yapmamızın sebebi, bu fonk değer verilmeden çalışssa da hata vermesin
        {
            List<Entity> liste;
            if (obj == null)    //eğer obj gönderilmeden listeleme isteniyorsa
                liste = db.Set<Entity>().ToList();
            else
                liste = db.Set<Entity>().Where(obj).ToList();       //obj gönderilerek listeleme
            return liste;
        }




        //tek veri çekme (fonk'a parametere gönderilmesi zorunlu)
        public Entity GetByFilter( Expression<Func<Entity, bool>> obj)
        {
            return db.Set<Entity>().FirstOrDefault(obj);
        }













    }

}