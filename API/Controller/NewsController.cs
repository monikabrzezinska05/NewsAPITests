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
    public IEnumerable<Articles> GetArticles()
    {
        return _service.GetAllArticles();
    }
    
}