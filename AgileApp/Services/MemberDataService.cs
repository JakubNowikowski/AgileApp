using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileApp.DAL;
using AgileApp.Models;

namespace AgileApp.Services
{
	public class MemberDataService : IMemberDataService
	{
		IMembersRepository repository = new MembersRepository();

		public MemberDataService()
		{
			this.repository = repository;
		}

		public Member GetMemberDetail(int memberId)
		{
			return repository.GetMemberById(memberId);
		}

		public List<Member> GetAllMembers()
		{
			return repository.GetMembers2();
		}

		public void UpdateMember(Member member)
		{
			repository.UpdateMember(member);
		}

		public void DeleteMember(Member member)
		{
			repository.DeleteMember(member);
		}
	}
}
