using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileApp.Models;

namespace AgileApp.DAL
{
	class MembersRepository : IMembersRepository
	{
		private static List<Member> members;

		public MembersRepository()
		{

		}

		public Member GetAMember()
		{
			if (members == null)
				LoadMembers();
			return members.FirstOrDefault();
		}

		public List<Member> GetMembers()
		{
			if (members == null)
				LoadMembers();
			return members;
		}

		public Member GetMemberById(int id)
		{
			if (members == null)
				LoadMembers();
			return members.Where(c => c.MemberId == id).FirstOrDefault();
		}
		public void DeleteMember(Member member)
		{
			members.Remove(member);
		}

		public void UpdateMember(Member member)
		{
			Member memberToUpdate = members.Where(c => c.MemberId == member.MemberId).FirstOrDefault();
			memberToUpdate = member;
		}

		private void LoadMembers()
		{
			members = new List<Member>()
			{
				new Member ()
				{
					MemberId = 1,
					MemberName = "User1",
					Description = "User1 description",
					ImageId = 2,
					Position="Junior .NET Developer",
					ExtraSkills="Testing",
					InStock = true,
					Price = 12
				},
				new Member ()
				{
					MemberId = 2,
					MemberName = "User2",
					Description = "User2 description",
					ImageId = 2,
					Position="Java, Python Developer",
					ExtraSkills ="PiWeb",
					InStock = true,
					Price = 12
				},
				new Member ()
				{
					MemberId = 3,
					MemberName = "User3",
					Description = "User3 description",
					ImageId = 2,
					Position="Tester, .NET Developer",
					ExtraSkills="AI Specialist",
					InStock = true,
					Price = 12
				},
				new Member ()
				{
					MemberId = 4,
					MemberName = "User4",
					Description = "User4 description",
					ImageId = 2,
					Position="Junior .NET Developer",
					ExtraSkills="Testing",
					InStock = true,
					Price = 12
				},
				new Member ()
				{
					MemberId = 5,
					MemberName = "User5",
					Description = "User5 description",
					ImageId = 2,
					Position="Java, Python Developer",
					ExtraSkills ="PiWeb",
					InStock = true,
					Price = 12
				},
				new Member ()
				{
					MemberId = 6,
					MemberName = "User6",
					Description = "User6 description",
					ImageId = 2,
					Position="Tester, .NET Developer",
					ExtraSkills="AI Specialist",
					InStock = true,
					Price = 12
				}
			};

		}
	}
}
