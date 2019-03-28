package halley.api.auth;

import halley.entity.UserGroup;

import javax.ejb.Stateful;
import javax.persistence.*;

@Stateful
public class OAuthService {
    private EntityManagerFactory factory = Persistence.createEntityManagerFactory("halley");
    private EntityManager em = factory.createEntityManager();

    public OAuthService() { }

    public boolean checkUser(String id, String group) {
        try {
            UserGroup userGroup = findUserInDB(id);

            return (userGroup != null && userGroup.getUserGroup().equals(group));
        } catch (NoResultException e) {
            return false;
        }
    }

    private UserGroup findUserInDB(String id) {
        return (UserGroup) em.createQuery(" from UserGroup where user_login = :id")
                .setParameter("id", id).getSingleResult();
    }
}
