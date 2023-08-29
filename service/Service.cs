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
    
       
    public IEnumerable<Articles> GetAllArticles()
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

}