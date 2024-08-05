using AutoMapper;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.UserDtos;
using MediatR;
using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases.Features.Users.Queries.AuthenticateUser
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, UserDto>
    {
        private readonly ICommonRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public AuthenticateUserQueryHandler(ICommonRepository<User> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _usersRepository.GetAllAsync());
        }
    }
}
