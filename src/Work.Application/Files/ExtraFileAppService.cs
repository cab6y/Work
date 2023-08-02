using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Work.Files
{
    public class ExtraFileAppService : WorkAppService, IExtraFileAppService
    {
        private readonly IExtraFileRepository _extraFileRepository;
        public ExtraFileAppService(IExtraFileRepository extraFileRepository)
        {
            _extraFileRepository = extraFileRepository;
        }
        public async Task<string> CountAsync()
        {
            try
            {
                var get = await _extraFileRepository.GetQueryableAsync();
                var result = get.Where(x=>x.CreatorId == CurrentUser.Id && x.FileEnum == Extras.FileEnum.ProfilePhoto).FirstOrDefault();
                if (result != null)
                    return result.Id.ToString();
                else
                    return "";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> CreateAsync(CreateUpdateExtraFile input)
        {
            try
            {
                string count = await CountAsync();
                if (count != "")
                    await DeleteAsync(Guid.Parse(count));
                ExtraFile file = new ExtraFile();
                file.Name = input.Name;
                file.FileEnum = input.FileEnum;
                file.Url = input.Url;
                await _extraFileRepository.InsertAsync(file);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var get = await _extraFileRepository.GetAsync(Id);
                string fullpath = Path.Combine(get.Url);

                if (File.Exists(Path.Combine(fullpath)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(fullpath));
                }
                await _extraFileRepository.DeleteAsync(Id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedResultDto<ExtraFileDto>> GetListAsync(GetExtraFileListDto input)
        {
            try
            {
                var totalCount = 0;
                var ExtraFileDtos = new List<ExtraFileDto>();

                var queryable = await _extraFileRepository.GetQueryableAsync();



                var query = from extraFile in queryable
                             where extraFile.CreatorId == CurrentUser.Id
                             select new { extraFile };
                
                var queryResult = query.ToList();
                ExtraFileDtos = queryResult.Select(x =>
                {
                    var ExtraFileDto = ObjectMapper.Map<ExtraFile, ExtraFileDto>(x.extraFile);
                    return ExtraFileDto;
                }).ToList();
                totalCount = input.Filter == null
              ? await _extraFileRepository.CountAsync()
              : await _extraFileRepository.CountAsync();

                return new PagedResultDto<ExtraFileDto>(
             totalCount,
             ExtraFileDtos
         );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Guid Id, CreateUpdateExtraFile input)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
