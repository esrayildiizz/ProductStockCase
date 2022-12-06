using Business.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockManager : IStockService
    {
        public ServiceResponse<Stock> StockListAdd()
        {
            ServiceResponse<Stock> response = new ServiceResponse<Stock>();
            try
            {
                EfProductDal product = new EfProductDal();
                EfStockDal stock = new EfStockDal();
                var tempStock = stock.Get();

                if (tempStock.Flour < 1 || tempStock.Salt<1 || tempStock.Water<1 || tempStock.Yeast<1)
                {
                    response.Error = "Stok adedi 1'den düşük olamaz.";
                    response.Success = false;
                    return response;
                }

                tempStock.Flour -= 1;
                tempStock.Salt -= 1;
                tempStock.Water -= 1;
                tempStock.Yeast -= 1;
                stock.Update(tempStock);
              
                var tempProduct = product.Get();
                tempProduct.ProductStock += 1;
                product.Update(tempProduct);

                response.Data = tempStock;
                response.Success = true;
                response.Message = "Ekmek yapma işlemi başarılı";
                return response;

            }
            catch (Exception ex)
            {
                response.Error = ex.StackTrace.ToString();//Hata detayı
                response.Success = false;
                return response;
            }
        }
        public ServiceResponse<Stock> StockList()
        {
            ServiceResponse<Stock> response = new ServiceResponse<Stock>();
            try
            {
                EfStockDal stock = new EfStockDal();
                response.Data = stock.List().FirstOrDefault();
                response.Message = "Stok listeleme başarılı";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Error = ex.StackTrace.ToString();//Hata detayı
                response.Success = false;
            }
            return response;
        }

        public ServiceResponse<Product> ProductList()
        {
            ServiceResponse<Product> response = new ServiceResponse<Product>();
            try
            {
                EfProductDal product = new EfProductDal();
                response.Data = product.List().FirstOrDefault();
                response.Message = "Product listeleme başarılı";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Error = ex.StackTrace.ToString();//Hata detayı
                response.Success = false;
            }
            return response;
        }


        public ServiceResponse<Stock> StockAdd(Stock stock)
        {
            ServiceResponse<Stock> response = new ServiceResponse<Stock>();
            try
            {
                EfStockDal stockDal = new EfStockDal();
                if (stock.Flour < 0 || stock.Salt < 0 || stock.Water < 0 || stock.Yeast < 0)
                {
                    response.Error = "Stok adedi 0'dan düşük olamaz.";
                    response.Success = false;
                    return response;
                }

                var tempStock=stockDal.Get();
                tempStock.Flour += stock.Flour;
                tempStock.Water += stock.Water;
                tempStock.Salt += stock.Salt;
                tempStock.Yeast += stock.Yeast;
                stockDal.Update(tempStock);

                response.Message = "Stok ekleme başarılı";
                response.Success = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Error = ex.StackTrace.ToString();//Hata detayı
                response.Success = false;
                return response;
            }
        }
    }
}
