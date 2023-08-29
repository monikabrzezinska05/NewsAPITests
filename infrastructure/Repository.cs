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

    public IEnumerable<Articles> GetArticleById()
    {
        var sql $@"

"
    }
}