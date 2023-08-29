using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using service;

namespace API.Controller;


[ApiController]
public class NewsController : ControllerBase
{
    private readonly Service _service;

    public NewsController(Service service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/api/articles")]
    public Articles PostNews(Articles articles)
    {
        return _service.CreateArticle(articles);
    }
    
    [HttpGet]
    [Route("/api/feed")]
    public IEnumerable<NewsFeedItem> GetArticles()
    {
        return _service.GetAllArticles();
    }

    [HttpGet]
    [Route("/api/articles/{articleId}")]
    public Articles GetArticleById([FromRoute] int articleId)
    {
        return _service.GetArticleById(articleId);
    }

    [HttpDelete]
    [Route("/api/articles/{articleId}")]
    public void DeleteArticleById([FromRoute] int articleId)
    {
        _service.DeleteArticleById(articleId);
    }

    [HttpPut]
    [Route("/api/articles/{articleId}")]
    public Articles UpdateArticles([FromRoute] int articleId, [FromBody] Articles article)
    {
        return _service.UpdateArticles(articleId, article);
    }

    [HttpGet]
    [Route("/api/articles")]
    public IEnumerable<Articles> SearchArticleItem([FromQuery] string searchterm, [FromQuery] int pagesize)
    {
        if (searchterm.Length >= 3)
        {
            return _service.SearchArticleItem(searchterm, pagesize);
        }

        throw new Exception("Not working for you");
    }
}