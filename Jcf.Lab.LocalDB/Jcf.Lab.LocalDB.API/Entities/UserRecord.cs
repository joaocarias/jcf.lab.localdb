using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.LocalDB.API.Entities
{
    public record UserRecord
    (        
        string Name,
        string Email,
        string Password
    );
}
