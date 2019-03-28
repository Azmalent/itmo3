import * as React from "react";

import VkLogo from "super-tiny-icons/images/svg/vk.svg";
import {Link} from "react-router-dom";
import {UserContext} from "./app";
import UserType from "../types/userType";

export class Header extends React.Component<{}, {}> {
    public render(): JSX.Element {

        return (
            <header className="sticky row">
                <label htmlFor="drawer-checkbox" className="button drawer-toggle hidden-md"/>
                <div className="row col-md-6 col-lg-4">
                    <label className="logo col-md">Галлея</label>
                    <Link className="button hidden-sm col-md" to="/">Главная</Link>
                    <Link className="button hidden-sm col-md" to="/articles/">Статьи</Link>
                    <Link className="button hidden-sm col-md" to="/space/">Карта</Link>
                </div>

                <div className="hidden-sm">
                    <UserContext.Consumer>
                        { value => value.userType
                          ? <div>
                                { value.userType == UserType.admin &&
                                    <Link className="button" to="/articles/new">Новая статья</Link>
                                }
                                <button className="button" onClick={value.logout}>Выход</button>
                            </div>

                          : <a className="svgButton">
                                <VkLogo onClick={value.login}/>
                            </a>
                        }
                    </UserContext.Consumer>
                </div>
            </header>
        );
    }
}

export default Header;
