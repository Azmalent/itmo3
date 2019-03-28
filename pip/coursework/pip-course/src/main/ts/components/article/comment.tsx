import * as React from "react";
import * as _ from "lodash";

export interface ICommentProps {
    authorId: number;
    authorName: string;
    date: string;
    text: string;
}

export class Comment extends React.Component<ICommentProps, {}> {
    public render(): JSX.Element {
        const {authorId, authorName, date, text} = this.props;
        const authorUrl = "https://vk.com/id" + authorId;

        return (
            <div className="card fluid">
                <div className="section">
                    <p>
                        <a href={authorUrl}><strong>{authorName}</strong></a>
                        {" " + _(date).split(' ').head()}
                    </p>
                </div>
                <div className="section">
                    {text}
                </div>
            </div>
        );
    }
}

export default Comment;
