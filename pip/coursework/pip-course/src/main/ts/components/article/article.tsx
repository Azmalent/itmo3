import * as React from "react";
import * as _ from "lodash";

export interface IArticleProps {
    id: number;
    name: string;
    date: string;
    text: string;
}

export class Article extends React.Component<IArticleProps, {}> {
    public render(): JSX.Element {
        const {name, date, text} = this.props;

        return (
            <div className="card fluid">
                <div className="section dark centered-text">
                    <h3>{name}</h3>
                    <p>{_(date).split(' ').head()}</p>
                </div>
                <p>{text}</p>
            </div>
        );
    }
}

export default Article;
