﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IgenericDal<T> where T:class
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
        
        List<T> GetAll();

        T GetById(int id);
    }
}
