using System;
using System.Collections.Generic;

namespace Common.EntityClass;

public partial class UserDetails
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
