using OnlineExamination.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamination.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Save();
    }
}
