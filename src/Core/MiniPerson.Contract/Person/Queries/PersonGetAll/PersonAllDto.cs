using MiniPerson.Application.DTO;
using MiniPerson.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MiniPerson.Domain.DTO
{
    public class PersonAllDto : BaseEntityDto
    {
        #region Props
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        #endregion
    }
}