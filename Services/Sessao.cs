﻿using Newtonsoft.Json;
using Snapbites.Models;

namespace SnapBites.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string tokenSessao;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "usuario";
        }

        public void addTokenLogin(Usuario usuario)
        {
            string loginTokenJson = JsonConvert.SerializeObject(usuario);
            this.httpContextAccessor.HttpContext?.Session.SetString(this.tokenSessao, loginTokenJson);
        }

        public Usuario getTokenLogin() 
        {
            string? loginTokenJson = this.httpContextAccessor.HttpContext?.Session.GetString(this.tokenSessao);
            return loginTokenJson != null ? JsonConvert.DeserializeObject<Usuario>(loginTokenJson) : null;
        }

        public void deleteTokenLogin()
        {
            this.httpContextAccessor.HttpContext?.Session.Remove(this.tokenSessao);
        }
    }
}
