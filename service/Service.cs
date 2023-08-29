using infrastructure;
using infrastructure.Models;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }
    
    public Articles CreateArticle(Articles articles)
    {
        return _repository.CreateArticle(articles);
    }
    
       
    public IEnumerable<NewsFeedItem> GetAllArticles()
    {
        try
        {
            return _repository.GetAllArticles();
        }
        catch (Exception)
        {
            throw new Exception("Could not get Articles");
        }
    }

    public Articles GetArticleById(int articleId)
    {
        return _repository.GetArticleById(articleId);
    }


    public void DeleteArticleById(int articleId)
    {
        _repository.DeleteArticleById(articleId);
    }

    public Articles UpdateArticles(int articleId, Articles articles)
    {
        return _repository.UpdateArticles(articleId, articles);
    }

    public IEnumerable<Articles> SearchArticleItem(string searchterm, int pagesize)
    {
        return _repository.SearchArticleItem(searchterm, pagesize);
    }
}