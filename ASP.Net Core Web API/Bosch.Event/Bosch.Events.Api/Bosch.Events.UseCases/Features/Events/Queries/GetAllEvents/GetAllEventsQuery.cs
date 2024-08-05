using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.UseCases.DTOs.EventDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Events.Queries.GetAllEvents
{
    //Query is requesting for all/list of roles
    public class GetAllEventsQuery:IRequest<List<EventDto>>
    {
    }
}
