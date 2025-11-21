using HW20.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Repository
{
    public interface ICarImageRepository
    {
        void Create(List<CarImage> carImages);
        List<string> GetAll(int requestId);
    }
}
