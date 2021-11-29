using System;
using System.Collections.Generic;

namespace JoinPerformanceTests
{
    public class GuidPerson
    {
        public Guid Id { get; set; }

        public List<GuidEmail> Emails = new ();
    }

    public class GuidEmail
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
    }
}