using System;
using AutoMapper;
using FetchData.Models;
using FetchEntity.Entities;

namespace FetchData.Mapper
{
	public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlockDTO, Block>();
            CreateMap<TransactionDTO, Transaction>();
        }
    }
}

