﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KokaarCis.Domain.Paging;
using Microsoft.AspNetCore.Mvc;

namespace KokaarCis.Mvc.ViewComponents
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
