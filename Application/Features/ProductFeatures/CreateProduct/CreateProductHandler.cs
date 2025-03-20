using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;

namespace Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductHandler
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private Mapper _mapper;
       
        public CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, Mapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handler(CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(createProductRequest);
            _productRepository.Add(product);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateProductResponse>(product);
        }
    }
}
