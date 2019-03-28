import javax.servlet.*;
import javax.servlet.http.*;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class AreaCheckServlet extends HttpServlet
{
    private boolean checkArea(float r, Point p)
            throws IOException
    {
        Point center = new Point(0, 0);

        //четверть окружности радиуса R в I четверти
        if (p.x > 0 && p.y > 0 && Utils.distance(center, p) < r)
            return true;

        //Прямоугольник R/2 x R в IV четверти
        if (p.x > 0 && p.x < r / 2 && p.y < 0 && p.y > -r)
            return true;

        ///треугольник в II четверти
        Point a = new Point(-r, 0), b = new Point(0, r);
        double abc = Utils.triangleArea(a, b, center),
                abp = Utils.triangleArea(a, b, p),
                acp = Utils.triangleArea(a, p, center),
                bcp = Utils.triangleArea(p, b, center);

        return (abp != 0 && acp != 0 && bcp != 0 && Utils.doubleEquals(abc, abp + acp + bcp));
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException
    {
        String rStr = request.getParameter("r"),
               xStr = request.getParameter("x"),
               yStr = request.getParameter("y");
        float r = Float.NaN, x = Float.NaN, y = Float.NaN;
        boolean error = false, result = false;
        try {
            r = Float.parseFloat(rStr.replace(',', '.'));
            x = Float.parseFloat(xStr.replace(',', '.'));
            y = Float.parseFloat(yStr.replace(',', '.'));

            Point p = new Point(x, y);
            result = checkArea(r, p);
        }
        catch (Exception e) { error = true; }

        if (r < 0 || Math.abs(x) > 5 || Math.abs(y) > 5) error = true;

        PrintWriter out = response.getWriter();
        //если это AJAX-запрос, возвращаем yes/no
        boolean ajax = "XMLHttpRequest".equals(request.getHeader("X-Requested-With"));
        if(ajax)
        {
            response.setContentType("text");
            out.print(result ? "Yes" : "No");
            return;
        }

        //выводим страницу
        response.setContentType("text/html");
        out.print("<!DOCTYPE html>" +
                  "<html lang=\"en\">" +
                  "<style type=\"text/css\">" +
                  " div {" +
                  "     margin: 5% auto 5%" +
                  " }" +
                  " table {" +
                  "   border: outset black;" +
                  "   background-color: white;" +
                  "   margin: inherit;" +
                  "   text-align: center;" +
                  " }" +
                  "</style>" +
                  "<head>" +
                  "    <meta charset=\"UTF-8\">" +
                  "    <title>Results</title>" +
                  "</head>" +
                  "<body>" +
                  "    <div> " +
                  "       <table border=\"1\">" +
                  "            <tr>" +
                  "                <th>Radius</th>" +
                  "                <th>X</th>" +
                  "                <th>Y</th>" +
                  "                <th>Included?</th>" +
                  "            </tr>" +
                  "            <tr>" +
                  "                <td>" + (!Float.isNaN(r) ? r : rStr) + "</td>" +
                  "                <td>" + (!Float.isNaN(x) ? x : xStr) + "</td>" +
                  "                <td>" + (!Float.isNaN(y) ? y : yStr)  + "</td>" +
                  "                <td>" + (error ? "Error!" : result ? "Yes" : "No") + "</td>" +
                  "            </tr>" +
                  "       </table>" +
                  "    </div>" +
                  "    <div style=\"text-align: center\">" +
                  "       <button onclick=\"location.href='./';\">Return</button>" +
                  "    </div>" +
                  "</body>" +
                  "</html>");
        out.close();
        if (error) return;

        //сохраняем данные в контекст
        ServletContext context = getServletContext();

        ArrayList<Float> rList = (ArrayList)context.getAttribute("r");
        ArrayList<Float> xList = (ArrayList)context.getAttribute("x");
        ArrayList<Float> yList = (ArrayList)context.getAttribute("y");
        ArrayList<Boolean> resList = (ArrayList)context.getAttribute("result");

        if(rList == null || xList == null || yList == null || resList == null)
        {
            rList = new ArrayList<Float>(10);
            xList = new ArrayList<Float>(10);
            yList = new ArrayList<Float>(10);
            resList = new ArrayList<Boolean>(10);
        }

        rList.add(r);
        xList.add(x);
        yList.add(y);
        resList.add(result);

        context.setAttribute("r", rList);
        context.setAttribute("x", xList);
        context.setAttribute("y", yList);
        context.setAttribute("result", resList);
    }
}
