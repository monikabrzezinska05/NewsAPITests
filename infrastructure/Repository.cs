using Dapper;
using infrastructure.Models;
using Npgsql;

namespace infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public Articles CreateArticle(Articles articles)
    {
        var sql = $@" 
INSERT INTO news.articles (headline, body, author, articleimgurl) 
VALUES (@Headline, @Body, @Author, @ArticleImgUrl)
RETURNING *;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Articles>(sql, articles);
        }
    }

    public IEnumerable<NewsFeedItem> GetAllArticles()
    {
        var sql = $@"
SELECT articleid, headline, left(body, 50) body, articleimgurl FROM news.articles;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<NewsFeedItem>(sql);
        }
    }

    public Articles GetArticleById(int articleId)
    {
        var sql = $@"
SELECT * FROM news.articles Where ArticleId = @articleid;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Articles>(sql, articleId);
        }
    }

    public void DeleteArticleById(int articleId)
    {
        var sql = $@"
DELETE FROM news.articles Where ArticleID = @articleid;";
        using (var conn = _dataSource.OpenConnection())
        {
            conn.Execute(sql, new { articleId });
        }
    }

    public Articles UpdateArticles(int articleId, Articles articles)
    {
        var sql = $@"
UPDATE news.articles SET headline = @headline, body = @body, articleimgurl = @articleimgurl, author = @author 
WHERE articleid = @articleid 
RETURNING articleid, headline, body, articleimgurl, author;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Articles>(sql, new {articles.Headline, articles.Body, articles.ArticleImgUrl, articles.Author, articleId});
        }
    }

    public IEnumerable<Articles> SearchArticleItem(string searchterm, int pagesize)
    {
        var sql = $@"
SELECT * FROM news.articles WHERE body LIKE '%' || @searchterm || '%' OR headline LIKE '%' || @searchterm || '%' LIMIT @pagesize;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Articles>(sql, new { searchterm, pagesize });
        }
    }
}