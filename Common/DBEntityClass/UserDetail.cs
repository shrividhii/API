using System;
using System.Collections.Generic;

namespace Common.DBEntityClass;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
