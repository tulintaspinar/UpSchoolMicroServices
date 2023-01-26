﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Basket.DTOs;
using UpSchoolECommerce.Services.Basket.Services;
using UpSchoolECommerce.Shared.ControllerBases;
using UpSchoolECommerce.Shared.Services;

namespace UpSchoolECommerce.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdated(BasketDTO basketDTO)
        {
            basketDTO.UserId = _sharedIdentityService.GetUserId;
            var response = await _basketService.SaveOrUpdate(basketDTO);
            return CreateActionResultInstance(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
