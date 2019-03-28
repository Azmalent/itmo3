import java.util.List;

import javax.ejb.*;
import javax.faces.bean.SessionScoped;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.FormParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.Context;

@Stateful
@SessionScoped
@Path("/point")
public class PointBean
{
    private PointService service = new PointService();

    private double distance(Point a, Point b)
    {
        return Math.sqrt(Math.pow(a.getX() - b.getX(), 2) + Math.pow(a.getY() - b.getY(), 2));
    }

    private double triangleArea(Point a, Point b, Point c) 
    {
        double ab = distance(a, b);
        double bc = distance(b, c);
        double ca = distance(c, a);
        double p = (ab + bc + ca) / 2;
        return Math.sqrt(p * (p - ab) * (p - bc) * (p - ca));
    }

    private boolean checkHit(Point p)
    {
        Point center = new Point(0, 0, 0);

        //Квадрат R x R в II четверти
        if (p.getX() >= -p.getR() && p.getX() <= 0 && p.getY() >= 0 && p.getY() <= p.getR())
            return true;

        //сектор радиуса R/2 в III четверти
        if (p.getX() <= 0 && p.getY() <= 0 && distance(center, p) <= p.getR() / 2)
            return true;

        ///треугольник в IV четверти
        Point a = new Point(p.getR() / 2, 0, 0);
        Point b = new Point(0, -p.getR() / 2, 0);
        double abc = triangleArea(a, b, center);
        double abp = triangleArea(a, b, p);
        double acp = triangleArea(a, p, center);
        double bcp = triangleArea(p, b, center);

        return Math.abs(abp + acp + bcp - abc) < 1E-5;
    }

    @POST
    @Path("/check")
    public void check(@FormParam("X") double x, @FormParam("Y") double y, @FormParam("R") double r,
                      @Context HttpServletRequest req, @Context HttpServletResponse resp)
    { 
        try 
        {
            Point point = new Point(x, y, r);
            boolean hit = checkHit(point);
            point.setHit(hit);

            service.savePoint(point);

            List<Point> list = (List<Point>) req.getSession().getAttribute("points");
            list.add(point);

            resp.sendRedirect(UserBean.APP_NAME + "main");
        } 
        catch (Exception e)
        { 
            e.printStackTrace(); 
        }
    }

    @GET
    @Path("/getpoints")
    public List<Point> getPoints(@Context HttpServletRequest req)
    {
        return service.getAllPoints();
    }

    @GET
    @Path("/update")
    public void updateRadius(@QueryParam("r") double r, @Context HttpServletRequest req)
    {
        List<Point> points = service.getAllPoints();

        for(Point p : points)
        {
            p.setR(r);
            boolean hit = checkHit(p);
            service.updatePoint(p.getId(), r, hit);
        }
    }
}