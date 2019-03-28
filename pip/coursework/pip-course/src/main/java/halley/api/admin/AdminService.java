package halley.api.admin;

import halley.api.auth.OAuthService;

import javax.ejb.Stateful;
import javax.enterprise.context.SessionScoped;
import javax.ws.rs.*;
import java.io.Serializable;

/**
 * Представляет интерфейс для проверки прав пользователей.
 * @author Рушан
 * @since 2 этап
 */
@SessionScoped
@Stateful
@Path("/admin")
public class AdminService implements Serializable {

    private OAuthService authService = new OAuthService();

    /**
     * Проверяет, является ли пользователь администратором.
     * @author Рушан
     * @since 2 этап
     *
     * @param id    ID пользователя для проверки.
     *
     * @return true, если пользователь имеет права администратора, и false в противном случае.
     */
    @GET
    @Path("/check")
    public String checkForAdmin(@QueryParam("id") String id) {
        try {
            return authService.checkUser(id,"admin") ? "true" : "false";
        } catch (Exception e) {
            return "false";
        }
    }
}
