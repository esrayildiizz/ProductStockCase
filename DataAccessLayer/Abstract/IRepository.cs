using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T p);

        //Şartlı listeleme için aşağıdaki listeleme yöntemi kullanılır.
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
