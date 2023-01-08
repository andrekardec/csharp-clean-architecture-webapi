using CleanArchitectureWebAPI.Domain.Interfaces.Base;
using CleanArchitectureWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebAPI.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
