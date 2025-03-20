using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
       
        public CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(createProductRequest);
            _productRepository.Add(product);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateProductResponse>(product);
        }
    }
}
