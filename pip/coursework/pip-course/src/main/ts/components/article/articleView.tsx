import * as React from "react";
import Article, {IArticleProps} from "./article";
import {Redirect, RouteComponentProps} from "react-router";
import {parseJson} from "../../utils";
import {UserContext} from "../app";
import UserType from "../../types/userType";
import {Link} from "react-router-dom";
import GenericList from "../generic/genericList";
import {default as Comment, ICommentProps} from "./comment";
import {trim, uniqueId} from "lodash"

export type IArticleViewProps = RouteComponentProps<{id: number}>;

export interface IArticleViewState {
    data: IArticleProps;
    comments: ICommentProps[];
}

export class ArticleView extends React.Component<IArticleViewProps, IArticleViewState> {
    constructor(props: any) {
        super(props);

        const {id} = this.props.match.params;
        this.state = {
            data: parseJson("/rest/articles/" + id, false),
            comments: parseJson("/rest/comments/" + id, false),
        }
    }

    private delete(): void {
        const xhr = new XMLHttpRequest();
        const {id} = this.props.match.params;
        xhr.open("DELETE", "/rest/articles/" + id, false);
        xhr.send();

        if (xhr.status === 200) {
            location.replace("/articles/")
        } else {
            alert("Ошибка " + xhr.status + ": " + xhr.statusText);
        }
    }

    public render(): JSX.Element {
        const {data, comments} = this.state;
        const {id} = this.props.match.params;
        const editUrl = "/articles/" + id + "/edit";

        const commentRenderer = (props: ICommentProps) => {
            return <Comment key={uniqueId("comment_")} {...props}/>;
        };

        const onTextChange = () => {
            const textarea = document.getElementById("comment_input") as HTMLTextAreaElement;
            const button = document.getElementById("comment_button") as HTMLButtonElement;
            const text = textarea.value;
            button.disabled = trim(text) == "";
        };

        return (
            data
              ? <div className="full-width">
                    <div className="card fluid">
                        <div className="section">
                            <Article {...data}/>
                        </div>
                        <UserContext.Consumer>
                        { value => value.userType == UserType.admin &&
                            <div className="row section button-group">
                                <Link className="col-sm-4 button primary" to={editUrl}>
                                    Редактировать
                                </Link>
                                <button className="col-sm-4 button secondary" onClick={this.delete.bind(this)}>
                                    Удалить
                                </button>
                            </div>
                        }
                        </UserContext.Consumer>
                    </div>

                    <div className="row">
                        <div className="col-sm col-lg-8 col-lg-offset-2">
                            <UserContext.Consumer>
                            { value => value.id &&
                                <form action="/rest/comments" method="post">
                                    <fieldset>
                                        <legend>Комментарий</legend>
                                        <textarea id="comment_input" name="text" rows={3} placeholder="Текст"
                                                  onChange={onTextChange}/>
                                        <input type="hidden" name="articleId" value={data.id}/>
                                        <input type="hidden" name="authorId" value={value.id}/>
                                        <input type="hidden" name="authorName" value={value.username}/>
                                        <button id="comment_button" type="submit">Отправить</button>
                                    </fieldset>
                                </form>
                            }
                            </UserContext.Consumer>

                            <GenericList items={comments} itemRenderer={commentRenderer}/>
                        </div>
                    </div>
                </div>

              : <Redirect to='/404' />
        );
    }
}

export default ArticleView;
