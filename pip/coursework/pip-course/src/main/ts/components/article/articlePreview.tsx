import {Article, IArticleProps} from "./article";
import * as React from "react";
import {truncate, uniqueId} from "lodash";
import {Link} from "react-router-dom";

export class ArticlePreview extends React.Component<IArticleProps, {}> {
    render() {
        const props = this.props;
        const truncatedText = truncate(props.text, {
            length: 500,
            separator: /[,:;]? +/,
        });

        return (
            <div className="card fluid" key={uniqueId("article_")}>
                <Article {...props} text={truncatedText}/>
                <Link className="button secondary centered-text"
                        to={"/articles/" + props.id}>
                    Читать дальше
                </Link>
            </div>
        );
    }
}