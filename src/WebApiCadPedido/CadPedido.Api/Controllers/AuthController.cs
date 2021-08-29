﻿using CadPedido.Api.ApiModels;
using CadPedido.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CadPedido.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppSettings _appSettings;

    public AuthController(SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager,
                          IOptions<AppSettings> appSettings)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Cria uma nova conta
    /// </summary>
    /// <param name="registerUser"></param>
    /// <returns></returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPost("nova-conta")]
    public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
    {

      if (!ModelState.IsValid)
        return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

      var user = new IdentityUser
      {
        UserName = registerUser.Email,
        Email = registerUser.Email,
        EmailConfirmed = false
      };

      var result = await _userManager.CreateAsync(user, registerUser.Password);

      if (!result.Succeeded) return BadRequest(result.Errors);

      await _signInManager.SignInAsync(user, false);

      return Ok(await GerarJwt(registerUser.Email));
    }

    /// <summary>
    /// Realiza o login
    /// </summary>
    /// <param name="registerUser"></param>
    /// <returns>Retorna token para acesso a Api</returns>
    /// <response code="200"> Sucesso </response>
    /// <response code="404"> Requisição</response>
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginUserViewModel loginUser)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

      var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

      if (result.Succeeded)
      {
        return Ok(await GerarJwt(loginUser.Email));
      }

      return BadRequest("Usuário ou senha inválidos");
    }

    /// <summary>
    /// Gerar Token Jwt
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Retorna Token Jwt</returns>
    private async Task<string> GerarJwt(string email)
    {
      var user = await _userManager.FindByEmailAsync(email);
      var identityClaims = new ClaimsIdentity();
      identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

      //autentication sucessful so generate jwt token
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = identityClaims,

        Issuer = _appSettings.Emissor,
        Audience = _appSettings.ValidoEm,
        Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
  }
}