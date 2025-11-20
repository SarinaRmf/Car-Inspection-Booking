using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.Services
{
    public class CarImageService(IFileService fileService, ICarImageRepository _repo) : ICarImageService
    {
        public void Create(int carId, IFormFile file)
        {
            var path = fileService.Upload(file,"CarImages");

            _repo.Create(carId ,path);
        }
    }
}
