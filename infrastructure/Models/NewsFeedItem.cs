using System.ComponentModel.DataAnnotations;

namespace infrastructure.Models;

public class NewsFeedItem
{
    public string Headline { get; set; }
    public int ArticleId { get; set; }
    public string ArticleImgUrl { get; set; }
    public string Body { get; set; }
}