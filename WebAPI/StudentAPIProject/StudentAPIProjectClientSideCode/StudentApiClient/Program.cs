
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json; //This lib do ser ans aser to the jason data acoming from the server, this is for .net core 8
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using StudentApiClient;
//using Newtonsoft.Json;

namespace StudentApiClient
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7258/api/Student/"); // Set this to the correct URI for your API
                                                                                     // You can run with https, its more secure, but will change the endpoint

            await GetAllStudents();
            await GetPassedStudents();
            await GetAverageGrade();
            await GetStudentById(1);

            var newStudent = new Student { Name = "Mazen Abdullah", Age = 20, Grade = 85 }; //There is no constructor in here so you can leave the id empty.
            await AddStudent(newStudent); // Example: Add a new student

            //this will show all students after adding new one
            await GetAllStudents();

            //this will delete student 1
            await DeleteStudent(1); // Example: Delete student with ID 1

            //this will show all students after deleting student 1
            await GetAllStudents();

            //this will Update student 2
            await UpdateStudent(2, new Student { Name = "Salma", Age = 22, Grade = 90 }); // Example: Update student with ID 2

            //this will show all students after Updating student 2
            await GetAllStudents();


        }

        static async Task GetAllStudents()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching all students...\n");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("All");
                if (students != null)
                {
                    foreach (var student in students) // Because it is ienumerable
                    { 
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Age: {student.Grade}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task GetPassedStudents()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching passed students...\n");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("Passed");
                if (students != null)
                {
                    foreach (var student in students) // Because it is ienumerable
                    { 
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Age: {student.Grade}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task GetAverageGrade()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching average grade...\n");
                var averageGrade = await httpClient.GetFromJsonAsync<float>("AverageGrade");
                Console.WriteLine($"Average Grade: {averageGrade}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task GetStudentById(int id)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nFetching student with ID {id}...\n");

                var response = await httpClient.GetAsync($"{id}");

                if (response.IsSuccessStatusCode)
                {
                    var student = await response.Content.ReadFromJsonAsync<Student>();
                    if (student != null)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine($"Bad Request: Not accepted ID {id}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Not Found: Student with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task AddStudent(Student newStudent)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nAdding a new student...\n");

                var response = await httpClient.PostAsJsonAsync("", newStudent);

                if (response.IsSuccessStatusCode)
                {
                    var addedStudent = await response.Content.ReadFromJsonAsync<Student>();
                    Console.WriteLine($"Added Student - ID: {addedStudent.Id}, Name: {addedStudent.Name}, Age: {addedStudent.Age}, Grade: {addedStudent.Grade}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Bad Request: Invalid student data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task DeleteStudent(int id)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nDeleting student with ID {id}...\n");
                var response = await httpClient.DeleteAsync($"{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Student with ID {id} has been deleted.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine($"Bad Request: Not accepted ID {id}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Not Found: Student with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task UpdateStudent(int id, Student updatedStudent)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nUpdating student with ID {id}...\n");
                var response = await httpClient.PutAsJsonAsync($"{id}", updatedStudent);

                if (response.IsSuccessStatusCode)
                {
                    var student = await response.Content.ReadFromJsonAsync<Student>();
                    Console.WriteLine($"Updated Student: ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Failed to update student: Invalid data.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int  Grade { get; set; }
    }
}
//The three pieces
//async is a modifier on a method that tells the compiler "this method contains operations that may take time, and I want to pause it without blocking the thread while waiting." It doesn't make code run in parallel by itself — it enables the use of await inside the method.
//Task is the return type representing "a unit of work that will complete in the future." Think of it like a promise: "I don't have the result yet, but I will." There are two flavors:

//Task — represents an operation that completes but returns no value (like void, but awaitable)
//Task<T> — represents an operation that will eventually return a value of type T

//await pauses execution of the current method until the awaited Task completes — but crucially, it does not block the thread. The thread is freed up to go do other work (handle UI events, serve other requests, etc.), and when the awaited operation finishes, execution resumes right where it left off.
//Why it's used in your code
//csharpstatic async Task Main(string[] args)
//{
//    httpClient.BaseAddress = new Uri("http://localhost:5215/api/Students");
//    await GetAllStudents();
//}

//GetAllStudents() almost certainly makes an HTTP call (via httpClient) to your API — network calls are I/O-bound and take unpredictable time.
//If you called it synchronously, the calling thread would sit idle, blocked, doing nothing productive while waiting for the response.
//By marking Main as async Task and using await GetAllStudents(), the program asynchronously waits for the API call to finish without wasting the thread, then continues once the data comes back.
//Main has to return Task (not void) here because await can only be used inside a method marked async, and modern C# allows Main itself to be async Task so you can await directly in your entry point instead of needing .Wait() or .Result (which can cause deadlocks).