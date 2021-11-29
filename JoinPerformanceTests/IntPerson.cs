using System;
using System.Collections.Generic;

namespace JoinPerformanceTests
{
    public class IntPerson
    {
        public int Id { get; set; }

        public List<IntEmail> Emails = new ();
    }

    public class IntEmail
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
    }
}