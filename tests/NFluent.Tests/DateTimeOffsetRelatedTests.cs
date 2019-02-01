namespace NFluent.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DateTimeOffsetRelatedTests
    {
        [Test]
        public void IsEqualToWorks()
        {
            var newYears = new DateTimeOffset(new DateTime(2013, 1, 1), new TimeSpan(0, 1, 0, 0));

            Check.That(newYears).IsEqualTo(new DateTimeOffset(new DateTime(2013, 1, 1), new TimeSpan(0, 1, 0, 0)));
            Check.That(newYears).IsEqualToIgnoringHours(new DateTimeOffset(new DateTime(2013, 1, 1, 12, 0, 0), new TimeSpan(0,1,0,0)));
            Check.That(newYears).IsEqualToIgnoringMinutes(new DateTimeOffset(new DateTime(2013, 1, 1, 0, 1, 0), new TimeSpan(0,1,0,0)));
            Check.That(newYears).IsEqualToIgnoringSeconds(new DateTimeOffset(new DateTime(2013, 1, 1, 0, 0, 1), new TimeSpan(0,1,0,0)));
            Check.That(newYears).IsEqualToIgnoringMillis(new DateTimeOffset(new DateTime(2013, 1, 1, 0, 0, 0), new TimeSpan(0,1,0,0)));
        }

        [Test]
        public void IsNotEqualToWorksWhenOffSetIsDifferent()
        {
            var localTime = new DateTime(2013, 1, 1, 10, 2, 0);
            var oneHourOffSet = new DateTimeOffset(localTime, new TimeSpan(7, 0, 0));

            Check.That(oneHourOffSet).IsNotEqualTo(new DateTimeOffset(localTime, new TimeSpan(6, 0, 0)));
            
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringHours(new DateTimeOffset(localTime, new TimeSpan(0,13,0,0)));
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringMinutes(new DateTimeOffset(localTime, new TimeSpan(0,1,0,0)));
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringSeconds(new DateTimeOffset(localTime, new TimeSpan(0,1,0,0)));
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringMillis(new DateTimeOffset(localTime, new TimeSpan(0,1,0,0)));
        }

        [Test]
        public void IsNotEqualToWorksWhenTimeIsDifferent()
        {
            var localTime = new DateTime(2013, 1, 1, 10, 2, 0);
            var oneHourOffSet = new DateTimeOffset(localTime, new TimeSpan(7, 0, 0));

            Check.That(oneHourOffSet).IsNotEqualTo(new DateTimeOffset(localTime, new TimeSpan(6, 0, 0)));
            
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringHours(new DateTimeOffset(new DateTime(2013, 1, 2, 12, 0, 0), new TimeSpan(0,13,0,0)));
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringMinutes(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 1, 0), new TimeSpan(0,13,0,0)));
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringSeconds(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 0, 1), new TimeSpan(0,13,0,0)));
            Check.That(oneHourOffSet).Not.IsEqualToIgnoringMillis(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 0, 0), new TimeSpan(0,13,0,0)));
        }

        [Test]
        public void MatchTheSameUTCInstantWorks()
        {
            var newYears = new DateTimeOffset(new DateTime(2013, 1, 1), TimeSpan.Zero);

            Check.That(newYears).MatchTheSameUTCInstant(new DateTimeOffset(new DateTime(2013, 1, 1), TimeSpan.Zero));
            Check.That(newYears).MatchTheSameUTCInstantIgnoringHours(new DateTimeOffset(new DateTime(2013, 1, 2, 12, 0, 0), new TimeSpan(0,13,0,0)));
            Check.That(newYears).MatchTheSameUTCInstantIgnoringMinutes(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 1, 0), new TimeSpan(0,1,0,0)));
            Check.That(newYears).MatchTheSameUTCInstantIgnoringSeconds(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 0, 1), new TimeSpan(0,1,0,0)));
            Check.That(newYears).MatchTheSameUTCInstantIgnoringMillis(new DateTimeOffset(new DateTime(2013, 1, 1, 1, 0, 0), new TimeSpan(0,1,0,0)));
        }

        [Test]
        public void NotMatchTheSameUTCInstantWorks()
        {
            var localTime = new DateTime(2013, 1, 1, 10, 2, 0);
            var oneHourOffSet = new DateTimeOffset(localTime, new TimeSpan(7, 0, 0));
            Check.That(oneHourOffSet).IsNotEqualTo(new DateTimeOffset(localTime, new TimeSpan(6, 0, 0)));
            
            Check.That(oneHourOffSet).Not.MatchTheSameUTCInstantIgnoringMillis(new DateTimeOffset(localTime, new TimeSpan(6, 0, 0)));
        }
    }
}
