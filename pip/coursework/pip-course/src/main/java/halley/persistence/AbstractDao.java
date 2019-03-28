package halley.persistence;

import javax.ejb.Stateful;
import javax.persistence.*;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import java.io.Serializable;

/**
 * Предоставляет абстрактный интерфейс для создания, чтения и удаления данных в БД.
 * @author Рушан
 * @since 2 этап
 */
@Stateful
@Produces(MediaType.APPLICATION_JSON)
public abstract class AbstractDao<T, TId> implements Serializable {

    protected final EntityManagerFactory factory;
    protected final EntityManager em;

    private final Class<T> type;

    protected AbstractDao(Class<T> type) {
        try {
            factory = Persistence.createEntityManagerFactory("halley");
        } catch (Throwable ex) {
            System.err.println("Failed to create EntityManagerFactory: " + ex);
            throw new PersistenceException(ex.getMessage());
        }

        try {
            em = factory.createEntityManager();
        } catch (Throwable ex) {
            System.err.println("Failed to create EntityManager: " + ex);
            throw new PersistenceException(ex.getMessage());
        }

        this.type = type;
    }

    /**
     * Сохраняет объект в базе данных.
     * @author Дмитрий
     * @since 2 этап
     *
     * @param item          Объект для записи в БД.
     */
    public void persist(T item) {
        EntityTransaction tx = null;
        try {
            tx = em.getTransaction();
            tx.begin();
            em.persist(item);
            tx.commit();
        } catch (Throwable e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
            throw e;
        }
    }

    /**
     * Получает запись из базы данных по первичному ключу.
     * @author Дмитрий
     * @since 2 этап
     *
     * @param key        Первичный ключ записи
     *
     * @return Полученный из базы данных объект
     * @throws NoResultException     Если запись не найдена
     */
    public T read(TId key) throws NoResultException {
        return em.find(type, key);
    }

    public boolean exists(TId key) {
        try {
            read(key);
            return true;
        } catch (NoResultException ex) {
            return false;
        }
    }

    /**
     * Удаляет запись из базы данных. Запись должна управляться JPA (т.е. получена методом read() или JPQL-запросом)
     * @author Дмитрий
     * @since 2 этап
     *
     * @param item      Запись, которую нужно удалить
     *
     * @throws NoResultException     Если запись не найдена
     */
    public void delete(T item) {
        EntityTransaction tx = null;
        try {
            tx = em.getTransaction();
            tx.begin();
            em.remove(item);
            tx.commit();
        }
        catch (NoResultException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
            throw e;
        }
    }

    /**
     * Удаляет объект из базы данных по первичному ключу.
     * @author Дмитрий
     * @since 2 этап
     *
     * @param key      Первичный ключ записи, которую нужно удалить
     *
     * @throws NoResultException     Если запись не найдена
     */
    public void deleteByKey(TId key) throws NoResultException {
        T item = read(key);
        delete(item);
    };
}
