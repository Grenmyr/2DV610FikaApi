using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610FikaApi.Models.Repositories
{
    public interface IBakerRepository
    {
        List<Baker> GetBakers();

        Baker GetBaker(int id);

        Baker AddBaker(Baker baker);

        void DeleteBaker(Baker baker);
    }
}
