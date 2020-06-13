using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ArmyTechTaskEntities db;

        public StudentRepository(ArmyTechTaskEntities db)
        {
            this.db = db;
        }

        public void add(Student std)
        {
            db.Students.Add(std);
            db.SaveChanges();
        }

        public void Delete(Student std)
        {
            db.Students.Remove(std);

            var stdTeachers = db.StudentTeachers.Where(a => a.StudentId == std.ID).ToList();
            foreach (var item in stdTeachers)
            {
                db.StudentTeachers.Remove(item);
            }
            db.SaveChanges();
        }

        public void Edit(Student student)
        {
            var std = db.Students.Find(student.ID);
            std.Name = student.Name;
            std.BirthDate = student.BirthDate;
            std.GovernorateId = student.GovernorateId;
            std.NeighborhoodId = student.NeighborhoodId;
            std.FieldId = student.FieldId;
            db.SaveChanges();



        }

        public IEnumerable<Student> getAll()
        {
            return db.Students.Include(s => s.Field).Include(s => s.Governorate).Include(a=>a.StudentTeachers).ToList();
        }

        public Student getByID(int id)
        {
            return db.Students.Find(id);
        }
    }
}