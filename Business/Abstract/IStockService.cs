using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockService
    {
        ServiceResponse<Stock> StockListAdd();
        ServiceResponse<Stock> StockList();
        ServiceResponse<Product> ProductList();

    }
}
