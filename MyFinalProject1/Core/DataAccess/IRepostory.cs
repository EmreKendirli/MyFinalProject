﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //generic constraint
    //class: referans tip
    //IEntity:IEntity olabilir ve IEntity implemente eden bir nesne olabilir
    //new(): new 'lenebilir olmalı --->IEntity almaması için
    public interface IRepostory<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        
        void Add(T entity);
        void UpDate(T entity);
        void Delete(T entity);

    }
}
