using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AgileApp.Models;

namespace AgileApp.DAL
{
	class MembersRepository : IMembersRepository
	{

		private static XDocument doc;

		private static List<Member> members = null;

		public MembersRepository()
		{

		}

		public Member GetAMember()
		{
			if (members == null)
				LoadMembers2();
			return members.FirstOrDefault();
		}

		public List<Member> GetMembers2()
		{
			if (members == null)
				LoadMembers2();
			return members;
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
				LoadMembers2();
			return members.Where(c => c.MemberId == id).FirstOrDefault();
		}
		public void DeleteMember(Member member)
		{
			members.Remove(member);
			doc.Save("MembersSource");
		}

		public void UpdateMember(Member member)
		{
			Member memberToUpdate = members.Where(c => c.MemberId == member.MemberId).FirstOrDefault();
			memberToUpdate = member;
		}

		private void LoadMembers()
		{
		}

		private void LoadMembers2()
		{
			doc = XDocument.Load(@"C:\Users\Kuba\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");

			members = new List<Member>()
			{
				new Member ()
				{
					MemberId = 0,
					MemberName = "nul",
					Description ="nul",
					ImageId = 2,
					Position="nul",
					ExtraSkills="nul",
				}

			};

			IEnumerable<XElement> member;

			int membersCount = doc.Descendants("Member").Count();

			for (int i = 1; i <= membersCount; i++)
			{

				member =
					   (from e in doc.Descendants("Member")
						where e.Attribute("id").Value == i.ToString()
						select e).Descendants();

				members.Add(new Member() {
					MemberId = i,
					MemberName = member.ElementAt(0).Value,
					Description = member.ElementAt(1).Value,
					ImageId = 2,
					Position = member.ElementAt(2).Value,
					ExtraSkills = member.ElementAt(3).Value,

				});

				//members = new List<Member>()
				//{
				//	new Member ()
				//	{
				//		MemberId = i,
				//		MemberName = member.ElementAt(0).Value,
				//		Description =member.ElementAt(1).Value,
				//		ImageId = 2,
				//		Position=member.ElementAt(2).Value,
				//		ExtraSkills=member.ElementAt(3).Value,
				//	}

				//};

			}



			//members = new List<Member>()
			//{
			//	new Member ()
			//	{
			//		MemberId = 1,
			//		MemberName = member.ElementAt(0).Value,
			//		Description = "User1 description",
			//		ImageId = 2,
			//		Position="Junior .NET Developer",
			//		ExtraSkills="Testing",
			//	},
			//	new Member ()
			//	{
			//		MemberId = 2,
			//		MemberName = "User2",
			//		Description = "User2 description",
			//		ImageId = 2,
			//		Position="Java, Python Developer",
			//		ExtraSkills ="PiWeb",
			//	},
			//	new Member ()
			//	{
			//		MemberId = 3,
			//		MemberName = "User3",
			//		Description = "User3 description",
			//		ImageId = 2,
			//		Position="Tester, .NET Developer",
			//		ExtraSkills="AI Specialist",
			//	},
			//	new Member ()
			//	{
			//		MemberId = 4,
			//		MemberName = "User4",
			//		Description = "User4 description",
			//		ImageId = 2,
			//		Position="Junior .NET Developer",
			//		ExtraSkills="Testing",
			//	},
			//	new Member ()
			//	{
			//		MemberId = 5,
			//		MemberName = "User5",
			//		Description = "User5 description",
			//		ImageId = 2,
			//		Position="Java, Python Developer",
			//		ExtraSkills ="PiWeb",
			//	},
			//	new Member ()
			//	{
			//		MemberId = 6,
			//		MemberName = "User6",
			//		Description = "User6 description",
			//		ImageId = 2,
			//		Position="Tester, .NET Developer",
			//		ExtraSkills="AI Specialist",
			//	}
			//};

		}
	}
}
