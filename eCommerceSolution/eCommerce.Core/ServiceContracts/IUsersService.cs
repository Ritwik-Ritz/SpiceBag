﻿using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
    Task <AuthResponse?> Login(Loginrequest loginrequest);
    Task<AuthResponse?> Register(RegisterRequest registerRequest);

}
