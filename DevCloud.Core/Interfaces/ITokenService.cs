using DevCloud.Core.DTOs;
using DevCloud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCloud.Core.Interfaces
{
    public interface ITokenService
    {
        Token Create(User user);
    }
}
