using System;
using EFTutorial.Models;
using System.Linq;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int endProgram = 0;
            do
            {
                Console.WriteLine("1: Display Blogs");
                Console.WriteLine("2: Add Blog");
                Console.WriteLine("3: Display Posts");
                Console.WriteLine("4: Add Post");
                Console.WriteLine("5: Exit");
                String userChoice = Console.ReadLine();

                // 1. Display Blogs
                if (userChoice == "1")
                {
                    using (var db = new BlogContext())
                    {
                        Console.WriteLine("Here is the list of blogs");
                        foreach (var b in db.Blogs)
                        {
                            Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                        }
                    }
                }

                // 2. Add Blog
                else if (userChoice == "2")
                {
                    Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();

                    // // Create new Blog
                    var blog = new Blog();
                    blog.Name = blogName;

                    // // Save blog object to database
                    using (var db = new BlogContext())
                    {
                        db.Add(blog);
                        db.SaveChanges();
                    }
                }


                // 3. Display Posts
                else if (userChoice == "3")
                {
                    using (var db = new BlogContext())
                    {
                        Console.WriteLine("Enter blog ID");
                        int userInput = Int32.Parse(Console.ReadLine());

                        var blog = db.Blogs.Where(x => x.BlogId == userInput).FirstOrDefault();
                        // var blogsList = blog.ToList(); // convert to List from IQueryable

                        Console.WriteLine($"Posts for Blog {blog.Name}");

                        foreach (var post in blog.Posts)
                        {
                            System.Console.WriteLine($"\tPost {post.PostId} {post.Title}");
                        }
                    }
                }



                // 4. Add Post
                else if (userChoice == "4")
                {
                    Console.WriteLine("Enter blog ID");
                    int userInput = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Enter your Post title");
                    var postTitle = Console.ReadLine();

                    var post = new Post();
                    post.Title = postTitle;
                    post.BlogId = userInput;

                    using (var db = new BlogContext())
                    {
                        db.Posts.Add(post);
                        db.SaveChanges();
                    }
                }

                else if (userChoice == "5")
                {
                    endProgram = 1;
                }

                else
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (endProgram != 1);







        }
    }
}
