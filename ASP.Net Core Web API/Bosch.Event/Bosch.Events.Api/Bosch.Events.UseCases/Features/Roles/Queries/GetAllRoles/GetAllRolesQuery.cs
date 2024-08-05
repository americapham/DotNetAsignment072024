using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles
{
    //Query is requesting for all/list of roles
    public class GetAllRolesQuery:IRequest<List<RoleDto>>
    {
    }
}
