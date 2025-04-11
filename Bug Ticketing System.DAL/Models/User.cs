using Microsoft.AspNetCore.Identity;

namespace Bug_Ticketing_System.DAL;

public class User:IdentityUser
{
	public virtual ICollection<Bug_User> Bug_Users { get; set; }=new HashSet<Bug_User>();
	
}
