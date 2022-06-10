﻿using Microsoft.AspNetCore.Authorization;

namespace FORUM_CZAT.Pages
{
    [Authorize(Roles = "Admins")]
    public class AdminPageModel : PageModel
    {
    }
}
