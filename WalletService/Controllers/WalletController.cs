using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletService.Repositories;
using WalletService.Dtos;
using WalletService.Models;

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

        [HttpGet]
        [Route("{id:guid}")]
        public ActionResult<WalletReadDto> GetWalletById([FromRoute] Guid id)
        {
            var wallet = repo.GetWalletById(id);
            if (wallet == null) return NotFound();

            return Ok(dbMapper.Map<WalletReadDto>(wallet));
        }

        [HttpPost]
        public ActionResult<WalletReadDto> CreateWallet(WalletCreateDto payload)
        {
            var newWallet = dbMapper.Map<Wallet>(payload);
            repo.CreateWallet(newWallet);
            var saved = repo.SaveChanges();
            if (!saved)
            {
                return BadRequest();
            }

            var result = dbMapper.Map<WalletReadDto>(newWallet);
            return Ok(result);
        }
    }
}