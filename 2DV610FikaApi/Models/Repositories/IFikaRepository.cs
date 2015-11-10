
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610FikaApi.Models.Repositories
{
    public interface IFikaRepository
    {
        Task<Fika> GetFika(int id);

        Task<Fika> AddFika(Fika fika);

        Task<Fika> GetFika();

    }
}
