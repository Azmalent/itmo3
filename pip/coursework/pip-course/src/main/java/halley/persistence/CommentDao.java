package halley.persistence;

import halley.entity.Comment;

import javax.enterprise.context.SessionScoped;
import javax.persistence.Query;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.*;
import javax.ws.rs.core.Context;
import java.util.List;

/**
 * Представляет интерфейс для CRUD-операций с комментариями.
 * @author Рушан
 * @since 2 этап
 */
@SessionScoped
@Path("/comments")
public class CommentDao extends AbstractDao<Comment, String> {

    public CommentDao() {
        super(Comment.class);
    }

    /**
     * Получает все комментарии к статье с заданным ID.
     * @author Рушан
     * @since 2 этап
     *
     * @param id    ID статьи
     *
     * @throws javax.persistence.NoResultException  Если статья не найдена
     *
     * @return Комментарии к статье с соответствующим ID
     */
    @GET
    @Path("/{id}")
    public List<Comment> getComments(@PathParam("id") int id,
                                     @Context HttpServletRequest request,
                                     @Context HttpServletResponse response) {
        Query query = em.createQuery("from Comment where article_id=:id order by date desc")
                        .setParameter("id", id);

        return (List<Comment>) query.getResultList();
    }

    /**
     * Создаёт комментарий в базе данных
     * @author Рушан
     * @since 2 этап
     *
     * @param articleId    ID статьи
     * @param authorId     ID автора ВКонтакте
     * @param authorName   Имя и фамилия автора ВКонтакте
     * @param text         Текст комментария
     */
    @POST
    public void createComment(@FormParam("articleId") int articleId,
                              @FormParam("authorId") int authorId,
                              @FormParam("authorName") String authorName,
                              @FormParam("text") String text,
                              @Context HttpServletRequest request,
                              @Context HttpServletResponse response
    ) {
        try{
            Comment comment = new Comment(articleId, authorId, authorName, text);
            persist(comment);

            response.sendRedirect("/articles/" + articleId);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
