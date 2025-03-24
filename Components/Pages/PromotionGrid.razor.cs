using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using System.Collections.Generic;
using ToDoListProject.Models;
using ToDoListProject.ServiceDomain;

namespace ToDoListProject.Components.Pages
{
    public partial class PromotionGrid
    {
        [Parameter]
        public EventHandler<int> OnEmployeeDeleted { get; set; }

        private IQueryable<Employee> people = Enumerable.Empty<Employee>().AsQueryable();
        protected override async Task OnInitializedAsync()
        {
            people = (await EmployeeService.GetEmployeesAsync()).AsQueryable();
        }
        protected Confirm DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }
        //public async Task DeleteEmp( bool deleteConfirmed)
        //{
        //    if (deleteConfirmed)
        //    {


        //    }
        //}
        private async Task DeleteEmployee(int id)
        {
            // Call the service to delete the employee
            await EmployeeService.DeleteEmployeeAsync(id);

            // Refresh the data after deletion
            var employeeList = await EmployeeService.GetEmployeesAsync();
            people = employeeList.AsQueryable();
        }

        private void NavigateToEdit(int id)
        {
            Navigation.NavigateTo($"editemployee/{id}");
        }

        PaginationState pagination = new PaginationState { ItemsPerPage = 6 };


        private QuickGrid<TodoItem>? movieGrid;
        private string titleFilter = string.Empty;
        private IQueryable<TodoItem> movies = new List<TodoItem>
        {
            new TodoItem("Watch The Matrix", false),
            new TodoItem("Read Clean Code", true),
            new TodoItem("Build a Blazor app", false),
            new TodoItem("Go for a run", true),
            new TodoItem("Plan weekend trip", false)
        }.AsQueryable();

        // Filtered movies based on title
        private IQueryable<TodoItem> filteredMovies =>
            movies.Where(m => !string.IsNullOrEmpty(m.Title) && m.Title.Contains(titleFilter, StringComparison.OrdinalIgnoreCase));

    }
}