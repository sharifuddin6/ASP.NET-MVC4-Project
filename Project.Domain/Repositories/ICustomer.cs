﻿namespace Project.Domain.Repositories
{
    public interface ICustomer
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }
    }
}
