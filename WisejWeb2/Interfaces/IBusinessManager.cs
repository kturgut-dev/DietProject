using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Interfaces
{
    public interface IBusinessManager<T>
    {
        IBusinessResult<bool> Add(T entity);
        IBusinessResult<bool> Update(T entity);
        IBusinessResult<bool> Delete(Expression<Func<T, bool>> expression);
        IBusinessResult<T> Get(Expression<Func<T, bool>> expression);
        IBusinessResult<List<T>> GetAll(Expression<Func<T, bool>> expression);
    }
}
