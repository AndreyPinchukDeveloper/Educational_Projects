using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooker.FluentValidation
{
    public class TestClass
    {
        public void TestValidation()
        {
            Entity entity = new Entity()
            {
                Name = "Test",
                Description = "TestDescription",
                IntValue = 1,
            };

            var validator = new EntityValidator();
            var validationResults = validator.Validate(entity);

            validationResults.IsValid.Dump("is valid: ");

            foreach (var validationResult in validationResults.Errors) 
            {
                Console.WriteLine(validationResult);
            }
        }
    }

    public class EntityValidator:AbstractValidator<Entity>
    {
        public EntityValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Logins).Must(x => x != null && x.Count > 0).WithMessage("There's not any logins");
            RuleForEach(x => x.Logins).SetValidator(new LoginValidator());
        }
    }

    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.NickName).NotEmpty().MaximumLength(50);          
        }
    }

    public class Login
    {
        public string Email { get; set; }
        public string NickName { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int IntValue { get; set; }

        public List<Login> Logins { get; set; }
    }
}
