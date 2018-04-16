using System;
using System.Collections.Generic;
using System.Text;
using MYH.ABP.Member.Dto;
using Abp.Domain.Repositories;
using Abp.UI;

namespace MYH.ABP.Member
{
    public class MemberService : IMemberIService
    {
        private readonly IRepository<MemberEntity> _memberRepository;

        public MemberService(IRepository<MemberEntity> memberRepository)
        {
            _memberRepository = memberRepository;
        }

       public void CreateMember(CreateMemberInput input)
        {
            var member = _memberRepository.FirstOrDefault(p => p.OpenIdMp == input.OpenIdMp);
            if(member != null)
            {
                throw new UserFriendlyException("用户已经存在");
            }
            
            var 
        }
    }
}
