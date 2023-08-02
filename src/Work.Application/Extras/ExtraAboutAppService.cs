using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work.Extras
{
    public class ExtraAboutAppService : WorkAppService, IExtraAboutAppService
    {
        private readonly IExtraAboutRepository _extraAboutRepository;
        public ExtraAboutAppService(IExtraAboutRepository extraAboutRepository) 
        {
            _extraAboutRepository = extraAboutRepository;
        }

        public async Task<bool> CreateAsync(CreateUpdateExtraAbout input)
        {
            try
            {
                ExtraAbout extraAbout = new ExtraAbout();
                extraAbout.Details = input.Details;
                extraAbout.PlaysAdultRoles = input.PlaysAdultRoles;
                extraAbout.puan = input.puan;
                extraAbout.IsProffesionalTrained = input.IsProffesionalTrained;
                extraAbout.InterviewNumber = input.InterviewNumber;
                extraAbout.Instagram = input.Instagram;
                extraAbout.Info = input.Info;
                await _extraAboutRepository.InsertAsync(extraAbout);
                return true;
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
                await _extraAboutRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ExtraAboutDto> GetAsync(Guid id)
        {
            try
            {
                var extraAbout = await _extraAboutRepository.GetAsync(id);
                return ObjectMapper.Map<ExtraAbout, ExtraAboutDto>(extraAbout);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ExtraAboutDto> GetOnCurrenUserAsync()
        {
            try
            {
                var quarable = await _extraAboutRepository.GetQueryableAsync();
                var query = quarable.Where(x=>x.CreatorId == CurrentUser.Id).FirstOrDefault();
                return ObjectMapper.Map<ExtraAbout, ExtraAboutDto>(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Guid id, CreateUpdateExtraAbout input)
        {
            try
            {
                var extraAbout = await _extraAboutRepository.GetAsync(id);
                extraAbout.Info = input.Info;
                extraAbout.InterviewNumber = input.InterviewNumber;
                extraAbout.Instagram = input.Instagram;
                extraAbout.IsProffesionalTrained = input.IsProffesionalTrained;
                extraAbout.Details = input.Details;
                extraAbout.PlaysAdultRoles = input.PlaysAdultRoles;
                extraAbout.IsProffesionalTrained = input.IsProffesionalTrained;
                extraAbout.puan = input.puan;
                await _extraAboutRepository.UpdateAsync(extraAbout);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
