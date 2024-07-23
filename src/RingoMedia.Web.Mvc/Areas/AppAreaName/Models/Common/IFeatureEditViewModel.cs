using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

    }
}