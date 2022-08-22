using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeContracts.UnitTests
{
    public class ContractTests
    {
        private const string ExpectedAssertException = "Microsoft.VisualStudio.TestPlatform.TestHost.DebugAssertException";

        [Fact]
        public void Requires_Successful_Validates_Valid_Requirements()
        {
            var (target, requirements) = CreateValidRequirements();
            
            var exception = Record.Exception(() => Contract.Requires(target, requirements));

            exception.Should().BeNull();
        }

        [Fact]
        public void Requires_Successful_Validates_Invalid_Requirements()
        {
            var (target, requirements) = CreateInvalidRequirements();
    
            var exception = Record.Exception(() => Contract.Requires(target, requirements));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }

        [Fact]
        public void Requires_Lambda_Successful_Validates_Valid_Requirements()
        {
            bool Predicate() => true;

            var exception = Record.Exception(() => Contract.Requires(Predicate));

            exception.Should().BeNull();
        }

        [Fact]
        public void Requires_Lambda_Successful_Validates_Invalid_Requirements()
        {
            bool Predicate() => false;

            var exception = Record.Exception(() => Contract.Requires(Predicate));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }

        [Fact]
        public void RequiresAll_Lambda_Successful_Validates_Valid_Requirements_For_Each_Element()
        {
            var collection = CreateValidBoolCollection();
            bool Predicate(bool d) => d;

            var exception = Record.Exception(() => Contract.RequiresAll(collection, Predicate));

            exception.Should().BeNull();
        }

        [Fact]
        public void RequiresAll_Lambda_Successful_Validates_Invalid_Requirements_For_Each_Element()
        {
            var collection = CreateInvalidBoolCollection();
            bool Predicate(bool d) => d;

            var exception = Record.Exception(() => Contract.RequiresAll(collection, Predicate));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }

        [Fact]
        public void RequiresAll_Successful_Validates_Valid_Requirements_For_Each_Element()
        {
            var collection = Enumerable.Range(1, 20).Select(i => (double)i).ToList();

            var exception = Record.Exception(() => Contract.RequiresAll(collection, Requirements
                .For(collection.First())
                .Greater(0)
                .Lesser(21)));

            exception.Should().BeNull();
        }

        [Fact]
        public void RequiresAll_Successful_Validates_Invalid_Requirements_For_Each_Element()
        {
            var collection = Enumerable.Range(1, 20).Select(i => (double)i).ToList();

            var exception = Record.Exception(() => Contract.RequiresAll(collection, Requirements
                .For(collection.First())
                .Greater(0)
                .Lesser(21)
                .Negative()));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }
        
        [Fact]
        public void Ensures_Successful_Validates_Valid_Requirements()
        {
            var (target, requirements) = CreateValidRequirements();
    
            var exception = Record.Exception(() => Contract.Ensures(target, requirements));

            exception.Should().BeNull();
        }

        [Fact]
        public void Ensures_Lambda_Successful_Validates_Valid_Requirements()
        {
            bool Predicate() => true;

            var exception = Record.Exception(() => Contract.Requires(Predicate));

            exception.Should().BeNull();
        }

        [Fact]
        public void Ensures_Lambda_Successful_Validates_Invalid_Requirements()
        {
            bool Predicate() => false;

            var exception = Record.Exception(() => Contract.Requires(Predicate));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }

        [Fact]
        public void EnsuresAll_Lambda_Successful_Validates_Valid_Requirements_For_Each_Element()
        {
            var collection = CreateValidBoolCollection();
            bool Predicate(bool d) => d;

            var exception = Record.Exception(() => Contract.EnsuresAll(collection, Predicate));

            exception.Should().BeNull();
        }

        [Fact]
        public void EnsuresAll_Lambda_Successful_Validates_Invalid_Requirements_For_Each_Element()
        {
            var collection = CreateInvalidBoolCollection();
            bool Predicate(bool d) => d;

            var exception = Record.Exception(() => Contract.EnsuresAll(collection, Predicate));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }

        [Fact]
        public void EnsuresAll_Successful_Validates_Valid_Requirements_For_Each_Element()
        {
            var collection = Enumerable.Range(1, 20).Select(i => (double)i).ToList();

            var exception = Record.Exception(() => Contract.EnsuresAll(collection, Requirements
                .For(collection.First())
                .Greater(0)
                .Lesser(21)));

            exception.Should().BeNull();
        }

        [Fact]
        public void EnsuresAll_Successful_Validates_Invalid_Requirements_For_Each_Element()
        {
            var collection = Enumerable.Range(1, 20).Select(i => (double)i).ToList();

            var exception = Record.Exception(() => Contract.EnsuresAll(collection, Requirements
                .For(collection.First())
                .Greater(0)
                .Lesser(21)
                .Negative()));

            exception.Should().NotBeNull();
            exception?.GetType().ToString().Should()
                .Be(ExpectedAssertException);
        }
        
        private List<bool> CreateInvalidBoolCollection()
        {
            var collection = CreateValidBoolCollection();
            collection.Add(false);
            return collection;
        }

        private static List<bool> CreateValidBoolCollection()
        {
            return Enumerable.Range(1, 20).Select(i => true).ToList();
        }

        private (double, ComparableRequirements<double>) CreateInvalidRequirements()
        {
            var (target, requirements) = CreateValidRequirements();
            requirements.Negative();

            return (target, requirements);
        }

        private (double, ComparableRequirements<double>) CreateValidRequirements()
        {
            var target = 50.0d;

            return (target, Requirements
                .For(target)
                .Lesser(100.0d)
                .Greater(25.0d)
                .InRange(45.0d, 55.0d)
                .GreaterEquals(target)
                .LesserEquals(target)
                .Positive());
        }
    }
}
