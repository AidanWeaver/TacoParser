using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void LocationNotNull()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("42.784, 64.78, Name", 64.78)]
        [InlineData("62.784, -20.78, Name", -20.78)]
        [InlineData("24.673, -53.76384, Name", -53.76384)]
        [InlineData("-42.746, 78.523, Name", 78.523)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var taco = new TacoParser();

            //Act

            var actual = taco.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("42.784, 64.78, Name", 42.784)]
        [InlineData("62.784, -20.78, Name", 62.784)]
        [InlineData("24.673, -53.76384, Name", 24.673)]
        [InlineData("-42.746, 78.523, Name", -42.746)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var taco = new TacoParser();

            //Act

            var actual = taco.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Latitude);

        }
    }
}
