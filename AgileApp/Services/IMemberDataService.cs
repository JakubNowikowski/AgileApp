using AgileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.Services
{
	public interface IMemberDataService
	{
		void DeleteMember(int memberId);
		List<Member> GetAllMembers();
		Member GetMemberDetail(int memberId);
		void UpdateMember(Member member);
	}
}
