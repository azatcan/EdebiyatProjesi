using EDB.Domain.Entities;

namespace EDB.WebAPI.Model.AuthorsModel
{
    public class AuthorsAddedModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string About { get; set; }
        public string Pseudonym { get; set; }
        public IFormFile ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
    }
}
