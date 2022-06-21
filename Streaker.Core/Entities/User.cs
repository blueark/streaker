using Streaker.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Streaker.Core.Entities
{
    /// <summary>
    /// Information about a user on whose behalf the code is running.
    /// </summary>
    public class User : EntityBase<int>, IIdentity
    {
        public string? Name { get; set; }

        [NotMapped]
        public string? AuthenticationType { get; set; }

        [NotMapped]
        public bool IsAuthenticated { get; set; }
    }
}
