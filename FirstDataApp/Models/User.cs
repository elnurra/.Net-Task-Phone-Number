using System;
using System.Collections.Generic;

namespace FirstDataApp;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
