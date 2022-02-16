using AutoMapper;
using Power.Core.DTOs;
using Power.Data.Entities;
using Power.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<BaseEntity<int>, BaseEntityDTO<int>>().ReverseMap().IncludeAllDerived();

            //CreateMap<Test, TestDto>()
            //    .ForMember(dest => dest.TestId, src => src.MapFrom(src => src.Id)).ReverseMap();

            BookMapping();

            AuthorMapping();
        }


        private void BookMapping()
        {
            CreateMap<Book, BookDTO>()
            .ForMember(dest => dest.IsFree, src => src.MapFrom(src => src.Price == 0.0))
            .ForMember(dest => dest.AuthorName, src => src.MapFrom(src => src.Author.Name))
            .ReverseMap();

            CreateMap<AddBookDTO, Book>();
        }
        private void AuthorMapping()
        {
            CreateMap<Author, AuthorDTO>()
              .ForMember(dest => dest.AuthorId, src => src.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
