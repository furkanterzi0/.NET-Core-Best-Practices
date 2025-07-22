using BestPractices.Models;
using FluentValidation;

namespace BestPractices.Api.Validations
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(i => i.FullName).NotEmpty().WithMessage("isim soyisim bos olamaz");
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100'den buyuk olamaz");
        }
    }
}
