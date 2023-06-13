using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletService.Repositories;
using WalletService.Dtos;

namespace WalletService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepo repo;
        private readonly IMapper dbMapper;

        public WalletController(IWalletRepo repository, IMapper mapper)
        {
            repo = repository;
            dbMapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WalletReadDto>> GetWallets()
        {
            var wallet = repo.GetWallets();
            return Ok(dbMapper.Map<IEnumerable<WalletReadDto>>(wallet));
        }
    }
}