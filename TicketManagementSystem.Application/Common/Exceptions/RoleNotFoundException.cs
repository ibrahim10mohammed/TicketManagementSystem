namespace TicketManagementSystem.Application.Exceptions
{
    public class RoleNotFoundException :Exception
    {
        public RoleNotFoundException(string roleName)
        : base($"The role '{roleName}' was not found.")
        {
        }

        public RoleNotFoundException(string roleName, Exception innerException)
            : base($"The role '{roleName}' was not found.", innerException)
        {
        }
    }
}
