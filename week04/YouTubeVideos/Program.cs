using System;
    using System.Collections.Generic;

// Comment class - responsible for commenter name + text
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class - responsible for title, author, length, and list of comments
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

// Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

// Method required by spec: return number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

// Helper to get all comments for display
    public List<Comment> GetComments()
    {
        return _comments;
    }   
}

// Main program - just creates objects and displays
class Program
{
    static void Main(string[] args)
    {
// Create list to hold videos
        List<Video> videos = new List<Video>();

        Video v1 = new Video("C# OOP Basics", "CodeWithBro", 420);
        v1.AddComment(new Comment("Alice", "This finally made classes click for me"));
        v1.AddComment(new Comment("Ben", "More examples please!"));
        v1.AddComment(new Comment("Cara", "Length was perfect"));
        videos.Add(v1);

        Video v2 = new Video("Building REST APIs with .NET", "DotNetMaster", 900);
        v2.AddComment(new Comment("David", "Best tutorial on routing"));
        v2.AddComment(new Comment("Eva", "I struggled with controllers before this"));
        v2.AddComment(new Comment("Frank", "Can you do EF Core next?"));
        v2.AddComment(new Comment("Grace", "Saved me hours of debugging"));
        videos.Add(v2);

        Video v3 = new Video("Async/Await Explained", "AsyncQueen", 600);
        v3.AddComment(new Comment("Henry", "The diagram at 5:00 was clutch"));
        v3.AddComment(new Comment("Ivy", "Still confused about Task vs void"));
        v3.AddComment(new Comment("Jack", "Great pacing"));
        videos.Add(v3);

        Video v4 = new Video("LINQ in 10 Minutes", "QueryGuru", 580);
        v4.AddComment(new Comment("Kim", "Where vs Select finally makes sense"));
        v4.AddComment(new Comment("Leo", "Need a part 2 on joins"));
        v4.AddComment(new Comment("Mia", "Concise and useful"));
        v4.AddComment(new Comment("Noah", "First time LINQ didn't scare me"));
        videos.Add(v4);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}