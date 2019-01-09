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
		void AddMember(int memberId);
		void DeleteMember(int memberId);
		Member GetAMember();
		Member GetMemberById(int id);
		List<Member> GetMembers2();
		List<Member> GetMembers();
		void UpdateMember(Member member);
	}
}
