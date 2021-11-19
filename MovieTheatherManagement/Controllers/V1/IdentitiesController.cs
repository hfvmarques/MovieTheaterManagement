using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTheatherManagement.Contracts.V1;
using MovieTheatherManagement.Contracts.V1.Requests;
using MovieTheatherManagement.Contracts.V1.Responses;
using MovieTheatherManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Controllers.V1
{    
    public class IdentitiesController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentitiesController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                { 
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            { 
                Token = authResponse.Token
            });
        }
    }
}
