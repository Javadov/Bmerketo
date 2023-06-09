﻿using Amazon.IdentityManagement.Model;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class UserRegisterViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "You must enter a first name.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "You must enter a last name.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Street Name")]
    [Required(ErrorMessage = "You must enter a street name.")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "Postal Code")]
    [Required(ErrorMessage = "You must enter a postal code.")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City")]
    [Required(ErrorMessage = "You must enter a city.")]
    public string City { get; set; } = null!;

    [Display(Name = "Mobile")]
    public string? Mobile { get; set; }

    [Display(Name = "Company")]
    public string? CompanyName { get; set; }

    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "You must enter an e-mail address.")]
    [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your must enter a valid e-mail address.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "You must enter a password.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Your must enter a valid password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "You must confirm your password.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "Upload Profile Image")]
    [DataType(DataType.Upload)]
    public IFormFile? ProfilePicture { get; set; }

    [Display(Name = "I have read and accepts the user terms and agreements")]
    public bool TermsAndAgreements { get; set; } = false;

    public static implicit operator AppUser(UserRegisterViewModel model)
    {
        var appUser = new AppUser
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.Mobile,
            CompanyName = model.CompanyName,
        };

        if (model.ProfilePicture != null)
            appUser.ImageUrl = $"{appUser.Id}_{Path.GetFileName(model.ProfilePicture.FileName).Replace(" ", "_")}";

        else
            appUser.ImageUrl = $"no-thumb.jpg";

        return appUser;
    }

    public static implicit operator AddressEntity(UserRegisterViewModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City
        };
    }
}
