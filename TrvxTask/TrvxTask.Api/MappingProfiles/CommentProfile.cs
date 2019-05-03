using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrvxTask.Api.Models;
using TrvxTask.Domain.Entities;

namespace TrvxTask.Api.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentModel>().ReverseMap();
        }
    }
}
