using System;

namespace MPP_Problema1.Model
{
    internal class FlightClient
    {
        public Guid Id { get; }
        private string Name { get; }
        private string Address { get; }
        private string Email { get; }

        public FlightClient(string name, string address, string email)
        {
            this.Id =  Guid.NewGuid();
            this.Name = name;
            this.Address = address;
            this.Email = email;
        }
    }
}
