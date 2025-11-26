using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
// Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        video1.AddComment("Alice", "This was super helpful!");
        video1.AddComment("Bob", "Great explanation, thanks!");
        video1.AddComment("Charlie", "Can you do one for OOP next?");
        video1.AddComment("Diana", "Clear and concise. Subscribed!");
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Funny Cat Compilation 2025", "CatLover99", 420);
        video2.AddComment("KittyFan", "LOL the one at 2:30 killed me!");
        video2.AddComment("JohnDoe", "My cat does the same thing haha");
        video2.AddComment("Sarah", "Best compilation ever!");
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Cook Perfect Pasta", "ChefAntonio", 900);
        video3.AddComment("Maria", "Finally! Someone who salts the water right!");
        video3.AddComment("Luis", "This changed my pasta game forever");
        video3.AddComment("Emma", "Simple and perfect. Thank you!");
        video3.AddComment("Paul", "Where has this video been all my life?");
        videos.Add(video3);

        // Video 4 (optional fourth)
        Video video4 = new Video("Epic Gaming Moments #47", "ProGamerX", 720);
        video4.AddComment("xXNoScopeXx", "That clutch was INSANE");
        video4.AddComment("PixelKing", "Bro how did you pull that off?!");
        video4.AddComment("NinjaFan", "Montage material right here");
        videos.Add(video4);

        // Display all videos
        Console.WriteLine("=== YouTube Videos ===\n");
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }        
    }
}