using GGsDB.Entities;
using GGsDB.Models;
using System.Collections.Generic;

namespace GGsDB.Mappers
{
    public interface IGameConsoleMapper
    {
        GameConsole ParseGameConsole(Products product);
        Products ParseGameConsole(GameConsole product);
        List<GameConsole> ParseGameConsole(ICollection<Products> products);
        ICollection<Products> ParseGameConsole(List<GameConsole> products);
    }
}