using Api.Domain.Entities;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.Domain.Interfaces
{
    public  interface IProduct
    {

        public Task<int> SaveReport(Product model);

     
     
         public   Task<List<Product>> GetProducts(); 
        

    }
}
