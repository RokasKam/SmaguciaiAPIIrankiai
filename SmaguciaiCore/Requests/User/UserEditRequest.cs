﻿using System.ComponentModel.DataAnnotations;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Requests.User;

public class UserEditRequest
{
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public string Nickname { get; set; }
    [Required(ErrorMessage = "The Name field cannot be empty")]
    public String Name { get; set; }
    [Required(ErrorMessage = "The Surname field cannot be empty")]
    public String Surname { get; set; }
    [Required(ErrorMessage = "The email field cannot be empty")]
    [EmailAddress(ErrorMessage = "The email must be valid (example: user@example.com)")]
    public string Email { get; set; }
    [Required(ErrorMessage = "The Phone Number field cannot be empty")]
    public String PhoneNumber { get; set; }
    [Required(ErrorMessage = "The Birth date field cannot be empty")]
    public DateTime BirthDate { get; set; }
    [Required(ErrorMessage = "The Gender field cannot be empty")]
    public Gender Gender { get; set; }
    [Required(ErrorMessage = "The Country field cannot be empty")]
    public String Country { get; set; }
    [Required(ErrorMessage = "The District field cannot be empty")]
    public String District { get; set; }
    [Required(ErrorMessage = "The City field cannot be empty")]
    public String City { get; set; }
    [Required(ErrorMessage = "The Street field cannot be empty")]
    public String Street { get; set; }
    [Required(ErrorMessage = "The ZipCode field cannot be empty")]
    public String ZipCode { get; set; }
    [Required(ErrorMessage = "The HouseNumber field cannot be empty")]
    public int HouseNumber { get; set; }
    public int? FlatNumber { get; set; }
}