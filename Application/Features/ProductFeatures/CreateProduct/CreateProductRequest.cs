using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.ProductFeatures.CreateProduct
{
   public sealed record CreateProductRequest(string Name, decimal Price) : IRequest<CreateProductResponse>
    {

    }
}
