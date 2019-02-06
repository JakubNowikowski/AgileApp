using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AgileApp.Models;

namespace AgileApp.DAL
{
    class MembersRepository : IMembersRepository
	{
		IEnumerable<XElement> memberProp;
		List<string> membersIDs = new List<string>();

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


			doc.Save(@"C:\Users\kuban\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");
			LoadMembers2();
		}

		public void AddMember(int memberId, string memberName, string description, string position, string extraSkills)
		{
			List<int> membersIDs = new List<int>();

			int membersCount = doc.Descendants("Member").Count();
			membersIDs = doc.Descendants("Member").Select(x => Convert.ToInt32(x.Element("ID").Value)).ToList();
			membersIDs.Sort();

			int newMemberID = 1;

			if (membersIDs.Count == 1)
				newMemberID = 2;

			for (int i = 1; i < membersIDs.Count; i++)
				if (membersIDs[i] - membersIDs[i - 1] != 1)
				{
					newMemberID = i + 1;
				}
				else
				{
					newMemberID = membersIDs.Max() + 1;
				}

			XElement root = new XElement("Member");
			root.Add
				(
				new XElement("ID", newMemberID.ToString()),
				new XElement("Name", memberName),
				new XElement("Description", description),
				new XElement("Position", position),
				new XElement("ExtraSkills", extraSkills)
				);

			doc.Element("Members").Add(root);

			doc.Save(@"C:\Users\kuban\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");
			LoadMembers2();
		}

		public void UpdateMember(Member member,string description, string position, string extraSkills)
		{
			//Member memberToUpdate = members.Where(c => c.MemberId == member.MemberId).FirstOrDefault();
			//memberToUpdate = member;

			memberProp =
					   from e in doc.Descendants("Member")
					   where e.Element("ID").Value == member.MemberId.ToString()
					   select e;

			foreach (XElement item in memberProp)
			{
				item.SetElementValue("Description", description);
				item.SetElementValue("Position", position);
				item.SetElementValue("ExtraSkills", extraSkills);
			}
			doc.Save(@"C:\Users\kuban\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");

			LoadMembers2();
		}

		private void LoadMembers()
		{
		}

		private void LoadMembers2()
		{
			doc = XDocument.Load(@"C:\Users\kuban\source\repos\AgileApp\AgileApp\DAL\MembersSource.xml");

			members = new List<Member>();
			members.Clear();
			

			int membersCount = doc.Descendants("Member").Count();
			membersIDs = doc.Descendants("Member").Select(x => x.Element("ID").Value).ToList();

			membersIDs.Sort();

			for (int i = 0; i <= membersCount - 1; i++)
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
				});
			}
		}
	}
}
