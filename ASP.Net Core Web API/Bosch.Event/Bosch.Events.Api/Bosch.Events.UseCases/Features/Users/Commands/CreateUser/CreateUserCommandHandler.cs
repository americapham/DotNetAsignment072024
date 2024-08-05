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

namespace Bosch.Events.UseCases.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,int>
    {
        private readonly ICommonRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ICommonRepository<User> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request.User);
            return _mapper.Map<int>(await _usersRepository.InsertAsync(newUser));
        }
    }
}
