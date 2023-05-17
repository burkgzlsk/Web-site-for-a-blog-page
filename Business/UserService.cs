using BBloGer.Models;
using BBloGer.Models.Context;
using BBloGer.Models.Entiteis;

namespace BBloGer.Bussines
{
    public class UserService
    {
        private DatabaseContext _db = new DatabaseContext();
        public ServiceResult<object> Register(RegisterViewModel model)
        {
            ServiceResult<object> result = new ServiceResult<object>();
            model.Username = model.Username.Trim().ToLower();

            if (_db.Users.Any(x=> x.Email.ToLower() == model.Email.ToLower()))
            {
                result.AddError($"'{model.Email}' adresi zaten kullanıyor.");
                return result;

            }

            if(_db.Users.Any(x => x.UserName.ToLower() == model.Username.ToLower()))
            {
                result.AddError($"'{model.Username}' kullanıcı adı zaten kayıtlıdır");
                return result;
            }

            _db.Users.Add(new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = model.Password,
                IsActive = true,
                IsAdmin = false,
                CreatedAt = DateTime.Now ,
                CreateUser = "register"
            });

            if (_db.SaveChanges() == 0)
            {   
                result.AddError("Kayıt Yapılamadı.");
            }
            return result;
        }

        public ServiceResult<User> Login(LoginViewModel model)
        {
            ServiceResult<User> result = new ServiceResult<User>();

            model.Username = model.Username.Trim().ToLower();

            User user = _db.Users.SingleOrDefault(x => x.UserName.ToLower() == model.Username && x.Password == model.Password);

            if (user == null)
            {
                result.AddError("Hatalı kullanıcı adı ya da şifre");
            }
            else
            {
                user.Password = string.Empty;
                result.Data = user;
            }


            return result;
        }
    }
}
