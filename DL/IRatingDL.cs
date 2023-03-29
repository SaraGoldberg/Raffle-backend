using Entities;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DL
{
    public interface IRatingDL
    {
        Task postRating(Rating rating);
    }
}