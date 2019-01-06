using AgileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp.DAL
{
	interface IMembersRepository
	{
		void DeleteMember(Member member);
		Member GetAMember();
		Member GetMemberById(int id);
		List<Member> GetMembers();
		void UpdateMember(Member member);
	}
}
