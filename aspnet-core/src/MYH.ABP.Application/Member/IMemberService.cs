using Abp.Application.Services;
using MYH.ABP.Member.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYH.ABP.Member
{
    public interface IMemberIService : IApplicationService
    {
        Task<CreateMemberInput> CreateMember(CreateMemberInput input);
    }
}
