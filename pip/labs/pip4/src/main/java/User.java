import javax.persistence.*;

@Entity
@Table(name = "users",schema = "s225116")
public class User 
{
    private int id;
    private String login;
    private int password;

    public User() { };
    public User(String login, String password)
    {
        this.login = login;
        this.password = password.hashCode();
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }

    @Column(name = "password", nullable = false)
    public int getPassword() { return password; }
    public void setPassword(int password) { this.password = password; }
    public void setPassword(String password) { this.password = password.hashCode(); }

    @Column(name = "login", nullable = false)
    public String getLogin() { return login; }
    public void setLogin(String login) { this.login = login; }
}
