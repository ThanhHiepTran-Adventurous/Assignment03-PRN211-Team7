using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess
{
    public class MemberDAO
    {
        public static List<Member> GetMembers()
        {
           var listMembers = new List<Member>();
            try
            {
                using (var dbcontext = new SalesManagementDBContext())
                {
                    listMembers = dbcontext.Members.ToList();
                }
            }catch(Exception ex)
            {
                throw new Exception("Load fail");
            }
            return listMembers;
        }
        //-----------------------------------------------------
        public static Member getMemberById(int memberId)
        {
            Member member = null;
            try
            {
                using(var dbContext = new SalesManagementDBContext())
                {
                    member = dbContext.Members.SingleOrDefault(m => m.MemberId == memberId);
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        //------------------------------------------------------
        public static Member getMemberByEmail(string memberEmail)
        {
            Member mem = null;
            try
            {
                using(var dbContext = new SalesManagementDBContext())
                {
                    mem = dbContext.Members.SingleOrDefault(m => m.Email.Equals(memberEmail));
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }  
            return mem;
        }
        //------------------------------------------------------
        public static Member getMemberByPasswordAndEmail(string email, string password)
        {
            Member member1 = null;
            try
            {
                using (var context = new SalesManagementDBContext())
                {
                    member1 = context.Members.SingleOrDefault(m => m.Email.Equals(email) && m.Password.Equals(password));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member1;
        }

        //------------------------------------------------------
        public static void createMem(Member m)
        {
            Member memId = new Member();
            Member memberEmail = new Member();
            memId = getMemberById(m.MemberId);
            memberEmail = getMemberByEmail(m.Email);
            if(memId == null && memberEmail == null)
            {
                try
                {
                    using(var dbContext = new SalesManagementDBContext())
                    {
                        dbContext.Members.Add(m);
                        dbContext.SaveChanges();
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if(memId != null)
            {
                throw new Exception("ID is already Exists!!");
            }else if (memberEmail != null)
            {
                throw new Exception("Email is already Exists!!");
            }
        }
        //---------------------------------------------------
        public static void updateMem(Member mem)
        {
            try
            {
                SalesManagementDBContext dbContext = new SalesManagementDBContext();
                dbContext.Members.Update(mem);
                dbContext.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //-----------------------------------------------------------------------
        public static void deleteMember(Member mem)
        {
            try
            {
                SalesManagementDBContext dBContext = new SalesManagementDBContext();
                var member = dBContext.Members.SingleOrDefault(m => m.MemberId == mem.MemberId);
                dBContext.Members.Remove(member);
                dBContext.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //-----------------------------------------------
        public static void RemoveMember(int memId)
        {
            try
            {
                using(var dbContext = new SalesManagementDBContext())
                {
                    var mem = dbContext.Members.SingleOrDefault(m => m.MemberId == memId);
                    dbContext.Members.Remove(mem);
                    dbContext.SaveChanges();
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
