using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.Queries
{
    public class GetProductByIdQuery
    {
        public int Id { get; set; } 
       public GetProductByIdQuery(int id)
       {
        Id = id;
       }
    }
}