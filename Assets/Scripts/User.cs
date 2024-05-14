using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UnityEngine;

public class User
{
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
}

public class UserLoginDto
{
        [Required]
        public string Username { get; set;}
        [Required]
        public string Password { get; set;}


        public UserLoginDto(string username, string password){
                Username = username;
                Password = password;
        }
        
        public override string ToString()
        {
                return $"{Username} {Password}";
        }
}
