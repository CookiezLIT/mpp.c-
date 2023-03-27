using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPP_Problema1.Model
{
    [Table ("flight_client")]
    public class FlightClient
    {
        [Column ("id")]
        public Guid Id { get; }
        [Column ("name")]
        public string Name { get; }
        [Column ("address")]
        public string Address { get; }
        
        [Column ("email")]
        public string Email { get; }

        public FlightClient(string name, string address, string email)
        {
            this.Id =  Guid.NewGuid();
            this.Name = name;
            this.Address = address;
            this.Email = email;
        }

        public FlightClient(object id, object name, object address, object email)
        {
            this.Id = (Guid)id;
            this.Name = (string)name;
            this.Address =(string)address;
            this.Email = (string)email;
        }
    }
}
