package halley.utils;

import javax.ejb.Stateful;

@Stateful
public class Validator {
    public Validator() {}

    public boolean validateForSizeLoginAndPass(String login, String password) {
        if (login.length() < 5 || login.length() > 20) return false;

        if (password.length() < 5 || password.length() > 20) return false;

        return true;
    }
}
