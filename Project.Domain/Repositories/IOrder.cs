using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.Domain.Repositories
{
    public interface IOrder
    {
        int Id { get; set; }

        int CustomerId { get; set; }

        int ProductId { get; set; }

        string Name { get; set; }
        
        int Quantity { get; set; }


        string Email { get; set; }

        string Code { get; set; }

        float Value { get; set; }

        float Total { get; set; }

        IEnumerable<SelectListItem> Customers { get; set; }

        IEnumerable<SelectListItem> Products { get; set; }
    }
}
