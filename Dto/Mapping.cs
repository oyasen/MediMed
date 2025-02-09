using AutoMapper;
using MediMed.Dto;
using MediMed.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // HealthTip mappings
        CreateMap<HealthTipDto, HealthTip>();
        CreateMap<HealthTip, HealthTipDto>();

        // Nurse mappings
        CreateMap<NurseDto, Nurse>();
        CreateMap<Nurse, NurseDto>();

        // Patient mappings
        CreateMap<PatientDto, Patient>();
        CreateMap<Patient, PatientDto>();
    }
}