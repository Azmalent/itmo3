import * as React from "react";
import {Link} from "react-router-dom";
import createBrowserHistory from "history/createBrowserHistory";

export class NotFound extends React.Component<{}, {}> {
    public render(): JSX.Element {
        const history = createBrowserHistory();
        return (
            <div className="center centered-text outlined-text">
                <h1>― 404 ―</h1>
                <p>Эта страница потерялась в открытом космосе.</p>
                <p>Проверьте, правильно ли вы указали координаты.</p>
                <span>  <a className="button primary" onClick={history.goBack}>Назад</a> </span>
                <span>  <Link className="button tertiary" to="/">На главную</Link> </span>
            </div>
        );
    }
}

export default NotFound;
