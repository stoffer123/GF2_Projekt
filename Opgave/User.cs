﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF2_Projekt.Opgave
{
    public class User
    {
        //get; set; to allow read/write of variables outside of this class.
        string phoneNumber { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string age { get; set; }
        string address { get; set; }
        string zipCode { get; set; }
        string city { get; set; }
        string email { get; set; }
        int newsLetterFrequency { get; set; } //At which frequency is a newsLetter wanted, standard values = 12, 4, 1 times a year

        public User(string phoneNumber, string firstName, string lastName, string age, string address, string zipCode, string city, string email, int newsLetterFrequency)
        {
            //"this" refers to the variable of THIS object and not the argument
            this.phoneNumber = phoneNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.zipCode = zipCode;
            this.city = city;
            this.email = email;
            this.newsLetterFrequency = newsLetterFrequency;
        }
    }
}