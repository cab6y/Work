using AutoMapper;
using Work.Extras;
using Work.Files;

namespace Work;

public class WorkApplicationAutoMapperProfile : Profile
{
    public WorkApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Extra, ExtraDto>();
        CreateMap<ExtraAbout, ExtraAboutDto>();
        CreateMap<ExtraFile, ExtraFileDto>();
    }
}
