using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.AuthenticateUser
{
    //Query is requesting for all/list of roles
    public class AuthenticateUserQuery: IRequest<UserDto>
    {
        public UserDto Credentials { get; set; }
    }
}
