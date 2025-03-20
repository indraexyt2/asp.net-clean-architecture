using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProductFeatures.CreateProduct
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nama produk tidak boleh kosong!")
                .MaximumLength(50).WithMessage("Nama produk maksimal 50 karakter!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Harga tidak boleh kosong!");
        }
    }
}
