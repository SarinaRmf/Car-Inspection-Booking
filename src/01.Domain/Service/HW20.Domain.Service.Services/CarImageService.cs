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
        public void Create(int requestId, List<IFormFile> files)
        {
            var images = new List<CarImage>();

            foreach(var file in files)
            {
                var path = fileService.Upload(file, "CarImages");

                var image = new CarImage
                {
                    ImagePath = path,
                    RequestId = requestId
                };
                images.Add(image);
            }

            _repo.Create(images);
        }

        public List<string> GetAll(int requestId) {

            return _repo.GetAll(requestId);
        }
    }
}
