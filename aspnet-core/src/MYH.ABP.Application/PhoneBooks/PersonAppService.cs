using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using MYH.ABP.PhoneBook.PhoneNum;
using MYH.ABP.PhoneBooks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYH.ABP.PhoneBooks
{
    public class PersonAppService : ABPAppServiceBase,IPersonAppService
    {
        private readonly IRepository<PhoneNumber> _phoneNumberRepository;
        private readonly ICacheManager _cacheManager;
        public PersonAppService(
            IRepository<PhoneNumber> phoneNumberRepository,
            ICacheManager cacheManager
            )
        {
            _phoneNumberRepository = phoneNumberRepository;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// 增加手机号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  async Task<PhoneNumberDto> Create(PhoneNumberDto input)
        {
            _cacheManager.GetCache("list:new");
            var phoneNumber = ObjectMapper.Map<PhoneNumber>(input);
            phoneNumber.Number = "12121212";
            phoneNumber.Id = 1;
            await _phoneNumberRepository.InsertAsync(phoneNumber);

            return null;
        }
    }
}
