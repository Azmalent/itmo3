package halley.persistence;

import halley.entity.Article;

import javax.enterprise.context.SessionScoped;
import javax.persistence.EntityTransaction;
import javax.persistence.Query;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.*;
import javax.ws.rs.core.Context;
import java.util.List;

/**
 * Представляет интерфейс для CRUD-операций со статьями.
 * @author Рушан
 * @since 2 этап
 */
@SessionScoped
@Path("/articles")
public class ArticleDao extends AbstractDao<Article, Integer> {

    private static final int PAGE_SIZE = 5;

    public ArticleDao() {
        super(Article.class);
    }

    /**
     * Получает 5 статей, упорядоченных по дате добавления, из базы данных.
     * @author Рушан
     * @since 2 этап
     *
     * @param page          Номер страницы для запроса (по умолчанию 0)
     * @param searchQuery   Запрос для поиска по тексту (опционально)
     *
     * @return Страница, содержащая до 5 статей
     */
    @GET
    public List<Article> getArticles(@QueryParam("p") @DefaultValue("0") int page,
                                    @QueryParam("q") @DefaultValue("")  String searchQuery,
                                    @Context HttpServletRequest request,
                                    @Context HttpServletResponse response) {
        Query query = em.createQuery("from Article " +
                                     "where lower(text) like '%' || lower(:query) || '%' " +
                                     "order by date desc")
                        .setParameter("query", searchQuery)
                        .setFirstResult(PAGE_SIZE * page)
                        .setMaxResults(PAGE_SIZE);
        return (List<Article>) query.getResultList();
    }

    /**
     * Сохраняет статью в базе данных.
     * @author Рушан
     * @since 2 этап
     *
     * @param name   Название статьи
     * @param text   Текст статьи
     */
    @POST
    public void createArticles(@FormParam("articleName") String name,
                               @FormParam("text") String text,
                               @Context HttpServletRequest request,
                               @Context HttpServletResponse response
    ) {
        try{
            Article article = new Article(name, text);

            persist(article);

            Integer id = article.getId();
            response.sendRedirect("/articles/" + id);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     * Получает статью по ID.
     * @author Рушан
     * @since 2 этап
     *
     * @param id    ID статьи
     *
     * @throws javax.persistence.NoResultException  Если статья не найдена
     *
     * @return Страница с соответствующим ID
     */
    @GET
    @Path("/{id}")
    public Article getArticle(@PathParam("id") int id) {

        return (Article) em.createQuery("from Article where id=:id")
                           .setParameter("id", id)
                           .getSingleResult();
    }

    /**
     * Получает статью по названию.
     * @author Рушан
     * @since 2 этап
     *
     * @param name   Название страницы
     *
     * @throws javax.persistence.NoResultException  Если статья не найдена
     *
     * @return Страница с соответствующим названиием
     */
    @GET
    @Path("/name")
    public Article getArticleByName(@QueryParam("name") String name,
                                    @Context HttpServletRequest request,
                                    @Context HttpServletResponse response) {
        return  (Article) em.createQuery("from Article where name=:name")
                            .setParameter("name", name)
                            .getSingleResult();
    }

    /**
     * Обновляет статью в базе данных.
     * @author Рушан
     * @since 2 этап
     *
     * @param id    ID статьи
     * @param name  Название статьи
     * @param text  Текст статьи
     */
    @POST
    @Path("/{id}")
    public void updateArticles(@PathParam("id") int id,
                               @FormParam("articleName") String name,
                               @FormParam("text") String text,
                               @Context HttpServletRequest request,
                               @Context HttpServletResponse response
    ) {
        Article article = read(id);
        article.setName(name);
        article.setText(text);

        EntityTransaction tx = null;
        try {
            tx = em.getTransaction();
            tx.begin();
            em.merge(article);
            tx.commit();
        } catch (Throwable e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
            throw e;
        }
    }

    /**
     * Удаляет статью из базы данных.
     * @author Рушан
     * @since 2 этап
     *
     * @param id    ID статьи
     *
     * @throws javax.persistence.NoResultException  Если статья не найдена
     */
    @DELETE
    @Path("/{id}")
    public void deleteArticle(@PathParam("id") int id) {
        Article article = read(id);

        if (article != null) {
            delete(article);
        }
    }
}
