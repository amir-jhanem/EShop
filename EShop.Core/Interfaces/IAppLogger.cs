﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
