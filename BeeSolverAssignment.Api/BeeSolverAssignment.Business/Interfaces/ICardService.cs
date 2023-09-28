using MtgApiManager.Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICard = MtgApiManager.Lib.Model.ICard;

namespace BeeSolverAssignment.Business.Interfaces
{
    public interface ICardService
    {
        Task<IOperationResult<List<ICard>>> GetAllCards(string? name, string[] colours, string[] types);

    }
}
