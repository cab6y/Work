using AutoMapper;
using Work.Extras;
using Work.Files;
using Work.Web.Pages.Extras;
using static Work.Web.Pages.Extras.AboutModel;
using static Work.Web.Pages.Extras.IndexModel;

namespace Work.Web;

public class WorkWebAutoMapperProfile : Profile
{
    public WorkWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<ExtraDto, ExtraDtoIndex>();
        CreateMap<ExtraAboutDto, ExtraAboutDtoIndex>();
        CreateMap<ExtraDtoIndex,CreateUpdateExtra >();
        CreateMap<ExtraAboutDtoIndex,CreateUpdateExtraAbout >();
        CreateMap<CreateUpdateExtraFileIndex, CreateUpdateExtraFile>();
    }
}
