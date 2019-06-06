using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        
       [Fact]
        public void AddGradeLogic()
        {
            var book = new InMemoryBook("Naj");
            var book2 = new InMemoryBook("Naj2");
            book.AddGrade(104);
            book.AddGrade(-1);
            book2.AddGrade(5);

            Assert.Empty(book.grades);
            Assert.Single(book2.grades);
        }

        [Fact]
        public void StringSpecialCase()
        {
            string x = "Naj";
            string name = CoverttoUpperCase(x);
          
            Assert.Equal("Naj", x);
            Assert.Equal("NAJ", name);
        }

        private string CoverttoUpperCase(string x)
        {
           return x.ToUpper();
        }
        
        [Fact]
        public void CsharpCanPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref object z)
        {
            z = 42;
        }

        private object GetInt()
        {
           return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = new InMemoryBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        
       
       [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = new InMemoryBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = new InMemoryBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 =  GetBook("Book 1");
            var book2 =  GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TwoVariablesCanReferenceSameObjects()
        {
            var book1 =  GetBook("Book 1");
            var book2 =  book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
