using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _01StudentAPIProjectv1_GetALL.Model;
using _01StudentAPIProjectv1_GetALL.StudentDataSimulation;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;

namespace _01StudentAPIProjectv1_GetALL.Controllers
{
    [ApiController] // Marks the class as a Web API controller with enhanced features.
                    //  [Route("[controller]")] // Sets the route for this controller to "Student", based on the controller name.
    [Route("api/Student")]
    //  [ApiConventionType(typeof(DefaultApiConventions))] هوا من وحده يوثق وما راح يخطأ بس ما يفيد اذا حبيت ترجع كود ما معروف وغير امور تكدر تبحث عنها


    public class StudentController : ControllerBase // Declare the controller class inheriting from ControllerBase.
    {

        //
        // here we use HttpGet method
        //

        [HttpGet("All", Name = "GetAllStudent")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        // Method to get all Student who passed
        public ActionResult<IEnumerable<Student>> GetAllStudent() // Define a method to get all Student.
        {
            //clsStudentDataSimulation.StudentList.Clear();

            if (clsStudentDataSimulation.StudentList.Count == 0)
            {
                return NotFound("No Student Found!");
            }
            return Ok(clsStudentDataSimulation.StudentList); // Returns the list of Student.
        }

        [HttpGet("Passed", Name = "GetPassedStudent")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<Student>> GetPassedStudent()

        {
            var passedStudent = clsStudentDataSimulation.StudentList.Where(student => student.Grade >= 50).ToList();
            //passedStudent.Clear();

            if (passedStudent.Count == 0)
            {
                return NotFound("No Student Passed");
            }


            return Ok(passedStudent); // Return the list of Student who passed.
        }

        [HttpGet("AverageGrade", Name = "GetAverageGrade")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<double> GetAverageGrade()
        {

            //   clsStudentDataSimulation.StudentList.Clear();

            if (clsStudentDataSimulation.StudentList.Count == 0)
            {
                return NotFound("No Student found.");
            }

            var averageGrade = clsStudentDataSimulation.StudentList.Average(student => student.Grade);
            return Ok(averageGrade);
        }


        [HttpGet("{id}", Name = "GetStudentById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(clsStudentDataSimulation), StatusCodes.Status200OK)] بيظهر الحاله + نوع البيانات
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<Student> GetStudentById(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            var student = clsStudentDataSimulation.StudentList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            return Ok(student);
        }

        //
        //here we use HttpPush method
        //
        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            //we validate the data here
            if (newStudent == null || string.IsNullOrEmpty(newStudent.Name) || newStudent.Age < 0 || newStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            newStudent.Id = clsStudentDataSimulation.StudentList.Count > 0 ? clsStudentDataSimulation.StudentList.Max(s => s.Id) + 1 : 1;
            clsStudentDataSimulation.StudentList.Add(newStudent);

            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("GetStudentById", new { id = newStudent.Id }, newStudent);

        }

        //
        //here we use HttpDelete method
        //

        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            var student = clsStudentDataSimulation.StudentList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            clsStudentDataSimulation.StudentList.Remove(student);
            return Ok($"Student with ID {id} has been deleted.");
        }

        //
        //here we use http put method for update
        //

        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> UpdateStudent(int id, Student updatedStudent)
        {
            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            var student = clsStudentDataSimulation.StudentList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;

            return Ok(student);
        }
    }
}



// ----------------------------
// ActionResult & IActionResult
// ----------------------------

//## IActionResult
//- Non-generic wrapper, just carries a status code (data is optional, not type-checked)
//- Use it when the method **doesn't need to return data** on success — e.g. `DELETE`
//- Swagger needs `[ProducesResponseType]` manually since it can't infer the type

//## ActionResult\<T>
//- Generic wrapper, carries status code **+** typed data
//- Use it whenever the method **should return data** on success — e.g. `GET`, `POST`, `PUT`
//- Swagger auto-detects the type `<T>` and documents it for you

//**Rule of thumb:**returning data → `ActionResult<T>`. Just a status → `IActionResult`.



// --------------
// CreatedAtRoute
// --------------

//`CreatedAtRoute` is used after a `POST` to say: *"created it, here's where to find it, here it is." *

//Returns 3 things together:
//-**`201 Created`** status
//- **`Location` header** — URL to `GET` it later
//- **The resource data** in the body

//```csharp
//return CreatedAtRoute(
//    "GetStudentById",                    // matches the Name on a [HttpGet] route
//    new { StudentID = NewStudent.Id },   // fills the route's {StudentID} param — name must match exactly
//    NewStudent                           // data sent in the response body
//);
//```

//**vs `Ok()`:** `Ok()` just says "done." `CreatedAtRoute` says "done + here's the URL + here's the data."

//**Use for:** `POST` when you have a matching `GET-by-ID` route.
//**Don't use for:** `GET`, `PUT`, `DELETE`.

//**vs `Created`:** `Created` needs the URL typed manually; `CreatedAtRoute` generates it automatically from the route name — cleaner and less error-prone.



// -------------------------------
// | Method | Where data goes    |
// -------------------------------

// |--------|--------------------|
// | GET    | Route (URL)        |
// | POST   | Body               |
// | PUT    | Body               |
// | DELETE | Route (usually ID) |