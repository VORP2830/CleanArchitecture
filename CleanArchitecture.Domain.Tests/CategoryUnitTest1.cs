using CleanArchitecture.Domain.Entities;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id")]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Short Name Value")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 charecters");
        }

        [Fact(DisplayName = "Create Category Missing Name Value")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name Value")]
        public void CreateCategory_WithMissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }
    }
}