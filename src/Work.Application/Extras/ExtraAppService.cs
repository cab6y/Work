using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Work.Files;

namespace Work.Extras
{
    public class ExtraAppService : WorkAppService, IExtraAppService
    {

        private readonly IExtraRepository _extraRepository;
        private readonly IExtraAboutRepository _extraAboutRepository;
        private readonly IExtraFileRepository _extraFileRepository;
        private readonly IRepository<IdentityUser,Guid> _identityUserRepository;
        public ExtraAppService(IExtraRepository extraRepository, 
            IExtraAboutRepository extraAboutRepository, 
            IExtraFileRepository extraFileRepository,
            IRepository<IdentityUser, Guid> identityUserRepository)
        {
            _extraRepository = extraRepository;
            _extraAboutRepository = extraAboutRepository;
            _extraFileRepository = extraFileRepository;
            _identityUserRepository = identityUserRepository;

        }
        public async Task<PagedResultDto<ExtraDto>> GetListAsync(GetExtraListDto input)
        {
            try
            {
                var totalCount = 0;
                var ExtraDtos = new List<ExtraDto>();

                var queryable = await _extraRepository.GetQueryableAsync();

                var extraFiles = from extraFile in await _extraFileRepository.GetQueryableAsync()
                                 where extraFile.FileEnum == FileEnum.ProfilePhoto
                                 select new { extraFile};
                var User = from user in await _identityUserRepository.GetQueryableAsync()
                                 select new { user};

                var query = from extra in queryable
                            from extraFile in extraFiles
                            from user in User
                            where extra.CreatorId == extraFile.extraFile.CreatorId && user.user.Id == extra.CreatorId
                            select new { extra , extraFile , user};

                var queryResult = query.ToList();
                ExtraDtos = queryResult.Select(x =>
                {
                    var extraDto = ObjectMapper.Map<Extra, ExtraDto>(x.extra);
                    if (x.extraFile.extraFile.FileEnum == FileEnum.video)
                        extraDto.VideoUrl = x.extraFile.extraFile.Url;
                    if (x.extraFile.extraFile.FileEnum == FileEnum.ProfilePhoto)
                        extraDto.ImgUrl = x.extraFile.extraFile.Url;
                    extraDto.Name = x.user.user.Name;
                    extraDto.Surname = x.user.user.Surname;
                    return extraDto;
                }).OrderBy(x=>x.Id).ToList();
                totalCount = input.Filter == null
              ? await _extraRepository.CountAsync()
              : await _extraRepository.CountAsync();

                return new PagedResultDto<ExtraDto>(
             totalCount,
             ExtraDtos
         );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> CreateAsync(CreateUpdateExtra input)
        {
            try
            {

                Extra extra = new Extra();
                extra.Kilo = input.Kilo;
                extra.DateOfBirth = input.DateOfBirth;
                extra.PhoneOfCustodian = input.PhoneOfCustodian;
                extra.TCKimlikNo = input.TCKimlikNo;
                extra.NameSurnameOfCustodian = input.NameSurnameOfCustodian;
                extra.City = input.City;
                extra.DateOfBirth = input.DateOfBirth;
                extra.DateOfPlace = input.DateOfPlace;
                extra.SkinColor = input.SkinColor;
                extra.DressSize = input.DressSize;
                extra.ExtraGenderEnum = input.ExtraGenderEnum;
                extra.EyeColor = input.EyeColor;
                extra.HairColor = input.HairColor;
                extra.HomeAddress = input.HomeAddress;
                extra.Kilo = input.Kilo;
                extra.ShoeSize = input.ShoeSize;
                extra.Size = input.Size;
                await _extraRepository.InsertAsync(extra);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<string>> GetAllVideos(Guid id)
        {
            try
            {
                var quarable = await _extraFileRepository.GetQueryableAsync();
                var extra = await _extraRepository.GetAsync(id);
                var query = from files in quarable
                            where files.CreatorId == extra.CreatorId && files.FileEnum == FileEnum.video
                            select new { files};
                return query.Select(x=>x.files.Url).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                await _extraRepository.DeleteAsync(id, true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ExtraDto> GetAsync(Guid id)
        {
            try
            {
                var extra = await _extraRepository.GetAsync(id);
                return ObjectMapper.Map<Extra, ExtraDto>(extra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ExtraDto> GetOnCurrenUserAsync()
        {
            try
            {
                var quarable = await _extraRepository.GetQueryableAsync();
                var query = quarable.Where(x=>x.CreatorId == CurrentUser.Id).FirstOrDefault();
                return ObjectMapper.Map<Extra, ExtraDto>(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Guid id, CreateUpdateExtra input)
        {
            try
            {
                var extra = await _extraRepository.GetAsync(id);
                extra.Kilo = input.Kilo;
                extra.DateOfBirth = input.DateOfBirth;
                extra.PhoneOfCustodian = input.PhoneOfCustodian;
                extra.TCKimlikNo = input.TCKimlikNo;
                extra.NameSurnameOfCustodian = input.NameSurnameOfCustodian;
                extra.City = input.City;
                extra.DateOfBirth = input.DateOfBirth;
                extra.DateOfPlace = input.DateOfPlace;
                extra.SkinColor = input.SkinColor;
                extra.DressSize = input.DressSize;
                extra.ExtraGenderEnum = input.ExtraGenderEnum;
                extra.EyeColor = input.EyeColor;
                extra.HairColor = input.HairColor;
                extra.HomeAddress = input.HomeAddress;
                extra.Kilo = input.Kilo;
                extra.ShoeSize = input.ShoeSize;
                extra.Size = input.Size;
                await _extraRepository.UpdateAsync(extra);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
