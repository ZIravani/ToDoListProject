namespace ToDoListProject.Models
{
    public class PeopleModel
    {
        public List<string> People { get; set; } = new List<string>();

        public void AddPerson(string person)
        {
            if (!string.IsNullOrEmpty(person))
            {
                People.Add(person);
            }
        }
    }
}
