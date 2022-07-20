using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetAllMembers() => MemberDAO.GetMembers();

        public void createMember(Member mem) => MemberDAO.createMem(mem);

        public void updateMember(Member mem) => MemberDAO.updateMem(mem);

        public void deleteMember(Member mem) => MemberDAO.deleteMember(mem);

        public void deleteMemberById(int memId) => MemberDAO.RemoveMember(memId);

        public Member getMemById(int memId) => MemberDAO.getMemberById(memId);

        public Member getMemberByEmail(string email) => MemberDAO.getMemberByEmail(email);  

        public Member getMemberByPasswordAndEmail(string email, string password) => MemberDAO.getMemberByPasswordAndEmail(email, password);
    }
}
