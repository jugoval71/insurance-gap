﻿// <auto-generated />
using System;
using GapInsurance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GapInsurance.Entities.Migrations
{
    [DbContext(typeof(Insurance))]
    partial class InsuranceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GapInsurance.Entities.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("DurationMonths");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<int>("Risk");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Policies");

                    b.HasData(
                        new { Id = new Guid("f3b81d4a-435b-419b-aff8-4b14070a7e04"), Description = "Test Policy for GAP", DurationMonths = 12, Name = "Test 1", Price = 200000m, Risk = 1, StartDate = new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), User = "TestUser1" },
                        new { Id = new Guid("48cfbd55-3803-480e-8f01-99e4c6520b0a"), Description = "Test Policy for GAP", DurationMonths = 24, Name = "Test 2", Price = 450000m, Risk = 2, StartDate = new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), User = "TestUser1" },
                        new { Id = new Guid("317d7d79-ea4f-460b-9edc-cd451e47474f"), Description = "Test Policy for GAP", DurationMonths = 24, Name = "Test 3", Price = 500000m, Risk = 3, StartDate = new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), User = "TestUser1" },
                        new { Id = new Guid("59a190d6-0676-4edf-9b92-d3ea7c8e92f6"), Description = "Test Policy for GAP", DurationMonths = 36, Name = "Test 4", Price = 800000m, Risk = 4, StartDate = new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), User = "TestUser1" }
                    );
                });

            modelBuilder.Entity("GapInsurance.Entities.PolicyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Coverage")
                        .HasColumnType("Decimal(5,2)");

                    b.Property<Guid?>("PolicyId")
                        .IsRequired();

                    b.Property<Guid?>("TypeId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.HasIndex("TypeId");

                    b.ToTable("PolicyTypes");

                    b.HasData(
                        new { Id = new Guid("c30c6a0f-0606-4b41-a552-4e8403e223fc"), Comment = "Coverage assigned based on risk", Coverage = 0.9m, PolicyId = new Guid("f3b81d4a-435b-419b-aff8-4b14070a7e04"), TypeId = new Guid("caa9ffe2-05a6-480f-94c2-fb684db53971") },
                        new { Id = new Guid("96394668-b824-49e1-8bed-3944c9afe758"), Comment = "Coverage assigned based on risk", Coverage = 0.45m, PolicyId = new Guid("59a190d6-0676-4edf-9b92-d3ea7c8e92f6"), TypeId = new Guid("d7e6f156-c094-4d0f-858d-344790acb60b") },
                        new { Id = new Guid("4f9d9fb5-8320-482b-9326-57ab884d4671"), Comment = "Coverage assigned based on risk", Coverage = 0.6m, PolicyId = new Guid("317d7d79-ea4f-460b-9edc-cd451e47474f"), TypeId = new Guid("ff777418-6610-40c2-a6fa-df7bae60f2e2") },
                        new { Id = new Guid("7b58863a-360b-47ba-a08c-e43137b9a007"), Comment = "Coverage assigned based on risk", Coverage = 0.55m, PolicyId = new Guid("48cfbd55-3803-480e-8f01-99e4c6520b0a"), TypeId = new Guid("558f771b-5f46-4914-891b-aa4ed67fd1c9") }
                    );
                });

            modelBuilder.Entity("GapInsurance.Entities.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new { Id = new Guid("caa9ffe2-05a6-480f-94c2-fb684db53971"), Code = "EQK", Name = "Earthquake" },
                        new { Id = new Guid("d7e6f156-c094-4d0f-858d-344790acb60b"), Code = "FR", Name = "Fire" },
                        new { Id = new Guid("ff777418-6610-40c2-a6fa-df7bae60f2e2"), Code = "LOS", Name = "Loss" },
                        new { Id = new Guid("558f771b-5f46-4914-891b-aa4ed67fd1c9"), Code = "STL", Name = "Theft" }
                    );
                });

            modelBuilder.Entity("GapInsurance.Entities.PolicyType", b =>
                {
                    b.HasOne("GapInsurance.Entities.Policy")
                        .WithMany("PolicyTypes")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GapInsurance.Entities.Type")
                        .WithMany("PolicyTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}