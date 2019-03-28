import org.hibernate.*;
import org.hibernate.cfg.Configuration;

import javax.faces.bean.ManagedBean;
import javax.faces.context.FacesContext;
import javax.servlet.ServletContext;
import java.io.File;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class ResultManagerBean implements Serializable
{
    private double x, y, r;
    private final SessionFactory sessionFactory;

    public ResultManagerBean()
    {
        r = 1;
        try
        {
            ServletContext ctx = (ServletContext)
                    FacesContext.getCurrentInstance().getExternalContext().getContext();

            String configPath = ctx.getRealPath("/") + "WEB-INF/hibernate.cfg.xml";
            sessionFactory = new Configuration().configure(new File(configPath)).buildSessionFactory();
        }
        catch (Throwable ex)
        {
            System.err.println("Failed to create SessionFactory: " + ex);
            throw new SessionException(ex.getMessage());
        }
    }

    public double getX()
    {
        return x;
    }
    public void setX(double x)
    {
        this.x = x;
    }

    public double getY()
    {
        return y;
    }
    public void setY(double y)
    {
        this.y = y;
    }

    public double getR()
    {
        return r;
    }
    public void setR(double r)
    {
        this.r = r;
    }

    public boolean checkArea(double x, double y)
    {
        Point p = new Point(x, y);
        Point center = new Point(0, 0);

        //четверть окружности радиуса R/2 в III четверти
        if (p.x <= 0 && p.y <= 0 && Utils.distance(center, p) <= r/2)
            return true;

        //Квадрат R x R в I четверти
        if (p.x >= 0 && p.x <= r && p.y >= 0 && p.y <= r)
            return true;

        ///треугольник в IV четверти
        Point a = new Point(r/2, 0), b = new Point(0, -r);
        double abc = Utils.triangleArea(a, b, center),
                abp = Utils.triangleArea(a, b, p),
                acp = Utils.triangleArea(a, p, center),
                bcp = Utils.triangleArea(p, b, center);

        return Utils.doubleEquals(abc, abp + acp + bcp);
    }

    public void submit()
    {
        boolean hit = checkArea(x, y);

        ResultEntity result = new ResultEntity();
        result.setX(x);
        result.setY(y);
        result.setR(r);
        result.setHit(hit);

        Transaction tx = null;
        try
        {
            Session session = sessionFactory.openSession();
            tx = session.beginTransaction();
            session.flush();
            session.save(result);
            tx.commit();
        }
        catch (Throwable e)
        {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        }
    }

    public List getResultList()
    {
        Session session;
        List resultList = new ArrayList<ResultEntity>();

        try
        {
            session = sessionFactory.openSession();
            Query query = session.createQuery("FROM ResultEntity ORDER BY id DESC");
            resultList = query.list();
        }
        catch (Throwable e)
        {
            e.printStackTrace();
        }

        return resultList;
    }

    public void clearHistory()
    {
        Transaction tx = null;
        try
        {
            Session session = sessionFactory.openSession();
            tx = session.beginTransaction();
            Query query = session.createQuery("DELETE FROM ResultEntity");
            query.executeUpdate();
            tx.commit();
        }
        catch (Throwable e)
        {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        }
    }
}
