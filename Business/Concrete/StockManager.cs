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
            ServiceResponse<Stock> responce = new ServiceResponse<Stock>();
            try
            {
                EfProductDal product = new EfProductDal();
                EfStockDal stock = new EfStockDal();
                var tempStock = stock.Get();
               
                tempStock.Flour -= 1;
                tempStock.Salt -= 1;
                tempStock.Water -= 1;
                tempStock.Yeast -= 1;
                stock.Update(tempStock);
                //BURAYA BAKILACAK UNUTMA!! AYNI ANDA HEM PRODUCT HEMDE STOCK RESPONSA NASIL EKLENİR
                var tempProduct = product.Get();
                tempProduct.ProductStock += 1;
                product.Update(tempProduct);

                responce.Data = tempStock;

            }
            catch (Exception ex)
            {
                responce.Message = ex.Message.ToString();//Hata mesajı daha kısa haliyle
                responce.Error = ex.StackTrace.ToString();//Hata detayı
                responce.Success = false;
            }
            return responce;
        }
        public ServiceResponse<Stock> StockList()
        {
            ServiceResponse<Stock> response = new ServiceResponse<Stock>();
            try
            {
                EfStockDal stock = new EfStockDal();
                response.Data = stock.Get();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();//Hata mesajı daha kısa haliyle
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
                response.Data = product.Get();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();//Hata mesajı daha kısa haliyle
                response.Error = ex.StackTrace.ToString();//Hata detayı
                response.Success = false;
            }
            return response;
        }
    }
}
