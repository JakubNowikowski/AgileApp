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

		public void DeleteMember(int memberId)
		{
			doc.Descendants("Member").Where(x => x.Element("ID").Value == memberId.ToString()).Remove();
			doc.Save(@"C:\Users\Kuba\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");
			LoadMembers2();
		}

		public void AddMember(int memberId, string memberName, string description, string position, string extraSkills)
		{
			XElement root = new XElement("Member");
			root.Add
				(
				new XElement("ID", memberId.ToString()),
				new XElement("Name", memberName),
				new XElement("Description", description),
				new XElement("Position", position),
				new XElement("ExtraSkills", extraSkills)
				);

			doc.Element("Members").Add(root);

			doc.Save(@"C:\Users\Kuba\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");
			LoadMembers2();
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

			members = new List<Member>();
			members.Clear();
			IEnumerable<XElement> memberProp;
			List<string> membersIDs = new List<string>();

			int membersCount = doc.Descendants("Member").Count();
			membersIDs = doc.Descendants("Member").Select(x => x.Element("ID").Value).ToList();


			for (int i = 0; i <= membersCount-1; i++)
			{

				memberProp =
				   (from e in doc.Descendants("Member")
					where e.Element("ID").Value == membersIDs[i]
					select e).Descendants();


				members.Add(new Member()
					{
						MemberId = Convert.ToInt32(membersIDs[i]),
						MemberName = memberProp.ElementAt(1).Value,
						Description = memberProp.ElementAt(2).Value,
						ImageId = 2,
						Position = memberProp.ElementAt(3).Value,
						ExtraSkills = memberProp.ElementAt(4).Value,

						//MemberId = i,
						//MemberName = i.ToString(),
						//Description = i.ToString(),
						//ImageId = 2,
						//Position = i.ToString(),
						//ExtraSkills = i.ToString(),

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
