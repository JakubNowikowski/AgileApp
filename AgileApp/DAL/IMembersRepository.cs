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
		void AddMember(int memberId, string memberName, string description, string position, string extraSkills);
		void DeleteMember(int memberId);
		Member GetMemberById(int id);
		List<Member> GetMembers();
		List<Member> GetMembersByPosition(string position);
        void UpdateMember(Member member, string description, string position, string extraSkills);
	}
}
