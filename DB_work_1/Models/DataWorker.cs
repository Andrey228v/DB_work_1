using DB_work_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_work_1.Models
{
    public static class DataWorker
    {

        // Получить все отделы
        public static List<Deportament> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Deportaments.ToList();
                return result;
            }
        }

        // Получить все позиции
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        // Получить всех сотрудников
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        // Создать отдел
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли отдел
                bool checkIsExist = db.Deportaments.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Deportament newDepartment = new Deportament { Name = name };
                    db.Deportaments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // Создать позицию
        public static string CreatePosition(string name, decimal salary, int maxNumber, Deportament department)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли позиция
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExist)
                {
                    Position newPosition = new Position
                    {
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DeportamentId = department.Id
                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // Создать сотрудника
        public static string CreateUser(string name, string surName, string phone, Position position)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check the user is exist
                bool checkIsExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);
                if (!checkIsExist)
                {
                    User newUser = new User
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // Удаление отдела
        public static string DeleteDepartment(Deportament department)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Deportaments.Remove(department);
                db.SaveChanges();
                result = "Сделано! Отдел " + department.Name + " удален";
            }
            return result;
        }

        // Удаление позиции
        public static string DeletePosition(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check position is exist
                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Сделано! Позиция " + position.Name + " удалена";
            }
            return result;
        }

        // Удаление сотрудника
        public static string DeleteUser(User user)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "Сделано! Сотрудник " + user.Name + " уволен";
            }
            return result;
        }

        // Редактирование отдела
        public static string EditDepartment(Deportament oldDepartment, string newName)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Deportament department = db.Deportaments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = "Сделано! Отдел " + department.Name + " изменен";
            }
            return result;
        }
        
        // Редактирование позиции
        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Deportament newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                position.Name = newName;
                position.Salary = newSalary;
                position.MaxNumber = newMaxNumber;
                position.DeportamentId = newDepartment.Id;
                db.SaveChanges();
                result = "Сделано! Позиция " + position.Name + " изменена";
            }
            return result;
        }
        
        // Редактирование сотрудника
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check user is exist
                User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + user.Name + " изменен";
                }
            }
            return result;
        }

    }
}
