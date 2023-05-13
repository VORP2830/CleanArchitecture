using CleanArchitecture.Domain.Entities;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Valid Product")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m , 10, "Product Image");
            action.Should().NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create With Negative Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m , 10, "Product Image");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create With Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m , 10, "Product Image");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create With Long Image Name Value")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m , 10, "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create With Null Image Name")]
        public void CreateProduct_NullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m , 10, null);
            action.Should().NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create With Null Image Name")]
        public void CreateProduct_NullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 10, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create With Empty Image Name")]
        public void CreateProduct_EmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m , 10, "");
            action.Should().NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create With Negative Stock Value")]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m , -5, "");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }
    }
}