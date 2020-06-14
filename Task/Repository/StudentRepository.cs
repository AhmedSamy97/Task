using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task.Controllers;
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
            CascadeStudentTeachers(std);
            db.SaveChanges();
        }

        public void Edit(CreateStudent studentData)
        {
            var std = db.Students.Find(studentData.Student.ID);
            std.Name = studentData.Student.Name;
            std.BirthDate = studentData.Student.BirthDate;
            std.GovernorateId = studentData.Student.GovernorateId;
            std.NeighborhoodId = studentData.Student.NeighborhoodId;
            std.FieldId = studentData.Student.FieldId;

            CascadeStudentTeachers(studentData.Student);

            foreach (var item in studentData.TeacherId)
            {
                db.StudentTeachers.Add(new StudentTeacher() {StudentId = std.ID, TeacherId = item});
            }
            db.SaveChanges();

        }

        private void CascadeStudentTeachers(Student std)
        {
            var stdTeachers = db.StudentTeachers.Where(a => a.StudentId == std.ID).ToList();
            foreach (var item in stdTeachers)
            {
                db.StudentTeachers.Remove(item);
            }
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