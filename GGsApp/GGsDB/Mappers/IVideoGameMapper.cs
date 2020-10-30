using GGsDB.Entities;
using GGsDB.Models;
using System.Collections.Generic;

namespace GGsDB.Mappers
{
    public interface IVideoGameMapper
    {
        VideoGame ParseVideoGame(Products product);
        Products ParseVideoGame(VideoGame product);
        List<VideoGame> ParseVideoGame(ICollection<Products> products);
        ICollection<Products> ParseVideoGame(List<VideoGame> products);
    }
}