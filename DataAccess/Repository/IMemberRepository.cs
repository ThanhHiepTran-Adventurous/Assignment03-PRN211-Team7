using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();

        void createMember(Member mem);

        void deleteMember(Member mem);

        void updateMember(Member mem);

        void deleteMemberById(int memId);

        Member getMemById(int memId);

        Member getMemberByEmail(string email);

        Member getMemberByPasswordAndEmail(string email, string password);


    }
}
