using Microsoft.AspNetCore.Components;
using ToDoListProject.Models;


namespace ToDoListProject.Components.Pages
{
    public partial class EmployeeEdit : ComponentBase
    {
        public Employee employee = new Employee();

        [Parameter]
        public string id { get; set; } // Define id as string initially
        private int parsedId;

        protected override async Task OnInitializedAsync()
        {
            if (id != null)
                parsedId = int.Parse(id);     //EDIT
            else parsedId = 0;                //Create  

            employee= await EmployeeService.GetEmployeeByIdAsync(int.Parse(id));
           // employee = people.FirstOrDefault(m => m.id == parsedId);
            if (employee == null)
            {
                employee = new Employee();
            }
        }
        private async Task EditEmployee(int id)
        {
            var employee = await EmployeeService.GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                await EmployeeService.UpdateEmployeeAsync(employee);
                 await EmployeeService.GetEmployeesAsync(); // Refresh the list
            }
        }


    }
}