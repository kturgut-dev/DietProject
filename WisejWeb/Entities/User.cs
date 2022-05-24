using Core.Entities.Abstract;

namespace DietProject.WisejWeb.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string EPosta { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string VerifyToken { get; set; }
        public bool IsAdmin { get; set; }
        public string UniqToken => ID.ToString().MD5Encrypt();//herkesın kendıne aıt gizli bi token olsun diye
    }
}
