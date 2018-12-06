using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Models;

namespace AdPostingApi.Utilities
{
    public static class RequestValidation
    {
        internal static void ValidateAdInfoDto(AdInfoDto adInfoDto, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(adInfoDto.Title))
                modelState.AddModelError("Description", "Title is missing.");

            if (string.IsNullOrWhiteSpace(adInfoDto.Text))
                modelState.AddModelError("Description", "Text is missing.");
        }
    }
}
