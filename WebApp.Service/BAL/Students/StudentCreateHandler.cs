using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Core;

namespace WebApp.Service.BAL
{
    public class StudentCreateHandler
    {
        UnitOfWork unit = new UnitOfWork();
        public async Task<HttpResponseMessage> Handle(StudentCreateCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            var student = new Student
            {
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone
            };

            unit.StudentRepository.InsertOrUpdate(student);
            var result = await unit.StudentRepository.Save();

            HttpResponseMessage response = new HttpResponseMessage();
            if (result != 1)
                response.Content = new StringContent("Not Save");
             else
                response.Content = new StringContent("Sucessfully Save");

            return response;
        }
     }
}
