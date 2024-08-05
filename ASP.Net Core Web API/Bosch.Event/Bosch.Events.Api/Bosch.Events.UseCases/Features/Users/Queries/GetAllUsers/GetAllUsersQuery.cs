using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.GetAllUsers
{
    //Query is requesting for all/list of roles
    public class GetAllUsersQuery:IRequest<List<UserDto>>
    {
    }
}
