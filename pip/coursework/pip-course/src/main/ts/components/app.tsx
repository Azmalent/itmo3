import * as React from "react";
import {BrowserRouter as Router, Switch, Route} from "react-router-dom";
import Feed from "./article/feed";
import Footer from "./footer";
import Header from "./header";
import Home from "./home";
import NotFound from "./notfound";
import NavigationMenu from "./navigationMenu";
import IUserContext from "../types/userContext";
import Space from "./space/space";
import ArticleView from "./article/articleView";
import ArticleEdit from "./article/articleEdit";
import UserType from "../types/userType";
import {parseBoolean} from "../utils";

export const UserContext: React.Context<IUserContext> = React.createContext({
    login:  () => {},
    logout: () => {}
});

export type IAppState = IUserContext;

export class App extends React.Component<{}, IAppState> {
    constructor(props: any) {
        super(props);

        const login = () => {
            const xhr = new XMLHttpRequest();
            xhr.open("GET", "/rest/user/vk", false);
            xhr.send();

            if (xhr.status == 200) {
                const url = xhr.responseText;
                location.replace(url);
            } else {
                alert("Ошибка " + xhr.status + ": " + xhr.statusText);
            }
        };

        const logout = () => {
            this.setState({username: undefined, userType: undefined});

            const xhr = new XMLHttpRequest();
            xhr.open("POST", "/rest/user/logout", false);
            xhr.send();

            if (xhr.status != 200) {
                alert("Ошибка " + xhr.status + ": " + xhr.statusText);
            }
        };

        this.state = {
            login:  login.bind(this),
            logout: logout.bind(this)
        };
    }

    componentDidMount() {
        const xhr = new XMLHttpRequest();
        xhr.open("GET", "/rest/user/param", false);
        xhr.send();
        if (xhr.status == 200) {
            const results: string[] = xhr.responseText.split(";");
            const id: number = parseInt(results[0]);

            const checkXhr = new XMLHttpRequest();
            checkXhr.open("GET", "/rest/admin/check?id=" + id, false);
            checkXhr.send();
            const isAdmin: boolean = parseBoolean(checkXhr.responseText);

            this.setState({
                id: id,
                username: results[1] + " " + results[2],
                userType: isAdmin ? UserType.admin : UserType.user
            });
        } else {
            this.setState({
                id: undefined,
                username: undefined,
                userType: undefined
            });
        }
    }

    public render(): JSX.Element {
        const wrap = (Component: any, props: any = {}): JSX.Element => {
            return (
                <UserContext.Provider value={this.state}>
                    <Header/>
                    <NavigationMenu/>
                    <div className="content row">
                        <div className="col-sm-12 col-md-10 col-md-offset-1 row">
                            <Component {...props}/>
                        </div>
                    </div>
                    <Footer/>
                </UserContext.Provider>);
        };

        return (
            <Router>
                    <Switch>
                        <Route exact path="/" render={() => wrap(Home)}/>

                        <Route exact path="/articles" render={() => wrap(Feed)}/>
                        <Route exact path="/articles/search/:query" render={(props) => wrap(Feed, props)}/>
                        <Route exact path="/articles/new" render={() => wrap(ArticleEdit)}/>
                        <Route exact path="/articles/:id" render={(props) => wrap(ArticleView, props)}/>
                        <Route exact path="/articles/:id/edit" render={(props) => wrap(ArticleEdit, props)}/>

                        <Route exact path="/space"   render={() => wrap(Space)}/>
                        <Route component={NotFound}/>

                    </Switch>
            </Router>
        );
    }
}

export default App;
