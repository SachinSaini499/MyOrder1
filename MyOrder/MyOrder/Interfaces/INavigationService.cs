﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Interfaces
{
    public interface INavigationService
    {
        void NavigateToSecondPage();
        void NavigateBack();
    }
}
