using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.Common
{
    public abstract class BaseModelDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public int RowStatus { get; set; }
    }
}
