import javax.ejb.*;
import javax.persistence.*;

@Stateful
public class UserService 
{
    private EntityManagerFactory factory = Persistence.createEntityManagerFactory("JPAUNIT");
    private EntityManager em = factory.createEntityManager();

    public UserService() { }

    public void saveUser(User user)
    {
        em.getTransaction().begin();
        em.persist(user);
        em.getTransaction().commit();
    }

    public boolean checkUser(String login, String password)
    {
        try 
        {
            User user = (User) em.createQuery(" from User where login = :login")
                                 .setParameter("login", login).getSingleResult();

            return (user != null && password.hashCode() == user.getPassword());
        } 
        catch (NoResultException e)
        { 
            return false; 
        }
    }

    public boolean checkLogin(String login)
    {
        try 
        {
            User user = (User) em.createQuery(" from User where login = :login")
                                 .setParameter("login", login).getSingleResult();
            
            return (user == null);
        } 
        catch (NoResultException e)
        { 
            return true; 
        }
    }

}
