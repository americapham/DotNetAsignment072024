using AutoMapper;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;
using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        private readonly ICommonRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(ICommonRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<RoleDto>>(await _rolesRepository.GetAllAsync());
        }
    }
}
