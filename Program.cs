using System;
using System.Linq;

namespace select_many
{
    class Author
    {
        public string Name { get; set; }
        public Book[] Books { get; set; }
    }

    class Book
    {
        public string Name { get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var authors = CreateAuthors();

            var bookNames = authors.SelectMany(
                (author, i) => author.Books.Select((book, j) => $"{i}-{j}:{book.Name}"),
                (author, bookName) => $"{bookName}/{author.Name}"
            );

            Console.WriteLine(string.Join(", ", bookNames));
        }

        static Author[] CreateAuthors()
        {
            return new[] {
                new Author()
                {
                    Name = "芥川龍之介",
                    Books = new[] {
                        new Book()
                        {
                            Name = "羅生門",
                        },
                        new Book()
                        {
                            Name = "蜘蛛の糸",
                        },
                        new Book()
                        {
                            Name = "河童",
                        },
                    },
                },

                new Author()
                {
                    Name = "江戸川乱歩",
                    Books = new[] {
                        new Book()
                        {
                            Name = "人間椅子",
                        },
                        new Book()
                        {
                            Name = "怪人二十面相",
                        },
                    },
                },

                new Author()
                {
                    Name = "川端康成",
                    Books = new[] {
                        new Book()
                        {
                            Name = "雪国",
                        },
                        new Book()
                        {
                            Name = "伊豆の踊り子",
                        },
                    },
                },
            };
        }
    }
}
