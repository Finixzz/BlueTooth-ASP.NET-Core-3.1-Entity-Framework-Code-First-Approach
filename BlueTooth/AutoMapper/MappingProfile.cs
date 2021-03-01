using AutoMapper;
using BlueTooth.Dtos;
using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Firma, FirmaDto>();
            CreateMap<FirmaDto, Firma>();

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>();

            CreateMap<DentalCheckUp, DentalCheckUpDto>();
            CreateMap<DentalCheckUpDto, DentalCheckUp>();

            CreateMap<Diagnose, DiagnoseDto>();
            CreateMap<DiagnoseDto, Diagnose>();

            CreateMap<EstablishedDiagnosis, EstablishedDiagnosisDto>();
            CreateMap<EstablishedDiagnosisDto, EstablishedDiagnosis>();

            CreateMap<_DentalCheckWorkers, _DentalCheckWorkersDto>();
            CreateMap<_DentalCheckWorkersDto, _DentalCheckWorkers>();

            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceDto, Service>();

            CreateMap<Bill, BillDto>();
            CreateMap<BillDto, Bill>();
        }
    }
}
