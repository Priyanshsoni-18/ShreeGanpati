﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShreeGanpati.Shared.Dtos;

public record SignupRequestDto(string Name, string Email, string Password, string Address);

