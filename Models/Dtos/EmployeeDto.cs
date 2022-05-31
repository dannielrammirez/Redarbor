using System;
using System.ComponentModel.DataAnnotations;

namespace APIRedarbor.Models.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Empresa obligatoria")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Fecha de creacion obligatoria")]
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        [Required(ErrorMessage = "Email obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fax obligatorio")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Name { get; set; }
        public DateTime LastLogin { get; set; }
        [Required(ErrorMessage = "Password obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Portal obligatorio")]
        public int PortalId { get; set; }
        [Required(ErrorMessage = "Rol obligatorio")]
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Telefono obligatorio")]
        public string Telephone { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required(ErrorMessage = "Usuario obligatorio")]
        public string Username { get; set; }
    }
}
