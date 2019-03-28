import * as React from "react";
import {get, trim, uniqueId} from "lodash";
import {buildQuery, parseJson} from "../../utils";
import * as InfiniteScroll from "react-infinite-scroll-component";
import GenericList from "../generic/genericList";
import {RouteComponentProps} from "react-router";
import {KeyboardEvent} from "react";
import {ArticlePreview} from "./articlePreview";
import {IArticleProps} from "./article";

export type IFeedProps = RouteComponentProps<{query?: string}>

export interface IFeedState {
    page: number;
    articles: IArticleProps[];
    hasMore: boolean;
}

export class Feed extends React.Component<IFeedProps, IFeedState> {
    constructor(props: any) {
        super(props);

        this.state = {
            page: 0,
            articles: [],
            hasMore: true
        };
    }

    componentDidMount() {
        this.fetchNextPage();
    }

    private fetchNextPage(): void {
       setTimeout(() => {
           const query = get(this.props, ["match", "params", "query"]);
           const { page, articles } = this.state;

           const url = buildQuery("/rest/articles", [
               {name: "p", value: page.toString()},
               {name: "q", value: query}
           ]);
           const newArticles: IArticleProps[] = parseJson(url);

           this.setState({
               page: page + 1,
               articles: articles.concat(newArticles),
               hasMore: newArticles.length >= 5
           });
       }, 1500);
    };

    public render(): JSX.Element {
        const inputElement  = () => document.getElementById("search-input")  as HTMLInputElement;
        const buttonElement = () => document.getElementById("search-button") as HTMLButtonElement;
        const search = () => {
            const query = trim(inputElement().value);
            location.replace("/articles/search/" + query);
        };
        const updateInput = () => {
            const query = trim(inputElement().value);
            buttonElement().disabled = (query == "");
        };
        const onEnterPress = (e: KeyboardEvent<HTMLInputElement>) => {
            e.preventDefault();
            if (e.keyCode == 13) {
                buttonElement().click();
            }
        };

        const { articles, hasMore } = this.state;
        const count: number = articles.length;
        const articleRenderer = (props: IArticleProps) => {
            return <ArticlePreview key={uniqueId("article_")} {...props}/>;
        };

        return (
            <div className="full-width">
                <div className="row flex-center">
                    <input id="search-input" className="col-sm col-md-5" type="text" placeholder="Введите текст для поиска"
                           onChange={updateInput} onKeyUp={onEnterPress}/>
                    <div className="col-md-1">
                        <button id="search-button" className="small" disabled={true} onClick={search}>
                            <span className="icon-search"/>
                        </button>
                    </div>
                </div>

                <InfiniteScroll
                    dataLength={count}
                    next={this.fetchNextPage.bind(this)}
                    hasMore={hasMore}
                    loader={<div className="centered-text"><span className="spinner primary"/></div>}
                    endMessage={<h4 className="centered-text outlined-text">
                        {count > 0 ? ("Всего статей: " + count) : "Ничего не найдено :("}
                    </h4>}
                >
                    <GenericList items={articles} itemRenderer={articleRenderer}/>
                </InfiniteScroll>
            </div>
        );
    }
}

export default Feed;
