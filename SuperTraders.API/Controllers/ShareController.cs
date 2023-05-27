using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.CustomControllerBase;
using SuperTraders.Business.DTO.Share;
using SuperTraders.Business.Interfaces;

namespace SuperTraders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : CustomBaseController
    {

        private readonly IShareService _shareService;

        public ShareController(IShareService shareService)
        {
            _shareService = shareService; 
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerShareUpdateDto customerShareDto)
        {
            var result = await _shareService.GetShareUpdateWithCustomer(customerShareDto);

            return CreateActionResultInstance(result);
        }

    }
}
