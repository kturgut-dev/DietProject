using DietProject.WisejWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Interfaces
{
    public interface IBaseOperations<T> where T : class, new()
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(Expression<Func<T, bool>> prop);// ID == 5
        IList<T> GetAll(Expression<Func<T, bool>> prop = null);// FoodName = 'Elma'
    }
}
