package halley.api.auth;

import com.github.scribejava.apis.VkontakteApi;
import com.github.scribejava.core.builder.ServiceBuilder;
import com.github.scribejava.core.model.OAuth2AccessToken;
import com.github.scribejava.core.model.OAuthRequest;
import com.github.scribejava.core.model.Response;
import com.github.scribejava.core.model.Verb;
import com.github.scribejava.core.oauth.OAuth20Service;
import org.json.JSONArray;
import org.json.JSONObject;

import javax.ejb.Singleton;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.Context;

/**
 * Представляет интерфейс для авторизации пользователей.
 * @author Рушан
 * @since 2 этап
 */
@Singleton
@Path(value = "/user")
public class OAuthBean {
	private static final int PORT = 49680;
	
    public OAuthBean() {
        final String clientId = "CLIENT_ID";
        final String clientSecret = "CLIENT_SECRET";
        OAuth20Service service = new ServiceBuilder(clientId)
                .apiSecret(clientSecret)
                .scope("email")
                .callback("http://localhost:" + PORTBASE + "/rest/user/vk/callback")
                .build(VkontakteApi.instance());

        this.service = service;
    }

    private static final String PROTECTED_RESOURCE_URL = "https://api.vk.com/method/users.get?v="
            + VkontakteApi.VERSION;

    private final OAuth20Service service;

    /**
     * Возвращает URL для авторизации через ВКонтакте.
     * @author Рушан
     * @since 2 этап
     *
     * @return URL для перехода.
     */
    @GET
    @Path("/vk")
    public String loginUsingVK(@Context HttpServletResponse response,
                               @Context HttpServletRequest request
    ) {
        final String authorizationUrl;
        try {
            authorizationUrl = service.getAuthorizationUrl();
        } catch (Exception e) {
            return e.toString();
        }

        return authorizationUrl;
    }

    /**
     * Коллбэк для авторизации через ВКонтакте.
     * @author Рушан
     * @since 2 этап
     *
     * @param code  Код авторизации
     *
     * @return  ID, имя и фамилия пользователя
     */
    @GET
    @Path("/vk/callback")
    public String authUsingVK(
            @QueryParam("code") String code,
            @Context HttpServletRequest req,
            @Context HttpServletResponse resp
    ) {
        String firstName = null,
                lastName = null;
        int id = 0;

        OAuth2AccessToken accessToken = null;
        Response response = null;
        try {
            accessToken = service.getAccessToken(code);

            OAuthRequest request = new OAuthRequest(Verb.GET,PROTECTED_RESOURCE_URL);
            service.signRequest(accessToken,request);
            response = service.execute(request);

            JSONObject body = new JSONObject(response.getBody());
            JSONArray arr   = body.getJSONArray("response");

            for (int i = 0; i < arr.length(); i++)
            {
                id          = arr.getJSONObject(i).getInt("id");
                firstName   = arr.getJSONObject(i).getString("first_name");
                lastName    = arr.getJSONObject(i).getString("last_name");
            }

            req.getSession().setAttribute("id",id);
            req.getSession().setAttribute("first_name",firstName);
            req.getSession().setAttribute("last_name",lastName);

            resp.sendRedirect("/");
            return id + " " + firstName + " " + lastName;
        } catch (Exception e) {
            return e.toString();
        }
    }

    /**
     * Осуществляет выход из аккаунта.
     * @author Рушан
     * @since 2 этап
     */
    @POST
    @Path("/logout")
    public void logout(@Context HttpServletResponse response,
                       @Context HttpServletRequest request
    ) {
        try {
            request.getSession().invalidate();
            response.sendRedirect("/");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Возвращает параметры пользователя, хранящиеся в сессии.
     * @author Рушан
     * @since 2 этап
     *
     * @return Данные пользователя
     */
    @GET
    @Path("/param")
    public String getParam(@Context HttpServletRequest request)
    {
        int id = (int) request.getSession().getAttribute("id");
        String firstName = (String) request.getSession().getAttribute("first_name"),
                lastName = (String) request.getSession().getAttribute("last_name");

        return id + ";" + firstName + ";" + lastName + ";";
    }
}
