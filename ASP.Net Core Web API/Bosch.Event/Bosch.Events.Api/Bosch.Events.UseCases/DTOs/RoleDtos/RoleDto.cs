using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases.DTOs.RoleDtos
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}
