using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityFramework
{
    public class EFEntityRepostoryBase<TEntity,TContex>:IRepostory<TEntity>
        where TEntity: class, IEntity, new()
        where TContex: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContex contex = new TContex())
            {
                var addedEntity = contex.Entry(entity);//Referansı yakala
                addedEntity.State = EntityState.Added;//eklenecek nesne
                contex.SaveChanges();//simdi ekle
            }
          
        }

        public void Delete(TEntity entity)
        {
            using (TContex contex = new TContex())
            {
                var deletedEntity = contex.Entry(entity);//Referansı yakala
                deletedEntity.State = EntityState.Deleted;//silinecek nesne
                contex.SaveChanges();//simdi sil
            }

            
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContex contex = new TContex())
            {
            return contex.Set<TEntity>().SingleOrDefault(filter);
            }
        }



    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContex contex = new TContex())
            {
                return filter == null ? contex.Set<TEntity>().ToList() : contex.Set<TEntity>().Where(filter).ToList();//Eger filtreleme null ise product listele eger nul degilse where göre listele

            }
            
        }

        public void UpDate(TEntity entity)
        {
            using (TContex contex = new TContex())
            {
                var updatedEntity = contex.Entry(entity);//Referansı yakala
                updatedEntity.State = EntityState.Modified;//güncellenecek nesne
                contex.SaveChanges();//simdi güncelle
            }
            
        }


    }
}
