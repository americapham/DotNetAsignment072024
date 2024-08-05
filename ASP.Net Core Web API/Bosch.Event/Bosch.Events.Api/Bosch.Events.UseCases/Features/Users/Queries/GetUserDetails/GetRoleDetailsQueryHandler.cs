using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Users.Queries.GetUserDetails
{
    

    public class GetEventDetailsQueryHandler:IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        private readonly ICommonRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(ICommonRepository<User> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _usersRepository.GetDetailsAsync(request.UserId));
        }
    }
}
