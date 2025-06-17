using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class RoleDto
    {

    }

    public class CreateRoleDto
    {
        public string RoleName { get; set; }
    }

    public class UpdateRoleDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
