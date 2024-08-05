using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases.DTOs.UserDtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        
        public string UserName { get; set; } = string.Empty;
        
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
