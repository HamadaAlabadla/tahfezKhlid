// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using tahfez.Models;
using tahfezKhalid.Services;

namespace tahfezKhalid.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        readonly SignInManager<User> signInManager;
        readonly UserManager<User> userManager;
        readonly RoleManager<IdentityRole> roleManager;
        readonly IUserStore<User> userStore;
        readonly IUserEmailStore<User> emailStore;
        readonly ILogger<RegisterModel> logger;
        readonly IEmailSender emailSender;
        readonly IManageUserSessionService _contextUserSession;

        public RegisterModel(
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IManageUserSessionService contextUserSession)
        {
            this.userManager = userManager;
            this.userStore = userStore;
            emailStore = GetEmailStore();
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            this.roleManager = roleManager;
            _contextUserSession = contextUserSession;
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
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

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
            [Required(ErrorMessage = "الاسم بالكامل مطلوب")]
            [Display(Name = "الإسم بالكامل")]
            [MinLength(10)]
            [MaxLength(35)]
            [DataType(DataType.Text)]
            public string Name { get; set; }

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

            [RegularExpression("^[0-9]+$")]
            [Required(ErrorMessage = "رقم الهاتف مطلوب")]
            [Display(Name = "رقم الهاتف")]
            [StringLength(10)]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(int id, int sessionId = -1, string returnUrl = null)
        {
            ViewData["Id"] = id;
            ViewData["sessionId"] = sessionId;
            ViewData["Type"] = (TypeUser)id;
            ReturnUrl = returnUrl;
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(int Id,int sessionId = -1, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.IdentificationNumber = Input.IdentificationNumber;
                user.Name = Input.Name;
                user.TypeUser = (TypeUser)Id;
                user.PhoneNumber = Input.PhoneNumber;
                user.UserName = (Input.IdentificationNumber + Id);
                user.NormalizedUserName = (Input.IdentificationNumber + Id);
                //await userStore.SetUserNameAsync(user, Input.IdentificationNumber, CancellationToken.None);
                var getUser = await userManager.Users.FirstOrDefaultAsync(x => x.IdentificationNumber == user.IdentificationNumber && x.TypeUser == user.TypeUser);

                if (getUser == null)
                {
                    var password = "USER_123_user";
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        logger.LogInformation("User created a new account with password.");
                        var role = new IdentityRole();

                        if (user.TypeUser == TypeUser.آدمن)
                            role = roleManager.FindByNameAsync("admin").Result;
                        else if (user.TypeUser == TypeUser.محفظ)
                            role = roleManager.FindByNameAsync("memorizer").Result;
                        else if (user.TypeUser == TypeUser.ولي_أمر)
                            role = roleManager.FindByNameAsync("parent").Result;
                        else if (user.TypeUser == TypeUser.مشرف)
                            role = roleManager.FindByNameAsync("supervisor").Result;

                        if (role.Name.Length != 0)
                        {
                            var roleResult = await userManager.AddToRoleAsync(user, role.Name);
                        }

                        var userId = await userManager.GetUserIdAsync(user);
                        if(sessionId != -1)
                            return RedirectToAction("Create", "Students", new { Id = sessionId });
                        return RedirectToAction("Index", "Home", new { Id = Id });
                    }

                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    
                }
                else
                {
                    if(getUser.TypeUser == TypeUser.ولي_أمر && sessionId != -1)
                    {
                        await _contextUserSession.CreateUserSession(getUser.Id, sessionId);
                        return RedirectToAction("Create","Students",new { Id = sessionId });
                    }
                    ModelState.AddModelError("", "هذا الحساب موحود مسبقا !!!");
                }
            }

            ViewData["Id"] = Id;
            ViewData["Type"] = (TypeUser)Id;
            // If we got this far, something failed, redisplay form
            return Page();
        }

        User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        IUserEmailStore<User> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }

            return (IUserEmailStore<User>)userStore;
        }
    }
}