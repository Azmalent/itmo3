import * as React from "react";
import {Link} from "react-router-dom";
import {UserContext} from "./app";

export class NavigationMenu extends React.Component<{}, {}> {
    public render(): JSX.Element {
        return (
            <div className="hidden-md hidden-lg">
                <input id="drawer-checkbox" className="drawer" type="checkbox"/>
                <nav>
                    <label htmlFor="drawer-checkbox" className="drawer-close"/>
                    <Link to="/">Главная страница</Link>
                    <Link className="sublink-1" to="/articles/">Статьи</Link>
                    <Link to="/space/">Карта</Link>
                    <UserContext.Consumer>
                        { value =>
                            <button onClick={value.login}>Вход через ВК</button>
                        }
                    </UserContext.Consumer>
                </nav>
            </div>
        );
    }
}

export default NavigationMenu;
