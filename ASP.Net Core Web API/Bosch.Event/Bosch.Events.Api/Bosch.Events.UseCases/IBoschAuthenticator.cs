using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases
{
    public interface IBoschAuthenticator
    {
        Task<User> Authenticate(User user);
    }
}
