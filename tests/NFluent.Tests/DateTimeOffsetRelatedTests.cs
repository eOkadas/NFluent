namespace NFluent.Tests
{
    using System;
    using NFluent.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class DateTimeOffsetRelatedTests
    {
        [Test]
        public void IsEqualToWorks()
        {
            var newYears = new DateTimeOffset(new DateTime(2013, 1, 1), TimeSpan.Zero);

            Check.That(newYears).IsEqualTo(new DateTimeOffset(new DateTime(2013, 1, 1), TimeSpan.Zero));
            Check.That(newYears).IsEqualToIgnoringHours(new DateTimeOffset(new DateTime(2013, 1, 2, 12, 0, 0), new TimeSpan(0,13,0,0)));
            Check.That(newYears).IsEqualToIgnoringMinutes(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 1, 0), new TimeSpan(0,1,0,0)));
            Check.That(newYears).IsEqualToIgnoringSeconds(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 0, 1), new TimeSpan(0,1,0,0)));
            Check.That(newYears).IsEqualToIgnoringMillis(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 0, 0), new TimeSpan(0,1,0,0)));
        }

        [Test]
        public void IsNotEqualToWorks()
        {
            var newYears = new DateTimeOffset(new DateTime(2013, 1, 1), TimeSpan.Zero);
            Check.That(newYears).IsNotEqualTo(new DateTimeOffset(new DateTime(1905, 1, 1), TimeSpan.Zero));
        }
    }
}
