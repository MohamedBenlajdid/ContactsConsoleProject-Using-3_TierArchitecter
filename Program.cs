using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ContactBusinessLayer;

namespace ContactsConsoleApp
{
    internal class Program
    {
        static void testFindContactByID(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if(Contact1 != null )
            {
                Console.WriteLine($"FullName = {Contact1.FirstName + " " + Contact1.LastName}");
                Console.WriteLine($"Phone = {Contact1.Phone}");
                Console.WriteLine($"Email = {Contact1.Email}");
                Console.WriteLine($"Address = {Contact1.Address}");
                Console.WriteLine($"DateOfBirth = {Contact1.DateOfBirth}");
                Console.WriteLine($"CountryID = {Contact1.CountryID}");
                Console.WriteLine($"ImagePath = {Contact1.ImagePath}");

            }
            else
            {
                Console.WriteLine($"Contact With {ID} ContactID Not Found !");
            }
        }
        
        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();
            Contact1.FirstName = "Mohamed";
            Contact1.LastName = "AboLhadi";
            Contact1.Phone = "0632235295";
            Contact1.Email = "benmewdsa158@gmail.com";
            Contact1.Address = "Adile 323 B:32 ";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {

                Console.WriteLine($"Contact With ID = {Contact1.ID} Inserted Successfuly :) ");
            }
        }

        static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            Contact1.FirstName = "Fadi2";
            Contact1.LastName = "Maher2";
            Contact1.Email = "A2@a.com";
            Contact1.Phone = "2222";
            Contact1.Address = "222";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";
            
            if(Contact1.Save())
            {
                Console.WriteLine($"Contact With ID = {Contact1.ID} Updated Successfuly");
            }

        }

        static void testDeleteContact(int ID)
        {
            if(clsContact.isContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine($"Contact With ID = {ID} Deleted Successfuly");
                }
                else
                {
                    Console.WriteLine($"Contact With ID = {ID} NOT Deleted Successfuly");
                }
            }
            else
            {
                Console.WriteLine("We Cannot Delete Not Exist Contact");
            }
            
        }
        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();
            Console.WriteLine("Contacts Info : ");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]} {row["LastName"]}");
            } 
                
        }
        static void testIsContactExist(int ID)
        {
            if(clsContact.isContactExist(ID))
            {
                Console.WriteLine($"Contact With ID = {ID} Exist ");
            }
            else
            {
                Console.WriteLine($"Contact With ID = {ID} Not Exist ");
            }
        }

        static void testFindCountryByID(int ID)
        {
            clsCountry Country1 = clsCountry.Find(ID);
            if (Country1 != null)
            {
                Console.WriteLine($"Country ID = {Country1.ID}");
                Console.WriteLine($"Country Name = {Country1.CountryName}");
                Console.WriteLine($"Country Code = {Country1.Code}");
                Console.WriteLine($"Country PhoneCode = {Country1.PhoneCode}");
            }
            else
            {
                Console.WriteLine($"Country With ID = {ID} Not Found");
            }
        }
        static void testFindCountryByName(string CountryName)
        {
            clsCountry Country1 = clsCountry.Find(CountryName);
            if (Country1 != null)
            {
                Console.WriteLine($"Country ID = {Country1.ID}");
                Console.WriteLine($"Country Name = {Country1.CountryName}");
                Console.WriteLine($"Country Code = {Country1.Code}");
                Console.WriteLine($"Country PhoneCode = {Country1.PhoneCode}");
            }
            else
            {
                Console.WriteLine($"Country With Name = {CountryName} Not Found");
            }
        }
        static void testAddNewCountry()
        {
            clsCountry Country1 = new clsCountry();
            Country1.CountryName = "Morocco";
            if(Country1.Save())
            {
                Console.WriteLine($"Country Added Successfuly With ID = {Country1.ID}");
            }
            else
            {
                Console.WriteLine("Country Not Added Successfuly.Something Wrong");
            }
        }
        static void testUpdateCountry(int ID)
        {
            clsCountry Country1 = clsCountry.Find(ID);
            Country1.CountryName = "Spain";
            if(Country1.Save())
            {
                Console.WriteLine("Contact Updated Successfuly , ID = " + Country1.ID);
            }
            else
            {
                Console.WriteLine("Contact Not Updated Successfuly, Something Wrong");
            }
        }
        static void testDeleteCountry(int ID)
        {
            if(clsCountry.isCountryExist(ID))
            {
                if (clsCountry.DeleteCountry(ID))
                {
                    Console.WriteLine($"Country with ID = {ID} Deleted Successfuly");
                }
                else
                {
                    Console.WriteLine($"Country Not Deleted Successfuly .Something Wrong");
                }
            }
            else
            {
                Console.WriteLine($"Country with ID = {ID} Not Exist !");
            }
        }
        static void testIsCountryExist(int ID)
        {
            if(clsCountry.isCountryExist(ID))
            {
                Console.WriteLine($"Country with ID = {ID} Exist");
            }
            else
            {
                Console.WriteLine($"Country with ID = {ID} Not Exist");
            }
        }
        static void testIsCountryExistByName(string CountryName)
        {
            if (clsCountry.isCountryExist(CountryName))
            {
                Console.WriteLine($"Country with Name = {CountryName} Exist");
            }
            else
            {
                Console.WriteLine($"Country with Name = {CountryName} Not Exist");
            }
        }
        static void ListCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();
            Console.WriteLine("Showing All Countries");
            foreach(DataRow Row in dataTable.Rows)
            {
                Console.WriteLine($"{Row["CountryID"]} , {Row["CountryName"]} ," +
                    $"{Row["Code"]} , {Row["PhoneCode"]}");
            }
        }

        static void Main(string[] args)
        {
            //testAddNewCountry();
            //testDeleteCountry(7);
            //testUpdateCountry(8);
            testIsCountryExist(8);
            testIsCountryExistByName("Morocco");
            ListCountries();
            testFindCountryByID(5);
        }
    }
}
