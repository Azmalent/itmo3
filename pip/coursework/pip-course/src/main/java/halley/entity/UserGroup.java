package halley.entity;

import javax.persistence.*;

@Entity
@Table(name = "USER_GROUPS", schema = "S225116")
public class UserGroup {
    private String user;
    private String userGroup;

    public UserGroup(){ }

    public UserGroup(String user, String userGroup) {
        this.user = user;
        this.userGroup = userGroup;
    }

    @Id
    @Column(name = "USER_LOGIN", nullable = false)
    public String getUser() {
        return user;
    }
    public void setUser(String user) {
        this.user = user;
    }

    @Basic
    @Column(name = "USER_GROUP", nullable = false)
    public String getUserGroup() {
        return userGroup;
    }
    public void setUserGroup(String userGroup) {
        this.userGroup = userGroup;
    }
}
