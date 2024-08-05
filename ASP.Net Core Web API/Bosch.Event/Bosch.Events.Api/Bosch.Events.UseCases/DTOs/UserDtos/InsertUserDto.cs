using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.DTOs.UserDtos
{
    public class InsertUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
