using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Accompany_consulting.Models
{
    public class IdentityRole : IdentityRole<string>, IRole<string>
    {
        // ...
    }

}
