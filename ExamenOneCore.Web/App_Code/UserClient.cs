using ExamenOneCore.Entity.Models;
using ExamenOneCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOneCore.Web.App_Code
{
    public partial class ApiClient
    {
        public async Task<List<UsuarioModel>> GetUsers()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/Get"));
            return await GetAsync<List<UsuarioModel>>(requestUrl);
        }

        public async Task<string> CreateUser(UsuarioModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/CreateUser"));
            return await PostAsyncStr<UsuarioModel>(requestUrl, model);
        }

        public async Task<string> UpdateUser(EditUsuarioModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/UpdateUser"));
            return await PostAsyncStr<EditUsuarioModel>(requestUrl, model);
        }

        public async Task<string> ChangePassword(ChangePasswordModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/ChangePassword"));
            return await PostAsyncStr<ChangePasswordModel>(requestUrl, model);
        }

        public async Task<string> VerificaUsuario(EditUsuarioModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/VerificaUsuario"));
            return await PostAsyncStr<EditUsuarioModel>(requestUrl, model);
        }

        public async Task<string> VerificaEmail(EditUsuarioModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/VerificaEmail"));
            return await PostAsyncStr<EditUsuarioModel>(requestUrl, model);
        }

        public async Task<string> Delete(DeleteUsuarioModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/DeleteUser"));
            return await PostAsyncStr<DeleteUsuarioModel>(requestUrl, model);
        }

        public async Task<string> Login(LoginModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/Login"));
            return await PostAsyncStr<LoginModel>(requestUrl, model);
        }
    }
}