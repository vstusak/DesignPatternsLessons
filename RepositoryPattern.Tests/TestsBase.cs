﻿using Moq;
using NUnit.Framework;

namespace RepositoryPattern.Tests
{
    public class TestsBase
    {
        public MockRepository MockRepo { get; set; }

        [SetUp]
        public void Setup()
        {
            MockRepo = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public void Teardown()
        {
            MockRepo.VerifyAll();
        }
    }
}