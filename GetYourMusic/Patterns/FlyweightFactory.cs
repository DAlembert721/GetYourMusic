using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.ContractSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Patterns
{
    public class Datos
    {
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }
        public int ContractStateId { get; set; }
        public ContractState ContractState { get; set; }
    }

    public class FlyweightFactory
    {

        private List<Tuple<Flyweight,Datos>> flyweights= new List<Tuple<Flyweight,Datos>>();

        public FlyweightFactory(IEnumerable<Contract> args)
        {
           
            foreach( var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight,Datos>(new Flyweight(elem), this.getKey(elem)));
            }         

        }
        public Datos getKey(Contract key)
        {
            Datos elements = new Datos();
            elements.ContractState = key.ContractState;
            elements.ContractStateId = key.ContractStateId;
            elements.Organizer = key.Organizer;
            elements.OrganizerId = key.OrganizerId;

            return elements;
        }

        public Flyweight GetFlyweight(Contract contract)
        {
            Datos key = this.getKey(contract);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                this.flyweights.Add(new Tuple<Flyweight, Datos>(new Flyweight(contract), key));
            }
            else
            {
                return null;
            }
            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }
    }


}
