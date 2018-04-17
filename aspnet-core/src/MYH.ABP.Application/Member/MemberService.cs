using System;
using System.Collections.Generic;
using System.Text;
using MYH.ABP.Member.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System.Threading.Tasks;

namespace MYH.ABP.Member
{
    /// <summary>
    /// 会员
    /// </summary>
    public class MemberService : IMemberIService
    {
        private readonly IRepository<MemberEntity> _memberRepository;

        public MemberService(IRepository<MemberEntity> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// 创建会员
        /// </summary>
        /// <param name="input"></param>
       public async Task<CreateMemberInput> CreateMember(CreateMemberInput input)
        {
            var member = _memberRepository.FirstOrDefault(p => p.OpenIdMp == input.OpenIdMp);
            if(member != null)
            {
                throw new UserFriendlyException("用户已经存在");
            }

            member = new MemberEntity() { OpenIdMp = input.OpenIdMp, CompanyId = input.CompanyId, AccountId = input.AccountId };
            await _memberRepository.InsertAsync(member);
            return input;
        }
    }
}
