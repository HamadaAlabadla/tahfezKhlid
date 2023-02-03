// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using tahfez.Models;
using tahfezKhalid.Services;

namespace tahfezKhalid.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        readonly SignInManager<User> signInManager;
        readonly UserManager<User> userManager;
        readonly ILogger<LoginModel> logger;
        readonly IManageDeleteUserService contextDelete;

        public LoginModel(SignInManager<User> signInManager,
            ILogger<LoginModel> logger,
            UserManager<User> userManager,
            IManageDeleteUserService contextDelete)
        {
            this.signInManager = signInManager;
            this.logger = logger;
            this.userManager = userManager;
            this.contextDelete = contextDelete;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "رقم الهوية مطلوب")]
            [Display(Name = "رقم الهوية")]
            [StringLength(9)]
            [RegularExpression("^[0-9]+$")]
            [DataType(DataType.PhoneNumber)]
            public string IdentificationNumber { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "كلمة المرور مطلوبة")]
            [Display(Name = "كلمة المرور")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "تذكرني ؟ ")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(TypeUser))
                .Cast<TypeUser>()
                .Select(x => x.ToString())
                .ToList(), "Id");

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string Id, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                if (Id == TypeUser.آدمن.ToString())
                    Id = "0";
                else if (Id == TypeUser.محفظ.ToString())
                    Id = "1";
                else if (Id == TypeUser.ولي_أمر.ToString())
                    Id = "2";
                else if (Id == TypeUser.مشرف.ToString())
                    Id = "3";
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == (Input.IdentificationNumber + Id));

                if (user != null)
                {
                    var delete = await contextDelete.FindUserAsync(user.Id);

                    if (!delete)
                    {
                        var result = await signInManager.PasswordSignInAsync((Input.IdentificationNumber + Id), Input.Password, Input.RememberMe, lockoutOnFailure: false);

                        if (result.Succeeded)
                        {
                            logger.LogInformation("تم تسجيل الدخول بنجاح");
                            return RedirectToAction("Welcome", "Home");
                        }

                        if (result.RequiresTwoFactor)
                        {
                            return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                        }

                        if (result.IsLockedOut)
                        {
                            logger.LogWarning("User account locked out.");
                            return RedirectToPage("./Lockout");
                        }
                        else
                        {
                            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(TypeUser))
                                .Cast<TypeUser>()
                                .Select(x => x.ToString())
                                .ToList(), "Id");

                            ModelState.AddModelError(string.Empty, "فشل عملية تسجيل الدخول");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "تم تعطيل الحساب");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "فشل عملية تسجيل الدخول");
                }
            }

            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(TypeUser))
                .Cast<TypeUser>()
                .Select(x => x.ToString())
                .ToList(), "Id");
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}