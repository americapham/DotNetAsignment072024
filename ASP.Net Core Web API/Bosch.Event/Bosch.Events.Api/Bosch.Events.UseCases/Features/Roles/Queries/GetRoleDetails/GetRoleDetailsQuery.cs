using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails
{
    public class GetEventDetailsQuery:IRequest<RoleDto>
    {
        public int RoleId { get; set; }
    }
}
