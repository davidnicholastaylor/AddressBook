﻿using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Contact
    {
        // Create properties of class
        public string FirstName;
        public string LastName;
        public string Email;
        public string Address;

        // Combine first name and last name properties
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    class AddressBook
    {
        // Create dictionary of string keys and Contact values
        Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();

        // Use contact class to add key value pairs of contact emails and contacts into the addressBook dictionary
        // Try to add a contact a second time
        // Catch the contact if there is already a contact with that value and print custom error message
        public void AddContact(Contact contact)
        {
            try 
            {
            addressBook.Add(contact.Email, contact);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"{contact.FullName} already exists in contacts.");
            }
        }

        // Return email from addressBook
        public Contact GetByEmail(string email)
        {
            return addressBook[email];
        }
    }
    class Program
    {
        /*
            1. Add the required classes to make the following code compile.
            HINT: Use a Dictionary in the AddressBook class to store Contacts. They keys should be the contact email.

            2. Run the program and observe the exception.

            3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
                Print meaningful error messages in the catch blocks.
        */

        static void Main(string[] args)
        {
            // Create a few contacts
            Contact bob = new Contact()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@email.com",
                Address = "100 Some Ln, Testville, TN 11111"
            };
            Contact sue = new Contact()
            {
                FirstName = "Sue",
                LastName = "Jones",
                Email = "sue.jones@email.com",
                Address = "322 Hard Way, Testville, TN 11111"
            };
            Contact juan = new Contact()
            {
                FirstName = "Juan",
                LastName = "Lopez",
                Email = "juan.lopez@email.com",
                Address = "888 Easy St, Testville, TN 11111"
            };


            // Create an AddressBook and add some contacts to it
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

            // Try adding a contact a second time
            addressBook.AddContact(sue);
            

            // Create a list of emails that match our Contacts
            List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };

            // Insert an email that does NOT match a Contact
            emails.Insert(1, "not.in.addressbook@email.com");

            //  Search the AddressBook by email and print the information about each Contact
            foreach (string email in emails)
            {
                // Try to print contact list by using GetByEmail method
                // Catch email that does not match contact and print custom error message
                try
                {
                    Contact contact = addressBook.GetByEmail(email);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Name: {contact.FullName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Address: {contact.Address}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Employee with email {email} does not exist.");
                }
            }
        }
    }
}
