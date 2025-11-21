using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Services
{
    public interface ICarImageService
    {
        void Create(int requestId, List<IFormFile> files);
        List<string> GetAll(int requestId);
    }
}
