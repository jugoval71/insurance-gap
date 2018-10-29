using Microsoft.EntityFrameworkCore;
using System;

namespace GapInsurance.Entities
{
    public partial class Insurance
    {
        partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        partial void OnModelCreatingImpl(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>().HasData(
                new { Id = Guid.Parse("caa9ffe2-05a6-480f-94c2-fb684db53971"), Name = "Earthquake", Code = "EQK" },
                new { Id = Guid.Parse("d7e6f156-c094-4d0f-858d-344790acb60b"), Name = "Fire", Code = "FR" },
                new { Id = Guid.Parse("ff777418-6610-40c2-a6fa-df7bae60f2e2"), Name = "Loss", Code = "LOS" },
                new { Id = Guid.Parse("558f771b-5f46-4914-891b-aa4ed67fd1c9"), Name = "Theft", Code = "STL" }
                );
            modelBuilder.Entity<Policy>().HasData(
                new { Id = Guid.Parse("f3b81d4a-435b-419b-aff8-4b14070a7e04"), Name = "Test 1", Description = "Test Policy for GAP", StartDate = DateTime.UtcNow, DurationMonths = 12, Price = 200000M, Risk = RiskType.Low, User = "TestUser1" },
                new { Id = Guid.Parse("48cfbd55-3803-480e-8f01-99e4c6520b0a"), Name = "Test 2", Description = "Test Policy for GAP", StartDate = DateTime.UtcNow, DurationMonths = 24, Price = 450000M, Risk = RiskType.Mid, User = "TestUser1" },
                new { Id = Guid.Parse("317d7d79-ea4f-460b-9edc-cd451e47474f"), Name = "Test 3", Description = "Test Policy for GAP", StartDate = DateTime.UtcNow, DurationMonths = 24, Price = 500000M, Risk = RiskType.MidHigh, User = "TestUser1" },
                new { Id = Guid.Parse("59a190d6-0676-4edf-9b92-d3ea7c8e92f6"), Name = "Test 4", Description = "Test Policy for GAP", StartDate = DateTime.UtcNow, DurationMonths = 36, Price = 800000M, Risk = RiskType.High, User = "TestUser1" }
                );
            modelBuilder.Entity<PolicyType>().HasData(
                new { Id = Guid.Parse("c30c6a0f-0606-4b41-a552-4e8403e223fc"), PolicyId = Guid.Parse("f3b81d4a-435b-419b-aff8-4b14070a7e04"), TypeId = Guid.Parse("caa9ffe2-05a6-480f-94c2-fb684db53971"), Coverage = 0.9M, Comment = "Coverage assigned based on risk" },
                new { Id = Guid.Parse("96394668-b824-49e1-8bed-3944c9afe758"), PolicyId = Guid.Parse("59a190d6-0676-4edf-9b92-d3ea7c8e92f6"), TypeId = Guid.Parse("d7e6f156-c094-4d0f-858d-344790acb60b"), Coverage = 0.45M, Comment = "Coverage assigned based on risk" },
                new { Id = Guid.Parse("4f9d9fb5-8320-482b-9326-57ab884d4671"), PolicyId = Guid.Parse("317d7d79-ea4f-460b-9edc-cd451e47474f"), TypeId = Guid.Parse("ff777418-6610-40c2-a6fa-df7bae60f2e2"), Coverage = 0.6M, Comment = "Coverage assigned based on risk" },
                new { Id = Guid.Parse("7b58863a-360b-47ba-a08c-e43137b9a007"), PolicyId = Guid.Parse("48cfbd55-3803-480e-8f01-99e4c6520b0a"), TypeId = Guid.Parse("558f771b-5f46-4914-891b-aa4ed67fd1c9"), Coverage = 0.55M, Comment = "Coverage assigned based on risk" }
                );
        }

    }
}
