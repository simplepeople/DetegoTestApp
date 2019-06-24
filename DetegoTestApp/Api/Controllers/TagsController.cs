using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        public ReaderService ReaderService { get; set; }

        public TagsController(ReaderService readerService)
        {
            ReaderService = readerService;
        }

        [HttpGet]
        public async Task<GetInfosResponse> GetInfos(GetInfosRequest request)
        {
            var respModel = await ReaderService.GetInfos(request.Id);
            return new GetInfosResponse
            {
                ReaderId = respModel.ReaderId,
                Tags = respModel.TagInfos.Select(x => new TagDto
                {
                    Id = x.Id,
                    RfidKey = x.RfidKey,
                    ActivationCount = x.ActivationCount
                }).ToArray()
            };
        }
    }
}
