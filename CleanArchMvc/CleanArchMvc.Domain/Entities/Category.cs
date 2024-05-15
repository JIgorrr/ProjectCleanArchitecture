using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Category(string name) 
        {
            ValidationDomain(name);
        }

        public Category(int id, string name) 
        {
            DomainExceptionValidation.When(id < 0, 
                "Invalid Id value");
            Id = id;
            ValidationDomain(name);
        }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; private set; }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name. Name is invalid");

            DomainExceptionValidation.When(name.Length < 3, 
                "Onvalid name, too short, minimum 3 characters");

            Name = name;
        }

        public void UpdateName(string name)
        {
            ValidationDomain(name);
        }
    }
}
