using EDB.Domain.Entities;

namespace EDB.WebAPI.Model.LiteraryWorksModel
{
    public class LiteraryWorksAddedModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImagePath { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AudioFilePath { get; set; }
        public Guid AuthorsId { get; set; }
        public Authors Authors { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
