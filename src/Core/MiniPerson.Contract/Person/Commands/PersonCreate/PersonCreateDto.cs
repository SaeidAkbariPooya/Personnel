using MiniPerson.Application.DTO;
using MiniPerson.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MiniPerson.Domain.DTO
{
    public class PersonCreateDto : BaseEntityDto
    {
        public string FullName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}