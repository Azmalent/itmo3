import * as React from "react";
import {Redirect, RouteComponentProps} from "react-router";
import {UserContext} from "../app";
import {parseJson} from "../../utils";
import UserType from "../../types/userType";
import {trim} from "lodash";

export type IArticleEditProps = RouteComponentProps<{id: number}>;

export interface IArticleEditState {
    id: number;
    name: string,
    text: string
}

export class ArticleEdit extends React.Component<IArticleEditProps, IArticleEditState> {
    constructor(props: any) {
        super(props);

        const {match} = this.props;
        const id = match ? match.params.id : undefined;
        const data = id ? parseJson("/rest/articles/" + id) : {name: "", text: ""};
        this.state = {
            id: id,
            name: data.name,
            text: data.text
        };
    }

    private onFieldChange(fieldName: string) {
        return (event: any) => {
            const value = event.target.value;
            const button = document.getElementById("article_submit") as HTMLInputElement;
            button.disabled = (fieldName == "name" && trim(value) == "");

            const state: any = {};
            state[fieldName] = value;
            this.setState(state);
        }
    }

    public render(): JSX.Element {
        const {id, name, text} = this.state;
        return (

                <UserContext.Consumer>
                { value => value.userType == UserType.admin
                   ? <div className="card fluid">
                        <form action={"/rest/articles/" + (id || "")} method="post"
                           onSubmit={() => location.replace("/articles/" + id)}>
                            <fieldset>
                                <legend>Редактор статей</legend>
                                <div className="row">
                                    <input className="col-sm" type="text" name="articleName" value={name} placeholder="Название статьи"
                                           onChange={this.onFieldChange("name").bind(this)}/>
                                </div>
                                <div className="row">
                                    <textarea className="doc col-sm" name="text" value={text} placeholder="Текст"
                                              onChange={this.onFieldChange("text").bind(this)}/>
                                </div>
                                <div className="row">
                                    <input className="button primary col-sm" id="article_submit" type="submit" value="Отправить"/>
                                </div>
                            </fieldset>
                        </form>
                    </div>

                  : <Redirect to={"/articles/" + (id || "")}/>
                }
                </UserContext.Consumer>
        );
    }
}

export default ArticleEdit;
