// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using ArtJamWebApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtJamWebApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public bool IsMusician { get; set; }

            public string? Bio { get; set; }

            public string? Instrument { get; set; }

            public IFormFile? ProfilePicture { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Качване на профилната снимка, ако е предоставена
                string profilePicturePath = null;
                if (Input.ProfilePicture != null)
                {
                    profilePicturePath = UploadFile(Input.ProfilePicture);
                }

                var user = new User
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    ProfilePicture = profilePicturePath, // Запазваме пътя към снимката
                    IsMusician = Input.IsMusician
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("~/");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }




        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            // Генерираме уникално име за файла
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            // Определяме директорията, където ще съхраняваме файловете
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            // Създаваме директорията, ако не съществува
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Пълния път на файла
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Качваме файла в директорията
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            // Връщаме относителния път, за да може да бъде използван в HTML
            return "/uploads/" + uniqueFileName;
        }

    }

}
