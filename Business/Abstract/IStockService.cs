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

        ServiceResponse<Stock> StockListAdd(); //row içleri dolsun-eklesin
        ServiceResponse<Stock> StockList();
        ServiceResponse<Stock> StockAdd(Stock stock); //Popup da ekleme yapma için oluşturdum.
        ServiceResponse<Product> ProductList();

    }
}
