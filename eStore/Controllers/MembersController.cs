using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using DataAccess.Repository;
using System;

namespace eStore.Controllers
{
    public class MembersController : Controller
    {

        IMemberRepository _memberRepository = null;

        public MembersController() => _memberRepository = new MemberRepository();
        // GET: MembersController
        public ActionResult Index()
        {
            var memberList = _memberRepository.GetAllMembers();
            return View(memberList);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var mem = _memberRepository.getMemById(id.Value);
            if(mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member mem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _memberRepository.createMember(mem);

                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var member = _memberRepository.getMemById(id.Value);
            if(member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member mem)
        {
            try
            {
                if(id != mem.MemberId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _memberRepository.updateMember(mem);
                }
                TempData["complete"] = "Completed";

                if (HttpContext.Session.GetInt32("role") == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Details", "Members", new { id = HttpContext.Session.GetInt32("id") });
                }
               // return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var mem = _memberRepository.getMemById(id.Value);
            if(mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int memberId)
        {
            try
            {
                _memberRepository.deleteMemberById(memberId);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
