using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails
{
    

    public class GetEventDetailsQueryHandler:IRequestHandler<GetEventDetailsQuery, RoleDto>
    {
        private readonly ICommonRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(ICommonRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoleDto>(await _rolesRepository.GetDetailsAsync(request.RoleId));
        }
    }
}
