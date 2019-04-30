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
                using (var connection = new SqlConnection(connectionString))
                {
                    NewsComments newComment = new NewsComments();
                    newComment.NewsId = id;
                    Console.WriteLine("Enter your name");
                    newComment.CommentAuthor = Console.ReadLine();
                    Console.WriteLine("Enter your comment");
                    newComment.Comment = Console.ReadLine();
                    Console.WriteLine("Enter your name");
                    newComment.DateOfCommentPosting = DateTime.Now;
                   

                    connection.Execute("insert into NewsComments values(@CommentAuthor, @Comment, @DateOfCommentPosting)", newComment);
                }
            }
        }
    }
}
