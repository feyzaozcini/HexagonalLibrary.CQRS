using AutoMapper;
using HexagonalSample.Application.DtoClasses.Authors.Commands;
using HexagonalSample.Application.DtoClasses.Authors.Queries;
using HexagonalSample.Application.DtoClasses.Books.Commands;
using HexagonalSample.Application.DtoClasses.Books.Queries;
using HexagonalSample.Application.DtoClasses.BookTags.Commands;
using HexagonalSample.Application.DtoClasses.BookTags.Queries;
using HexagonalSample.Application.DtoClasses.Categories.Commands;
using HexagonalSample.Application.DtoClasses.Categories.Queries;
using HexagonalSample.Application.DtoClasses.Tags.Commands;
using HexagonalSample.Application.DtoClasses.Tags.Queries;
using HexagonalSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //AuthorProfile
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<Author, GetAuthorQueryResult>();

            //CategoryProfile
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, GetCategoryQueryResult>();

            //BookProfile
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<Book, GetBookQueryResult>();

            //TagProfile
            CreateMap<CreateTagCommand, Tag>();
            CreateMap<UpdateTagCommand, Tag>();
            CreateMap<Tag, GetTagQueryResult>();

            //BookTagProfile
            CreateMap<CreateBookTagCommand, BookTag>();
            CreateMap<UpdateBookTagCommand, BookTag>();
            CreateMap<BookTag, GetBookTagQueryResult>();
        }
    }
}
