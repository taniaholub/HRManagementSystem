

namespace CCL.Security.Identity
{
    public class HR
     : User
    {
        public HR(int userId, string name)
        : base(userId, name, nameof(HR))
        {

        }
    }
}
