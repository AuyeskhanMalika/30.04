using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperNews
{
    public class Menu
    {
        private readonly string connectionString;
        private List<News> news;
        private List<NewsComments> comments;

        public void Choices()
        {
            Console.WriteLine("Select an action:\n " + "1) View news and comments\n" + "2) Add news");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                PrintNews();
            }
            else
            {
                AddNews();
            }
        }
        
        public void PrintNews()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                news = connection.Query<News>("select * from News").ToList();
                comments = connection.Query<NewsComments>("select * from NewsComments").ToList();
            }
        }

        public void AddNews()
        {
            News newUncos = new News();
            Console.WriteLine("Enter the new");
            newUncos.Uncos = Console.ReadLine();

            Console.WriteLine("Enter the news author");
            newUncos.UncosAuthor = Console.ReadLine();

            Console.WriteLine("Enter the date of this publication");
            newUncos.DateOfPublication = DateTime.Now;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("insert into News values(@Uncos, @UncosAuthor, @DateOfPublication)", newUncos);
            }

            Console.WriteLine("\nSelect an action:\n" + "1) Leave a comment" + "2) Exit\n");
            int secondChoice = int.Parse(Console.ReadLine());

            if (secondChoice == 1)
            {
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    if (index > 0 && index <= news.Count)
                    {
                        string commentAuthor, comment;
                        Guid id = news[index - 1].Id;

                        Console.WriteLine("Enter your name: ");
                        commentAuthor = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(commentAuthor))
                        {
                            Console.WriteLine("Enter your comment: ");
                            comment = Console.ReadLine();

                            using (var connection = new SqlConnection(connectionString))
                            {
                                NewsComments newscomment = new NewsComments();
                                newscomment.NewsId = id;
                                newscomment.CommentAuthor = commentAuthor;
                                newscomment.Comment = comment;
                                newscomment.DateOfCommentPosting = DateTime.Now;

                                connection.Execute("insert into NewsComments values(@CommentAuthor, @Comment, @DateOfCommentPublishing, @NewsId)", newscomment);
                            }
                        }
                    }
                }
            }
        }
    }
}
