using AutoMapper;
using BeeSolverAssignment.Business.Interfaces;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ICard = MtgApiManager.Lib.Model.ICard;

namespace BeeSolverAssignment.Business.Services
{
    public class CardService : Interfaces.ICardService
    {
        private const string BASE_URL = "https://api.magicthegathering.io";
        public async Task<IOperationResult<List<ICard>>> GetAllCards(string? name, string[] colours, string[] types)
        {
            IMtgServiceProvider serviceProvider = new MtgServiceProvider();
            var cardService = serviceProvider.GetCardService();
            var cardData = await cardService.Where(c => c.Colors, string.Join(",", colours))
                .Where(c => c.Types, string.Join(",", types))
                .Where(c => c.Name, name == null ? "" : name).AllAsync();
            return cardData;
        }
    }
}
