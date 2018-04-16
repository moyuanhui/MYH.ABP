using Abp.Application.Services;
using MYH.ABP.Member.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYH.ABP.Member
{
    public interface IMemberIService : IApplicationService
    {
        void CreateMember(CreateMemberInput input);
    }
}
