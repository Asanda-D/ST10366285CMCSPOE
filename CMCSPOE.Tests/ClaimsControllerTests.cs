using CMCSPOE.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CMCSPOE.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCSPOE.Data.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CMCSPOE.Tests
{
    public class ClaimsControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ClaimsController _controller;

        public ClaimsControllerTests()
        {
            // Use in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "TestDatabase")
                          .Options;
            _context = new ApplicationDbContext(options);

            _controller = new ClaimsController(_context);

            // fill database with some test data
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var claims = new List<Claim>
        {
            new Claim
            {
                ClaimId = 1,
                LecturerName = "Thando Gumede",
                HoursWorked = 10,
                HourlyRate = 50,
                Status = "Pending",
                AdditionalNotes = "Some test notes for claimID 1",
                SupportingDocumentPath = "testdoc1.pdf"
            },
            new Claim
            {
                ClaimId = 2,
                LecturerName = "Luyanda Mbala",
                HoursWorked = 8,
                HourlyRate = 60,
                Status = "Approved",
                AdditionalNotes = "Some test notes for claimID 2", 
                SupportingDocumentPath = "testdoc2.pdf"
            }
        };

            _context.Claim.AddRange(claims);
            _context.SaveChanges();
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfClaims()
        {
            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Claim>>(viewResult.ViewData.Model);

            // Check if model contains the expected number of claims
            Assert.Equal(2, model.Count);
        }
    }
}