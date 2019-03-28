import javax.ejb.*;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.*;
import javax.ws.rs.core.Context;
import java.util.ArrayList;

@Singleton
@Path(value = "/user")
public class UserBean 
{
    public static final String APP_NAME = "/";

    @EJB
    private UserService service;

    public UserBean() { }

    private boolean validateUser(String login, String password)
    {
        if (login.length() < 5 || login.length() > 20) return false;
        if (password.length() < 5 || password.length() > 20) return false;
        return true;
    }

    @POST
    @Path("/signup")
    public void newUser(@FormParam("login") String login, @FormParam("password") String password,
                        @Context HttpServletResponse resp, @Context HttpServletRequest req)
    {
        try
        {
            User user = new User(login, password);
            if (validateUser(login, password) && service.checkLogin(login))
            {
                service.saveUser(user);
                req.getSession().setAttribute("login", login);
                req.getSession().setAttribute("points", new ArrayList<Point>());
                resp.sendRedirect(APP_NAME + "main");
            }
            else
            {
                resp.sendRedirect(APP_NAME + "signup");
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    @POST
    @Path("/login")
    public void checkAuth(@FormParam("login") String login, @FormParam("password") String password,
                          @Context HttpServletResponse resp, @Context HttpServletRequest req)
    {
        try
        {
            boolean test = service.checkUser(login, password);
            System.out.println(test);
            if (validateUser(login, password) && service.checkUser(login, password))
            {
                req.getSession().setAttribute("login", login);
                req.getSession().setAttribute("points", new ArrayList<Point>());
                resp.sendRedirect(APP_NAME + "main");
            }
            else resp.sendRedirect(APP_NAME + "login");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    @POST
    @Path("/logout")
    public void logOut(@Context HttpServletRequest req, @Context HttpServletResponse resp)
    {
        try
        {
            req.getSession().invalidate();
            resp.sendRedirect(APP_NAME + "login");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
