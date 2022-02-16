using Power.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthDTO> RegisterAsync(RegisterDTO dto);
        Task<AuthDTO> GetTokenAsync(TokenRequestDTO dto);
        Task<string> AddRolesAsync(AddRoleDTO dto);
    }
}
