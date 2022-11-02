using Domain.Entities.Identity;

namespace Application.Specifications
{
    public class UserDetailsSpecification : BaseSpecification<AppUser>
    {
        public UserDetailsSpecification(string userId) :base(x => x.Id == userId)
        {
            AddInclude(x => x.UserDetails);
        }
    }
}