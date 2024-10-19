using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CMCSPOE.Models;

namespace CMCSPOE.Tests
{
    public class ClaimTests
    {
        [Fact]  
        public void CalculateTotalClaim_ValidInputs_ReturnsExpectedValue()
        {
            // Arrange
            var claim = new Models.Claim
            {
                HoursWorked = 10,
                HourlyRate = 50
            };
            var expectedTotal = 500;

            // Act
            var actualTotal = claim.HoursWorked * claim.HourlyRate;

            // Assert
            Assert.Equal(expectedTotal, actualTotal);  
        }
    }
}
