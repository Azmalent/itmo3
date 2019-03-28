import javax.ejb.*;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import java.util.List;

@Stateful
public class PointService 
{
    EntityManagerFactory fact = Persistence.createEntityManagerFactory("JPAUNIT");
    EntityManager em = fact.createEntityManager();

    public void savePoint(Point point)
    {
        em.getTransaction().begin();
        em.persist(point);
        em.getTransaction().commit();
    }

    public void updatePoint(int id, double r, boolean hit)
    {
        Point point = em.find(Point.class, id);

        em.getTransaction().begin();
        point.setR(r);
        point.setHit(hit);
        em.getTransaction().commit();
    }

    public List<Point> getAllPoints()
    {
        return (List<Point>) em.createQuery("SELECT p FROM Point p").getResultList();
    }
}
