using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;
        private readonly IFieldRepository frepo;
        private readonly IGovernoratesRepository grepo;
        private readonly INeighborhoodsRepository nrepo;
        private readonly ITeacherRepository trepo;
        private readonly IStudentTeacherRespository strepo;

        public StudentController()
        {
            repo = new StudentRepository(new ArmyTechTaskEntities());
            frepo = new FieldRepository(new ArmyTechTaskEntities());
            grepo = new GovernoratesRepository(new ArmyTechTaskEntities());
            nrepo = new NeighborhoodsRepository(new ArmyTechTaskEntities());
            trepo = new TeacherRepository(new ArmyTechTaskEntities());
            strepo = new StudentTeachersRepository(new ArmyTechTaskEntities());
        }

        // GET: Student
        public ActionResult Index()
        {
           

            return View(repo.getAll());
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.FieldId = new SelectList(frepo.getAll(), "ID", "Name");
            ViewBag.GovernorateId = new SelectList(grepo.getAll(), "ID", "Name");
            ViewBag.NeighborhoodId = new SelectList(nrepo.getAll(), "ID", "Name");
            ViewBag.StudentTeachers = new SelectList(trepo.getAll(),"ID","Name");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStudent sstd)
        {
            

            if (ModelState.IsValid)
            {
                repo.add(sstd.Student);
                foreach (var TeacherId in sstd.TeacherId)
                {
                     strepo.AddTeacherToStudent(new StudentTeacher() { StudentId = sstd.Student.ID, TeacherId =TeacherId});

                }
                return RedirectToAction("Index");
            }
            ViewBag.FieldId = new SelectList(frepo.getAll(), "ID", "Name", sstd.Student.FieldId);
            ViewBag.GovernorateId = new SelectList(grepo.getAll(), "ID", "Name", sstd.Student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(nrepo.getAll(), "ID", "Name", sstd.Student.NeighborhoodId);
            ViewBag.selected = new SelectList(nrepo.getAll(), "ID", "Name", sstd.Student.ID);
            ViewBag.StudentTeachers = new SelectList(trepo.getAll(), "ID", "Name");
            return View(sstd);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            Student student = repo.getByID(id.Value);
            var teacher = trepo.getAll();
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.FieldId = new SelectList(frepo.getAll(), "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(grepo.getAll(), "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(nrepo.getAll(), "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            var std = repo.getByID(student.ID);
            if (std == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                repo.Edit(student);
                return RedirectToAction("Index");
            }
            ViewBag.FieldId = new SelectList(frepo.getAll(), "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(grepo.getAll(), "ID", "Name", student.GovernorateId);
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = repo.getByID(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                repo.Delete(student);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}