using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SofthouseXML
{
    public class InputSerializer
    {
        public People ParseInput(string input)
        {
            string[] splits = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            var people = new People();
            Person personParent = null;
            Family familyParent = null;

            foreach (string row in splits)
            {
                var firstLetter = row.ElementAt(0);

                switch (firstLetter)
                {
                    case 'P':
                        var person = PersonMapper.SerializePerson(row);
                        personParent = person;
                        familyParent = null;
                        people.Person.Add(person);
                        break;

                    case 'T':
                        var phone = PhoneMapper.SerializePhone(row);
                        if (familyParent != null)
                            familyParent.Phone = phone;
                        else if (personParent != null)
                            personParent.Phone = phone;
                        else
                            throw new Exception("Attempted to attach Phone without any parent.");
                        break;

                    case 'A':
                        var address = AddressMapper.SerializeAddress(row);
                        if (familyParent != null)
                            familyParent.Address = address;
                        else if (personParent != null)
                            personParent.Address = address;
                        else
                            throw new Exception("Attempted to attach Address without any parent.");
                        break;

                    case 'F':
                        var family = FamilyMapper.SerializeFamily(row);
                        if (personParent == null)
                            throw new Exception("Attempted to attach Family without any Person.");

                        personParent.Family.Add(family);
                        familyParent = family;
                        break;

                    default:
                        Debug.Log($"No operation exists for case: '{firstLetter}'.");
                        break;
                }
            }

            return people;
        }
    }
}