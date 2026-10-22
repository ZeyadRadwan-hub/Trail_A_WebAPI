using AutoMapper;
using JobPortal.DTOs.Company;
using JobPortal.DTOs.Job;
using Trail_A.Models;

namespace JobPortal.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Job
            CreateMap<Job, JobResponeDTO>();
            CreateMap<Job, JobResponeGetByIdDTO>();

            //Company
            CreateMap<Company, CompanyResponeDTO>()
                .ForMember(z => z.JobsCount,
                x => x.MapFrom(y => y.Jobs.Count));

            CreateMap<Company, CompanyInfoDTO>();
        }
    }
}
