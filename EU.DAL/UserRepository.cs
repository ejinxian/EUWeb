﻿using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    public class UserRepository: BaseRepository<User>, InterfaceUserRepository
    {
    }
}
