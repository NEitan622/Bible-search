using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanachController : ControllerBase
    {
        [HttpGet]
        public List<DTO_Common_Enteties.PasukTora> Get()
        {
           return Bll_services.Searches.GetLocationWord("רחל");
        }
    }
}
