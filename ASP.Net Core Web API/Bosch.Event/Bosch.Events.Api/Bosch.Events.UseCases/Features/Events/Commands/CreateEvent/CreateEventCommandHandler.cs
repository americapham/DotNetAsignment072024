using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.EventDtos;
using Bosch.Events.UseCases.Features.Events.Commands.CreateEvent;
using MediatR;

namespace Bosch.Events.UseCases.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler:IRequestHandler<CreateEventCommand, int>
    {
        private readonly ICommonRepository<Event> _eventsRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(ICommonRepository<Event> eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = _mapper.Map<Event>(request.Event);
            return _mapper.Map<int>(await _eventsRepository.InsertAsync(newEvent));
        }
    }
}
